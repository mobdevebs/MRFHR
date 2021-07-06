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
export interface IState{
    stateId:number;
    stateName:string;    
}

export interface IExperience{
    experienceId:number;
    experienceName:string;
    fromYear:number;
    toYear:number;
}
export interface IYears{
    yearsId:number;
    yearsName:string;
}
export interface IMonths{
    monthId:number;
    monthName:string;
}