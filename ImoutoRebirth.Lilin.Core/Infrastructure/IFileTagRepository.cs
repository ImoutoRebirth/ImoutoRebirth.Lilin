﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImoutoRebirth.Lilin.Core.Models;
using ImoutoRebirth.Lilin.Core.Models.FileInfoAggregate;

namespace ImoutoRebirth.Lilin.Core.Infrastructure
{
    public interface IFileTagRepository
    {
        Task<Guid[]> SearchFiles(
            IReadOnlyCollection<TagSearchEntry> tagSearchEntries,
            int? limit = 100,
            int offset = 0);

        Task<int> SearchFilesCount(IReadOnlyCollection<TagSearchEntry> tagSearchEntries);

        Task<IReadOnlyCollection<FileTag>> GetForFile(Guid fileId);
        
        Task Add(FileTag fileTag);
        
        Task AddBatch(IReadOnlyCollection<FileTagInfo> fileTags);

        Task Delete(FileTag fileTag);
    }
}