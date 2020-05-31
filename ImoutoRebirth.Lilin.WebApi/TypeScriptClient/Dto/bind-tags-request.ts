import { IFileTagRequest } from './file-tag-request';
import { SameTagHandleStrategy } from './same-tag-handle-strategy';

export interface IBindTagsRequest
{
    fileTags: IFileTagRequest[];
    sameTagHandleStrategy: SameTagHandleStrategy;
}
