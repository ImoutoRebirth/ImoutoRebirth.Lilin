import { RelativeType } from './relative-type';
import { IFileInfoResponse } from './file-info-response';

export interface IRelativeResponse
{
    relativesType: RelativeType;
    fileInfo: IFileInfoResponse;
}
