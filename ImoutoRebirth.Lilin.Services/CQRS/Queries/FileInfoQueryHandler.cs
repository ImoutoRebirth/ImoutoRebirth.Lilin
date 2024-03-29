﻿using ImoutoRebirth.Common.Cqrs.Abstract;
using ImoutoRebirth.Lilin.Core.Infrastructure;
using ImoutoRebirth.Lilin.Core.Models.FileInfoAggregate;

namespace ImoutoRebirth.Lilin.Services.CQRS.Queries;

public class FileInfoQueryHandler : IQueryHandler<FileInfoQuery, FileInfo>
{
    private readonly IFileTagRepository _fileTagRepository;
    private readonly IFileNoteRepository _fileNoteRepository;

    public FileInfoQueryHandler(IFileTagRepository fileTagRepository, IFileNoteRepository fileNoteRepository)
    {
        _fileTagRepository = fileTagRepository;
        _fileNoteRepository = fileNoteRepository;
    }

    public async Task<FileInfo> Handle(FileInfoQuery request, CancellationToken ct)
    {
        var tags = await _fileTagRepository.GetForFile(request.FileId, ct);
        var notes = await _fileNoteRepository.GetForFile(request.FileId, ct);

        return new FileInfo(tags, notes, request.FileId);
    }
}
