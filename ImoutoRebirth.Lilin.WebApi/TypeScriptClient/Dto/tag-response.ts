import { ITagTypeResponse } from './tag-type-response';

export interface ITagResponse
{
    id: string;
    type: ITagTypeResponse;
    name: string;
    hasValue: boolean;
    synonyms: string[];
    count: number;
}
