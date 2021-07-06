// import { Interface } from "readline";

export interface ICandidate {
    candidateId: number;
    prefixId: number;
    prefix: string;
    fullName: string
    genderId: number;
    genderName: string;
    age: number;
    dOB: string;
    emailId: string;
    contactNo: string;
    aadharNo: string;
    motherTongueId: number;
    motherTongue: string;
    laguageIds: string;
    languages: string;
    qualificationId: number;
    qualification: string;
    courseId: number;
    course: string;
    stream: string;
    streamId: number;
    marksPercentage: any;
    completionYear: number;
    qualificationTypeId: number;
    qualificationType: string;
    experienceYear: number;
    experienceMonth: number;
    currentCTC: any;
    currentEmployer: string;
    currentDesignation: string;
    domainId: number;
    domain: string;
    subDomainId: number;
    subDomain: string;
    stateId: number;
    state: string;
    previousApplied: boolean;
    relativeStatus: boolean;
    relativeName: string;
    relativeContactNo: string;
    parentRelationshipId: number;
    childRelationshipId: number;
    relationshipNotes: string;
    cmdApprovalRequired: number;
    cmdApprovalStatus: boolean;
    cmdApprovalNo: string;
    cmdApprovalDocument: string;
    resume: string;
    isemployee: boolean;
    createdBy: number;
    status: string;
}
export interface ISearchCandidate {
    candidateId: number;
    isActive: boolean;
    search:string;
}

export interface ICandidateCMDStatus {
    candidateId:number;
    cmdApprovalRequired:number;
    cmdApprovalStatus:boolean;
    cmdApprovalNo:string;
    cmdApprovalDocument:string;
}
export interface ICandidateDetail {
    candidateId: number;
    prefix: string;
    fullName: string
    genderName: string;
    age: number;
    dOB: string;
    emailId: string;
    contactNo: string;
    aadharNo: string;
    motherTongue: string;
    languages: string;
    qualification: string;
    course: string;
    stream: string;
    marksPercentage: any;
    completionYear: number;
    qualificationType: string;
    experienceYear: number;
    experienceMonth: number;
    currentCTC: any;
    currentEmployer: string;
    currentDesignation: string;
    domain: string;
    subDomain: string;
    stateId: number;
    state: string;
    previousApplied: boolean;
    relativeStatus: boolean;
    relativeName: string;
    relativeContactNo: string;
    parentRelationshipId: number;
    childRelationshipId: number;
    relationshipNotes: string;
    cmdApprovalRequired: number;
    cmdApprovalStatus: boolean;
    cmdApprovalNo: string;
    cmdApprovalDocument: string;
    resume: string;
    isemployee: boolean;
    status: string;
    sourceChannelName: string;
    createdBy: string;
}

export interface ICandidateStatus
{
    requisitionId :number;
    candidateId :number;
    statusId :number;
    createdBy :number;
    remarks :string;
}
