export interface IVendor{
    vendorId:number;
    vendorName:string;
    emailId:string;
    alternateEmailId:string;
    contactNo:string;
    alternateContactNo:string;
    website:string;
    city:string;
    street:string;
    zipCode:string;
    stateId:number;
    statename:string;
    termsOfService:string;
    isActive:boolean;
}

export interface ISearchVendor{
    vendorId:number;
    isActive:boolean; 
}