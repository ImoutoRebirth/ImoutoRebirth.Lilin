﻿using ImoutoRebirth.Lilin.Core.Infrastructure;
using ImoutoRebirth.Lilin.Core.Models;
using ImoutoRebirth.Lilin.Core.Models.FileInfoAggregate;
using ImoutoRebirth.Lilin.DataAccess;
using ImoutoRebirth.Lilin.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace ImoutoRebirth.Lilin.Infrastructure.Repositories;

public class FileNoteRepository : IFileNoteRepository
{
    private readonly LilinDbContext _lilinDbContext;

    public FileNoteRepository(LilinDbContext lilinDbContext)
    {
        _lilinDbContext = lilinDbContext;
    }

    public async Task Add(FileNote fileNote)
    {
        await _lilinDbContext.Notes.AddAsync(fileNote.ToEntity());
        await _lilinDbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<FileNote>> GetForFile(Guid fileId, CancellationToken cancellationToken)
    {
        var results = await _lilinDbContext.Notes
            .Where(x => x.FileId == fileId)
            .ToArrayAsync();

        return results.Select(x => x.ToModel()).ToArray();
    }

    public async Task Update(Guid noteId, Note note)
    {
        var entity = await _lilinDbContext.Notes.FindAsync(noteId);

        if (entity == null)
            throw new Exception($"Note with id {noteId} wasn't found");

        entity.Label = note.Label;
        entity.Height = note.Height;
        entity.Width = note.Width;
        entity.PositionFromTop = note.PositionFromTop;
        entity.PositionFromLeft = note.PositionFromLeft;

        await _lilinDbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid noteId)
    {
        var note = await _lilinDbContext.Notes.FindAsync(noteId);

        if (note == null)
            throw new Exception($"Note with id {noteId} wasn't found");

        _lilinDbContext.Remove(note);

        await _lilinDbContext.SaveChangesAsync();
    }
}