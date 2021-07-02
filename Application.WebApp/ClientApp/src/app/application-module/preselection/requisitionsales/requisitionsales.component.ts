import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ILocation, ISearchLocation } from '../../../interfaces/common/location.interface';
import { IVerticalFunction, ISearchFunction } from '../../../interfaces/common/function.interface';
import { IFunctionDepartment, ISearchDepartment } from '../../../interfaces/common/department.interface';
import { IJobType, ISearchJobType } from '../../../interfaces/common/jobtype.interface';
import { IJobDescription, ISearchJobDescription } from '../../../interfaces/common/jobdescription.interface';
import { IPositionVerticalDetail, ISearchPosition, IPositionGrade, ISearchPositionGrade } from '../../../interfaces/common/position.interface';
import { IRequisitionDetailData, IRequisitionDetailDataArray } from '../../../interfaces/preselection/requisition.interface';
import { LocationService } from '../../../services/common/location/location.service';
import { FunctionService } from '../../../services/common/function/function.service';
import { DepartmentService } from '../../../services/common/department/department.service';
import { PositionService } from '../../../services/common/position/position.service';
import { JobtypeService } from '../../../services/common/jobtype/jobtype.service';
import { JobdescriptionService } from '../../../services/common/jobdescription/jobdescription.service';
import { RequisitionService } from '../../../services/preselection/requisition/requisition.service';
import { PersistanceService } from '../../../sharedservices/persitence.service';
//import * as $ from 'jquery';
declare var jQuery: any;

@Component({
  selector: 'app-requisitionsales',
  templateUrl: './requisitionsales.component.html',
  styleUrls: ['./requisitionsales.component.css']
})
export class RequisitionsalesComponent implements OnInit {
  @ViewChild('tDate', { static: false }) tDate: ElementRef;
  @ViewChild('managementFileImport', { static: false }) managementFileImport: ElementRef;
  saveform: FormGroup;
  showTable: boolean = false;
  //location
  locations: ILocation[] = [];
  selectedLocation: ILocation;
  selectedLocationCode: string = "";
  selectedLocationOffice: string = "";
  searchLocation: ISearchLocation =
    {
      locationId: null,
      verticalId: null,
      locationCode: null,
      locationNo: null,
      isActive: true
    };
  locationId: number;
  //position
  positions: IPositionVerticalDetail[] = [];
  selectedPosition: IPositionVerticalDetail;
  searchPosition: ISearchPosition = {
    verticalId: null,
    positionId: null,
    isActive: true
  }
  positionId;
  positionName: string;
  //grade
  grades: IPositionGrade[] = [];
  selectedGrade: IPositionGrade;
  searchGrade: ISearchPositionGrade = {
    verticalId: null,
    positionId: null,
    isActive: true
  }
  gradeId: number;
  gradeName: string;
  //function
  functions: IVerticalFunction[] = [];
  selectedFunction: IVerticalFunction;
  searchFunction: ISearchFunction = {
    verticalId: null,
    functionId: null,
    isActive: true
  }
  functionId: number;
  functionName: string;
  //department
  departments: IFunctionDepartment[] = [];
  selectedDepartment: IFunctionDepartment;
  searchDepartment: ISearchDepartment = {
    departmentId: null,
    functionId: null,
    verticalId: null,
    isActive: true
  }
  departmentId: number;
  departmentName: string;
  //jobtype
  jobtypes: IJobType[] = [];
  selectedJobType: IJobType;
  searchJobType: ISearchJobType = {
    jobTypeId: null,
    isActive: true
  }
  jobTypeId: number;
  jobTypeName: string;
  //jobdescription
  jobdescriptions: IJobDescription[] = [];
  selectedJobDescription: IJobDescription;
  searchJobDescription: ISearchJobDescription = {
    jobDescriptionId: null,
    verticalId: null,
    isActive: true
  }
  jobDescriptionId: number;
  jobDescriptionName;
  iom: string;
  iomNo: string;
  targetDate: string;
  approveCount: number;
  requestCount: number;
  holdCount: number;
  isAutoApproved: boolean = false;
  requistionDetailData: IRequisitionDetailData[] = [];
  requistionDetailDataArray: IRequisitionDetailDataArray[] = [];
  managementfileToUpload: File = null;
  createdBy:number;
  constructor(
    private locationService: LocationService,
    private positionService: PositionService,
    private functionService: FunctionService,
    private departmentService: DepartmentService,
    private jobTypeService: JobtypeService,
    private jobDescriptionService: JobdescriptionService,
    private requisitionService:RequisitionService,
    private fb: FormBuilder,
    private persistance:PersistanceService
  ) {
    this.createdBy=this.persistance.get('loggedinuser').autoUserId;
    this.getAllLocation();
    this.getAllFunction();
    this.getAllJobType();
    this.getAllJobDescription();
    this.getAllPosition();
  }

