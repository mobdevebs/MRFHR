export interface IStatus{
    statusId:number;
    statusName:string;
    statusTypeId:number;
    statusTypeName:string;
    statusIcon:string;
}
export interface IPrefix
{
    prefixId:number;
    prefixName:string;
    isActive:boolean;
}
export interface ISearchPrefix
{
    prefixId:number;
    isActive:boolean;
}

export interface IGender
{
    genderId:number;
    genderName:string;
    isActive:boolean;
}

export interface ISearchGender
{
    genderId:number;
    isActive:boolean;
}

export interface IAge{
    ageId:number;
    ageName:string;
    fromAge:number;
    toAge:number;
}

export interface IExperience{
    experienceId:number;
    experienceName:string;
    fromYear:number;
    toYear:number;
}