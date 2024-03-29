﻿using ImoutoRebirth.Common;

namespace ImoutoRebirth.Lilin.Core.Models.FileInfoAggregate;

public class MetadataUpdateData
{
    public Guid FileId { get; }

    public IReadOnlyCollection<FileTag> Tags { get; }

    public IReadOnlyCollection<FileNote> Notes { get; }

    public MetadataSource MetadataSource { get; }

    public MetadataUpdateData(
        Guid fileId,
        IReadOnlyCollection<FileTag> tags,
        IReadOnlyCollection<FileNote> notes,
        MetadataSource metadataSource)
    {
        ArgumentValidator.NotNull(() => tags, () => notes);
        ArgumentValidator.Requires(() => tags.All(t => t.FileId == fileId), nameof(tags));
        ArgumentValidator.Requires(() => notes.All(n => n.FileId == fileId), nameof(notes));
        ArgumentValidator.Requires(
            () => tags.All(t => t.Source == metadataSource)
                  && notes.All(n => n.Source == metadataSource),
            nameof(metadataSource));

        FileId = fileId;
        Tags = tags;
        Notes = notes;
        MetadataSource = metadataSource;
    }
}