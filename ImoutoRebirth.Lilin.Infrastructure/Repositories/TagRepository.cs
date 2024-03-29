﻿using ImoutoRebirth.Lilin.Core.Infrastructure;
using ImoutoRebirth.Lilin.Core.Models;
using ImoutoRebirth.Lilin.DataAccess;
using ImoutoRebirth.Lilin.DataAccess.Entities;
using ImoutoRebirth.Lilin.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace ImoutoRebirth.Lilin.Infrastructure.Repositories;

public class TagRepository : ITagRepository
{
    private readonly LilinDbContext _lilinDbContext;

    public TagRepository(LilinDbContext lilinDbContext) => _lilinDbContext = lilinDbContext;

    public async Task<Tag?> Get(string name, Guid typeId, CancellationToken ct)
    {
        var result = await _lilinDbContext.Tags
            .Include(x => x.Type)
            .SingleOrDefaultAsync(x => x.Name == name && x.TypeId == typeId, cancellationToken: ct);

        return result?.ToModel();
    }

    public async Task<Tag?> Get(Guid id, CancellationToken ct)
    {
        var result = await _lilinDbContext.Tags
            .Include(x => x.Type)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken: ct);

        return result?.ToModel();
    }

    public async Task<IReadOnlyCollection<Tag>> Search(
        string? requestSearchPattern, 
        int requestLimit, 
        CancellationToken ct)
    {
        var tagsWithTypes = _lilinDbContext.Tags
            .OrderByDescending(x => x.Count)
            .Include(x => x.Type);

        List<TagEntity> finalResult;
        if (string.IsNullOrEmpty(requestSearchPattern))
        {
            finalResult = await tagsWithTypes.Take(requestLimit).ToListAsync(cancellationToken: ct);
        }
        else
        {
            requestSearchPattern = requestSearchPattern.ToLower();

            finalResult = await tagsWithTypes
                .Where(x => x.Name.ToLower().Equals(requestSearchPattern))
                .Take(requestLimit)
                .ToListAsync(cancellationToken: ct);

            if (finalResult.Count < requestLimit)
            {
                var startsWith = await tagsWithTypes
                    .Where(x => !x.Name.ToLower().Equals(requestSearchPattern))
                    .Where(x => x.Name.ToLower().StartsWith(requestSearchPattern))
                    .Take(requestLimit)
                    .ToListAsync(cancellationToken: ct);

                finalResult.AddRange(startsWith);
            }

            if (finalResult.Count < requestLimit)
            {
                requestLimit -= finalResult.Count;

                var contains = await tagsWithTypes
                    .Where(x => !x.Name.ToLower().Equals(requestSearchPattern))
                    .Where(x => !x.Name.ToLower().StartsWith(requestSearchPattern))
                    .Where(x => x.Name.ToLower().Contains(requestSearchPattern))
                    .Take(requestLimit)
                    .ToListAsync(cancellationToken: ct);

                finalResult.AddRange(contains);
            }
        }

        return finalResult.Select(x => x.ToModel()).ToArray();
    }

    public async Task Update(Tag tag)
    {
        var loadedTag = await _lilinDbContext.Tags.SingleAsync(x => x.Id == tag.Id);

        loadedTag.HasValue = tag.HasValue;
        loadedTag.SynonymsArray = tag.Synonyms;

        await _lilinDbContext.SaveChangesAsync();
    }

    public async Task Create(Tag tag)
    {
        var newEntity = new TagEntity
        {
            Id = Guid.NewGuid(),
            Name = tag.Name,
            HasValue = tag.HasValue,
            SynonymsArray = tag.Synonyms,
            TypeId = tag.Type.Id
        };

        await _lilinDbContext.Tags.AddAsync(newEntity);

        await _lilinDbContext.SaveChangesAsync();
    }

    public async Task UpdateTagsCounters()
    {
        var script =
            $"""
            UPDATE "{nameof(LilinDbContext.Tags)}" tags
            SET "{nameof(TagEntity.Count)}" = usages.count
            FROM
            (
                SELECT id, count(*) AS count
                FROM (
                    SELECT "{nameof(FileTagEntity.TagId)}" AS id, "{nameof(FileTagEntity.FileId)}" AS fileId
                    FROM "{nameof(LilinDbContext.FileTags)}"
                    GROUP BY id, fileId) as inn
                GROUP BY id
            ) usages
            WHERE tags."{nameof(TagEntity.Id)}" = usages.id
            """;

        await _lilinDbContext.Database.ExecuteSqlRawAsync(script);
    }
}
