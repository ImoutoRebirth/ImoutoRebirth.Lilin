﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImoutoRebirth.Lilin.Core.Models;

namespace ImoutoRebirth.Lilin.Core.Infrastructure
{
    public interface ITagRepository
    {
        Task<Tag?> Get(string name, Guid typeId);

        Task<IReadOnlyCollection<Tag>> Search(string? requestSearchPattern, int requestLimit);
        
        Task Update(Tag tag);

        Task Create(Tag tag);
    }
}