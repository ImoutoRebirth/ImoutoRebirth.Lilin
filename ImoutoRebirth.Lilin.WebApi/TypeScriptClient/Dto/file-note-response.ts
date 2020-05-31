import { INoteResponse } from './note-response';
import { MetadataSource } from './metadata-source';

export interface IFileNoteResponse
{
    fileId: string;
    note: INoteResponse;
    source: MetadataSource;
    sourceId: number;
}
