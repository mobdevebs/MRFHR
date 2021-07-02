export interface ICurrentJob
{
    jobDescriptonId :number;
    stateName :string;
    createdOn  :string;
    isSubmitted :number;
    isNew :number;
    jobPurpose :string;
    jobSummary :string;
    jobType :string;
    range :string;
}
export interface ISearchCurrentJob
{
    locationId:number;
    functionId:number;
    positionId:number;
}