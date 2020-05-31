import { ITagResponse } from './tag-response';
import { MetadataSource } from './metadata-source';

export interface IFileTagResponse
{
    fileId: string;
    tag: ITagResponse;
    value: string;
    source: MetadataSource;
}
