import { TagSearchScope } from './tag-search-scope';

export interface ITagSearchEntryRequest
{
    tagId: string;
    value: string;
    tagSearchScope: TagSearchScope;
}
