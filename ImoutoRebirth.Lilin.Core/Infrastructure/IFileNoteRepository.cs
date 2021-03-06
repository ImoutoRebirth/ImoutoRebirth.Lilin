﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImoutoRebirth.Lilin.Core.Models;
using ImoutoRebirth.Lilin.Core.Models.FileInfoAggregate;

namespace ImoutoRebirth.Lilin.Core.Infrastructure
{
    public interface IFileNoteRepository
    {
        Task Add(FileNote fileNote);

        Task<IReadOnlyCollection<FileNote>> GetForFile(Guid fileId);

        Task Update(Guid noteId, Note note);

        Task Delete(Guid noteId);
    }
}