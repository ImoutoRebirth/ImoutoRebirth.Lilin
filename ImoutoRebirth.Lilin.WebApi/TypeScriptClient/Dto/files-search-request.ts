import { ITagSearchEntryRequest } from './tag-search-entry-request';

export interface IFilesSearchRequest
{
    tagSearchEntries: ITagSearchEntryRequest[];
    count: number;
    skip: number;
}
