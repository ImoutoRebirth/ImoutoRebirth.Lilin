import { IFileTagResponse } from './file-tag-response';
import { IFileNoteResponse } from './file-note-response';

export interface IFileInfoResponse
{
    tags: IFileTagResponse[];
    notes: IFileNoteResponse[];
}
