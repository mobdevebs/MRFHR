export interface IRequisitionDetailData{
    autoId:number;
    iomNo:string;
    functionId:number;
    departmentId:number;
    positionId:number;
    gradeId:number;
    jobTypeId:number;
    jobDescriptionId:number;
    targetDate:string;
    approveCount:number;
    requestCount:number;
    holdCount:number;
    isAutoApproved:boolean;
}

export interface IRequisitionDetailDataArray{
    autoId:number;
    iomNo:string;
    functionId:number;
    functionName:string;
    departmentId:number;
    departmentName:string;
    positionId:number;
    positionName:string;
    gradeId:number;
    gradeName:string;
    jobTypeId:number;
    jobTypeName:string;
    jobDescriptionId:number;
    jobDescriptionName:string;
    targetDate:string;
    approveCount:number;
    requestCount:number;
    holdCount:number;
    isAutoApproved:boolean;
}

export interface ISearchRequisition{
    requisitionNo:string;
    requistionId:number;
    requisitionDetailHistoryId:number;
    locationId:number;
    verticalId:number;
    fromDate:string;
    toDate:string;
    iOMNo:string;
    requisitionApprovalStatus:number;
    requisitionProcessStatus:number;
    createdBy:number;
    approverAutoUserId:number;
}

export interface IRequisitionList{
    requisitionApprovalId:number;
    requisitionDetailHistoryId:number;
    requisitionDetailId:number;
    requisitionId:number;
    requisitionNo:string;
    locationId:number;
    locationNo:string;
    functionId:number;
    functionName:string;
    departmentId:number;
    departmentName:string;
    positionId:number;
    positionName:string;
    gradeId:number;
    gradeName:string;
    jobTypeId:number;
    jobTypeName:string;
    jobDescriptionId:number;
    jobDescriptionName:string;
    createdByAutoUserId:number;
    createdByUserName:string;
    createdByEmailId:string;
    createdOn:string;
    targetDate:string;
    approverAutoUserId:number;
    approverUserName:string;
    approverEmailId:string;
    approvedOn:string;
    approveCount:number;
    requestCount:number;
    holdCount:number;
    requisitionApprovalStatusId:number;
    approvalStatus:string;
    approvalStatusIcon:string;
    requisitionProcessStatusId:number;
    processStatus:string;
    processStatusIcon:string;
}

export interface IRequsitionSourceChannelFeature{
    SourceChannelId:number;
    JobDescriptionFeatureId:number;
    Notes:string;
}

export interface IRequisitionSourceFormData{
    RequisitionDetailHistoryId:number;
    VendorIds:string;
    SourceChannelFeature:IRequsitionSourceChannelFeature[];
    CreatedBy:number;
}
