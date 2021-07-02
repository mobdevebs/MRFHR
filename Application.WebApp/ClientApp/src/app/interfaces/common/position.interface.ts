export interface IPositionVerticalDetail
{
    positionId:number;
    positionName:string;
    verticalIds:string;
    verticalNames:string;
    isActive:boolean;
}

export interface ISearchPosition
{
    verticalId:number;
    positionId:number;
    isActive:boolean;
}

export interface IPositionGrade
{
    positionId:number;
    verticalId:string;
    gradeName:string;
    gradeId:number;
    isActive:boolean;
}

export interface ISearchPositionGrade
{
    verticalId:number;
    positionId:number;
    isActive:boolean;
}