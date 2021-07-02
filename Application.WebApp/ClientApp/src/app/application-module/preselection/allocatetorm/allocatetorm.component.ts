import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ISearchRequisition, IRequisitionList } from '../../../interfaces/preselection/requisition.interface';
import { IUserDetail, ISearchUser } from '../../../interfaces/common/user';
import { ISalary, ISearchSalary } from '../../../interfaces/common/salary.interface';
import { ShareddataService } from '../../../sharedservices/shareddata.service';
import { RequisitionService } from '../../../services/preselection/requisition/requisition.service';
import { UserService } from '../../../services/common/user/user.service';
import { SalaryService } from '../../../services/common/salary/salary.service';
import { NotificationService } from '../../../sharedservices/notification.service';
import { ToastrService } from 'ngx-toastr';
declare var jQuery: any;

@Component({
  selector: 'app-allocatetorm',
  templateUrl: './allocatetorm.component.html',
  styleUrls: ['./allocatetorm.component.css']
})
export class AllocatetormComponent implements OnInit {
  saveForm: FormGroup;
  //requisition detail
  requisitionDetailHistoryId:number;
  requisitionLists: IRequisitionList[] = [];
  searchRequisition:ISearchRequisition={
    requisitionNo:null,
    requistionId:null,
    requisitionDetailHistoryId:null,
    locationId:null,
    verticalId:null,
    fromDate:null,
    toDate:null,
    iOMNo:null,
    requisitionApprovalStatus:null,
    requisitionProcessStatus:null,
    createdBy:null,
    approverAutoUserId:null
  }
  //rm user
  rmUser:IUserDetail[]=[];
  searchUser:ISearchUser={
    userId:null,
    userName:null,
    roleId:3,
    isActive:null
  };
  selectedUser:IUserDetail;
  //salary
  salaries:ISalary[]=[];
  searchSalary:ISearchSalary={
    salaryId:0,
    isActive:true
  }
  selectedSalary:ISalary;
  constructor(
    private fb: FormBuilder,
    private shareddataService:ShareddataService,
    private requisitionService:RequisitionService,
    private userService:UserService,
    private salaryService:SalaryService,
    private notificationService:NotificationService,
    private toasterService:ToastrService
  ) { 
    this.requisitionDetailHistoryId=this.shareddataService.getData();
    console.log(this.requisitionDetailHistoryId);
    this.getRequisitionDetail();
    this.createForm();
    
  }

  ngOnInit() {
    this.getRMUser();
    this.getAllSalary();
  }

  createForm() {
    this.saveForm = this.fb.group({
      requisitionDetailHistoryId:[this.requisitionDetailHistoryId],
      allocatedAutoUserId: ['',Validators.required],
      salaryId: ['',Validators.required],
      remarks: ['']
    });
  }

  getRequisitionDetail(){
    this.requisitionLists=[];
    this.searchRequisition.requisitionDetailHistoryId=this.requisitionDetailHistoryId;
    this.requisitionService.getAllRequisition(this.searchRequisition).subscribe((result) => {
      if (result) {
        console.log(result);
        this.requisitionLists = result;
        console.log(result);
      }
      else {
        this.requisitionLists = [];
      }
    }, error => {
      console.log(error);
    }, () => {
    });
  }

  getRMUser(){
    this.rmUser=[];
    this.userService.getAllUser(this.searchRequisition).subscribe((result) => {
      if (result) {
        console.log(result);
        this.rmUser = result;
      }
      else {
        this.rmUser = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      this.loadSelectPicker();
    });
  }

  getAllSalary(){
    this.salaries=[];
    this.salaryService.getAllSalary(this.searchSalary).subscribe((result) => {
      if (result) {
        console.log(result);
        this.salaries = result;
      }
      else {
        this.salaries = [];
      }
    }, error => {
      console.log(error);
    }, () => {
    });
  }

  loadSelectPicker() {
    setTimeout(() => {
      jQuery('.selectpicker').selectpicker({
        size: 6
      });
      jQuery('.selectpicker').selectpicker('refresh');
    });
  }

  formSubmit(){
    console.log(this.saveForm.value);
    this.toasterService.success('Hello world!', 'Toastr fun!', {
      timeOut: 3000,
    });
    //this.notificationService.showSuccess("Data shown successfully !!", "HDTuto.com")
    // this.requisitionService.allocateRequisitionToRM(this.saveForm.value).subscribe((result) => {
    //   if (result) {
    //     console.log(result);
    //   }
    //   else {
    //     this.rmUser = [];
    //   }
    // }, error => {
    //   console.log(error);
    // }, () => {
    //   this.loadSelectPicker();
    // });
    
  }

}
