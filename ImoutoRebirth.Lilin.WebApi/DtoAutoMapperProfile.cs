﻿using AutoMapper;
using ImoutoRebirth.Lilin.Core.Models;
using ImoutoRebirth.Lilin.Core.Models.FileInfoAggregate;
using ImoutoRebirth.Lilin.Services.CQRS.Commands;
using ImoutoRebirth.Lilin.Services.CQRS.Queries;
using ImoutoRebirth.Lilin.WebApi.Requests;
using ImoutoRebirth.Lilin.WebApi.Responses;

namespace ImoutoRebirth.Lilin.WebApi;

public class DtoAutoMapperProfile : Profile
{
    public DtoAutoMapperProfile()
    {
        CreateMapFromModelToResponses();
        CreateMapFromRequestsToQueries();
    }

    private void CreateMapFromRequestsToQueries()
    {
        CreateMap<TagCreateRequest, CreateTagCommand>();
        CreateMap<TagSearchEntryRequest, TagSearchEntry>();

        CreateMap<FilesSearchRequest, FilesSearchQuery>()
            .ForCtorParam("offset", o => o.MapFrom(x => x.Skip ?? 0))
            .ForCtorParam("limit", o => o.MapFrom(x => x.Count));
        CreateMap<FilesSearchRequest, FilesSearchQueryCount>();
        CreateMap<FilesFilterRequest, FilesFilterQuery>();

        CreateMap<BindTagsRequest, BindTagsCommand>();
        CreateMap<UnbindTagRequest, UnbindTagCommand>();

        CreateMap<FileTagRequest, FileTagInfo>();
    }

    private void CreateMapFromModelToResponses()
    {
        CreateMap<FileInfo, FileInfoResponse>();
        CreateMap<FileTag, FileTagResponse>();
        CreateMap<FileNote, FileNoteResponse>();
        CreateMap<Note, NoteResponse>();
        CreateMap<Tag, TagResponse>();
        CreateMap<TagType, TagTypeResponse>();
        CreateMap<RelativeInfo, RelativeResponse>();
        CreateMap<RelativeShortInfo, RelativeShortResponse>();
    }
}
