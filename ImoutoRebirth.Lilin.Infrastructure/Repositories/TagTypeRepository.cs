﻿using ImoutoRebirth.Lilin.Core.Infrastructure;
using ImoutoRebirth.Lilin.Core.Models;
using ImoutoRebirth.Lilin.DataAccess;
using ImoutoRebirth.Lilin.DataAccess.Entities;
using ImoutoRebirth.Lilin.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace ImoutoRebirth.Lilin.Infrastructure.Repositories;

public class TagTypeRepository : ITagTypeRepository
{
    private readonly LilinDbContext _lilinDbContext;

    public TagTypeRepository(LilinDbContext lilinDbContext) => _lilinDbContext = lilinDbContext;

    public async Task<TagType?> Get(string name, CancellationToken ct) 
        => (await _lilinDbContext.TagTypes.SingleOrDefaultAsync(x => x.Name == name, cancellationToken: ct))?.ToModel();

    public async Task<TagType?> Get(Guid id, CancellationToken ct) 
        => (await _lilinDbContext.TagTypes.SingleOrDefaultAsync(x => x.Id == id, cancellationToken: ct))?.ToModel();

    public async Task<TagType> Create(string name)
    {
        var tagType = new TagTypeEntity {Id = Guid.NewGuid(), Name = name};
        await _lilinDbContext.TagTypes.AddAsync(tagType);
        await _lilinDbContext.SaveChangesAsync();
        return tagType.ToModel();
    }

    public async Task<IReadOnlyCollection<TagType>> GetAll(CancellationToken ct) 
        => await _lilinDbContext.TagTypes.Select(x => x.ToModel()).ToArrayAsync(cancellationToken: ct);
}
