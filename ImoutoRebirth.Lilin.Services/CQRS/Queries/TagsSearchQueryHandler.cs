﻿using ImoutoRebirth.Common.Cqrs.Abstract;
using ImoutoRebirth.Lilin.Core.Infrastructure;
using ImoutoRebirth.Lilin.Core.Models;

namespace ImoutoRebirth.Lilin.Services.CQRS.Queries;

public class TagsSearchQueryHandler : IQueryHandler<TagsSearchQuery, IReadOnlyCollection<Tag>>
{
    private readonly ITagRepository _tagRepository;

    public TagsSearchQueryHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public Task<IReadOnlyCollection<Tag>> Handle(TagsSearchQuery request, CancellationToken ct) 
        => _tagRepository.Search(request.SearchPattern, request.Limit, ct);
}