  ngAfterViewInit() {
    this.loadDatePicker();
  }

  loadDatePicker() {
    jQuery(".datepicker").parent(".input-group").datepicker({
      autoclose: true,
      format: "dd/mm/yyyy",
      todayHighlight: true
    });
  }

  ngOnInit() {

  }

  //locations
  getAllLocation() {
    this.locations = [];
    this.searchLocation.verticalId=3;
    this.locationService.getAllLocation(this.searchLocation).subscribe((result) => {
      if (result) {
        this.locations = result;
      }
      else {
        this.locations = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      this.loadSelectPicker();
    });
  }

  onLocationChange() {
    this.selectedLocationCode = this.selectedLocation.locationCode;
    this.selectedLocationOffice = this.selectedLocation.locationOffice;
  }

  //functions
  getAllFunction() {
    this.functions = [];
    this.searchFunction.verticalId = 3;
    this.functionService.getAllVerticalFunction(this.searchFunction).subscribe((result) => {
      if (result) {
        this.functions = result;
      }
      else {
        this.functions = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      this.loadSelectPicker();
    });
  }

  onFunctionChange() {
    this.functionId = this.selectedFunction.functionId;
    this.getAllDepartment();
  }

  //department
  getAllDepartment() {
    this.departments = [];
    this.searchDepartment.verticalId = 3;
    this.searchDepartment.functionId = this.functionId;
    this.departmentService.getAllFunctionDepartment(this.searchDepartment).subscribe((result) => {
      if (result) {
        this.departments = result;
        console.log(this.departments);
      }
      else {
        this.departments = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      this.loadSelectPicker();
    });
  }

  //position
  getAllPosition() {
    this.positions = [];
    this.searchPosition.verticalId = 3;
    this.positionService.getAllVerticalPosition(this.searchPosition).subscribe((result) => {
      if (result) {
        this.positions = result;
      }
      else {
        this.positions = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      //this.loadSelectPicker();
    });
  }

  onPositionChange() {
    this.positionId = this.selectedPosition.positionId;
    this.getAllGrade();
  }

  //grade
  getAllGrade() {
    this.grades = [];
    this.searchGrade.verticalId = 3;
    this.searchGrade.positionId = this.positionId;
    this.positionService.getAllPositionGrade(this.searchGrade).subscribe((result) => {
      if (result) {
        this.grades = result;
      }
      else {
        this.grades = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      this.loadSelectPicker();
    });
  }

  //job type
  getAllJobType() {
    this.jobtypes = [];
    this.jobTypeService.getAllJobType(this.searchJobType).subscribe((result) => {
      if (result) {
        this.jobtypes = result;
      }
      else {
        this.jobtypes = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      //this.loadSelectPicker();
    });
  }

  //job description
  getAllJobDescription() {
    this.jobdescriptions = [];
    this.searchJobDescription.verticalId = 3;
    this.jobDescriptionService.getAllJobDescription(this.searchJobDescription).subscribe((result) => {
      if (result) {
        this.jobdescriptions = result;
      }
      else {
        this.jobdescriptions = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      //this.loadSelectPicker();
    });
  }

  startRequisition() {
    var flag = 0;
    if (this.selectedLocation == undefined) {
      flag = 1;
    }
    else {

    }
    if (this.iom == undefined) {
      flag = 1;
    }
    else {

    }
    if (flag == 0) {
      this.requistionDetailData = [];
      this.showTable = true;
      this.iomNo = this.iom;
      setTimeout(() => {
        jQuery('.selectpicker').selectpicker({
          size: 4
        });
        jQuery('.selectpicker').selectpicker('refresh');
        this.loadDatePicker();
        jQuery('.custom-file input').change(function (e) {
          var files = [];
          for (var i = 0; i < jQuery(this)[0].files.length; i++) {
              files.push(jQuery(this)[0].files[i].name);
          }
          jQuery(this).next('.custom-file-label').html(files.join(', '));
      });

      });
    }
    else {
      this.showTable = false;
    }
  }

  addRow() {
    var flag = 0;
    if (this.selectedJobDescription == undefined) {
      flag = 1;
    }
    else {

    }
    if (this.tDate.nativeElement.value == undefined || this.tDate.nativeElement.value == "") {
      flag = 1;
    }
    else {

    }
    if (this.selectedJobType == undefined) {
      flag = 1;
    }
    else {

    }
    if (this.approveCount == undefined) {
      flag = 1;
    }
    else {

    }
    if (this.requestCount == undefined) {
      flag = 1;
    }
    else {

    }
    if (this.selectedGrade == undefined) {
      flag = 1;
    }
    else {

    }
    if (this.selectedPosition == undefined) {
      flag = 1;
    }
    else {

    }
    if (this.selectedDepartment == undefined) {
      flag = 1;
    }
    else {

    }
    if (this.selectedFunction == undefined) {
      flag = 1;
    }
    else {

    }
    if (flag == 0) {
      this.requistionDetailData.push(
        {
          autoId: this.requistionDetailData.length + 1,
          iomNo: this.iomNo,
          functionId: this.selectedFunction.functionId,
          departmentId: this.selectedDepartment.departmentId,
          positionId: this.selectedPosition.positionId,
          gradeId: this.selectedGrade.gradeId,
          jobTypeId: this.selectedJobType.jobTypeId,
          jobDescriptionId: this.selectedJobDescription.jobDescriptionId,
          targetDate: this.tDate.nativeElement.value,
          approveCount: this.approveCount,
          requestCount: this.requestCount,
          holdCount: (this.approveCount - this.requestCount),
          isAutoApproved: (this.approveCount - this.requestCount)>0?false:true
        });

      this.requistionDetailDataArray.push({
        autoId: this.requistionDetailData.length + 1,
        iomNo: this.iomNo,
        functionId: this.selectedFunction.functionId,
        functionName: this.selectedFunction.functionName,
        departmentId: this.selectedDepartment.departmentId,
        departmentName: this.selectedDepartment.departmentName,
        positionId: this.selectedPosition.positionId,
        positionName: this.selectedPosition.positionName,
        gradeId: this.selectedGrade.gradeId,
        gradeName: this.selectedGrade.gradeName,
        jobTypeId: this.selectedJobType.jobTypeId,
        jobTypeName: this.selectedJobType.jobTypeName,
        jobDescriptionId: this.selectedJobDescription.jobDescriptionId,
        jobDescriptionName: this.selectedJobDescription.jobDescriptionName,
        targetDate: this.tDate.nativeElement.value,
        approveCount: this.approveCount,
        requestCount: this.requestCount,
        holdCount: (this.approveCount - this.requestCount),
        isAutoApproved: (this.approveCount - this.requestCount)>0?false:true
      });
      this.clearForm();
    }
    else {

    }
  }

  loadSelectPicker() {
    setTimeout(() => {
      jQuery('.selectpicker').selectpicker({
        size: 6
      });
      jQuery('.selectpicker').selectpicker('refresh');
    });
  }

  clearForm() {
    setTimeout(() => {
      jQuery('.selectpicker').val('').trigger('change');
      jQuery('.selectpicker').not(".no-remove").find('option').remove();
      jQuery('.selectpicker').selectpicker('refresh');
      jQuery(".datepicker").parent(".input-group").datepicker('setDate', null);
      this.loadDatePicker();
    });
    this.approveCount = null;
    this.requestCount = null;
    this.holdCount = null;
  }

  onFileChange(files: FileList) {
    this.managementFileImport.nativeElement.innerText = Array.from(files)
      .map(f => f.name)
      .join(', ');
    this.managementfileToUpload = files.item(0);
    console.log(this.managementfileToUpload);
  }

  formSubmit(){
    const formData = new FormData();
    formData.append("VerticalId", "3");
    formData.append("LocationId", this.selectedLocation.locationId.toString());
    formData.append("IOMNo", this.iom.toString());
    formData.append("RequisitionData",  JSON.stringify(this.requistionDetailData));
    formData.append("ManagementApprovalFile",this.managementfileToUpload);
    formData.append("CreatedBy", this.createdBy.toString());
    console.log(formData);
    this.requisitionService.generateRequisition(formData).subscribe((result) => {
      console.log(result);
    }, error => {
      console.log(error);
    });
  }


}