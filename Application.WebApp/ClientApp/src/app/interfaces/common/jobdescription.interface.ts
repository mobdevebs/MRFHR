export interface IJobDescription
{
    jobDescriptionId:number;
    jobDescriptionName:string;
    verticalId:number;
    verticalName:string;
    isActive:boolean;
    createdBy:number;
}

export interface IJobDescriptionDetail {
    IsRestricted:number;
    Restricted:string;
    Vertical:number ;
    Position:number ;
    Department:number ;
    Function:number ;
    Location:number ;
    Grade:number ;      
    NoOfReportees: number;
    DesiredIndustries:number ;     
    Experience:number ;
    Age:number ;
    Course:number ;
    Stream: number;
    Language:number ;
    ReportsTo:string ;
    AnyOther:string;
    JobPurpose:string ;
    JobSummary: string;
    KPIs: string;
    Dimensions:string ;
    Knowledge: string;
    SkillsAndAbility: string;
    ExternalStakeHolders: string;
    InternalStakeHolders: string;
  }

export interface ISearchJobDescription
{
    jobDescriptionId:number;
    verticalId:number;
    isActive:boolean;
}