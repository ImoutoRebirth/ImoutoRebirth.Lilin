import { MetadataSource } from './metadata-source';

export interface IFileTagRequest
{
    tagId: string;
    fileId: string;
    source: MetadataSource;
    value: string;
}
