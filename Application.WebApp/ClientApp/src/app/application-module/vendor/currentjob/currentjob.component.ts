import { Component, OnInit } from '@angular/core';

import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ILocation, ISearchLocation } from '../../../interfaces/common/location.interface';
import { IVerticalFunction, ISearchFunction } from '../../../interfaces/common/function.interface';
import { ICurrentJob, ISearchCurrentJob } from '../../../interfaces/vendor/vendorjob.interface';
import { IJobType, ISearchJobType } from '../../../interfaces/common/jobtype.interface';
import { IJobDescription, ISearchJobDescription } from '../../../interfaces/common/jobdescription.interface';
import { IPositionVerticalDetail, ISearchPosition,IPositionGrade,ISearchPositionGrade } from '../../../interfaces/common/position.interface';
import { LocationService } from '../../../services/common/location/location.service';
import { FunctionService } from '../../../services/common/function/function.service';
import { VendorService } from '../../../services/vendor/vendor/vendor.service';
import { PositionService } from '../../../services/common/position/position.service';
import { VendorjobService } from 'src/app/services/vendor/vendorjob/vendorjob.service';
declare var jQuery: any;
@Component({
  selector: 'app-currentjob',
  templateUrl: './currentjob.component.html',
  styleUrls: ['./currentjob.component.css']
})
export class CurrentjobComponent implements OnInit {
  saveForm = new FormGroup({
    FunctionId: new FormControl(''),
    LocationId: new FormControl(''),
    PositionId: new FormControl('')
  });
  //location
  locations: ILocation[] = [];
  selectedLocation:ILocation;
  selectedLocationCode:string="";
  selectedLocationOffice:string="";
  searchLocation: ISearchLocation =
  {
    locationId: null,
    verticalId: null,
    locationCode: null,
    locationNo: null,
    isActive: true
  };
   //curr job
   currentJobs: ICurrentJob[] = [];
   selectedCurrentJob:ILocation;   
   searchCurrentJob: ISearchCurrentJob =
   {
     locationId: 0,
     positionId:0,
     functionId:0
   };
  locationId:number;
  //position
  positions:IPositionVerticalDetail[]=[];
  selectedPosition:IPositionVerticalDetail;
  searchPosition:ISearchPosition={
    verticalId:null,
    positionId:null,
    isActive:true
  }
  positionId;
  positionName:string;
 
  //function
  functions:IVerticalFunction[]=[];
  selectedFunction:IVerticalFunction;
  searchFunction:ISearchFunction={
    verticalId:null,
    functionId:null,
    isActive:true
  }
  functionId:number;
  functionName:string;
  
  constructor(
    private locationService: LocationService,
    private positionService:PositionService,
    private functionService:FunctionService,
    private currentJobService:VendorjobService
  ) {
    this.getAllLocation();
    this.getAllFunction();
    this.getAllPosition();
    this.getCurrentJobDetails();
  }
  getCurrentJobDetails()
  {
    this.currentJobs = [];
    this.currentJobService.getCurrentJob(this.searchCurrentJob).subscribe((result) => {
      if (result) {
        this.currentJobs = result;
        console.log(result);
      }
      else {
        this.currentJobs = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      setTimeout(() => {
        jQuery('.selectpicker').selectpicker('refresh');
      });
    });
  }
  //locations
  getAllLocation() {
    this.locations = [];
    this.locationService.getAllLocation(this.searchLocation).subscribe((result) => {
      if (result) {
        this.locations = result;
        console.log(result);
      }
      else {
        this.locations = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      setTimeout(() => {
        jQuery('.selectpicker').selectpicker('refresh');
      });
    });
  }

  onLocationChange(location:any){
    this.selectedLocationCode=this.selectedLocation.locationCode;
    this.selectedLocationOffice=this.selectedLocation.locationOffice;
  }

  //functions
  getAllFunction() {
    this.functions = [];
    this.searchFunction.verticalId=1;
    this.functionService.getAllVerticalFunction(this.searchFunction).subscribe((result) => {
      if (result) {
        this.functions = result;
        console.log(result);
      }
      else {
        this.functions = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      setTimeout(() => {
        jQuery('.selectpicker').selectpicker('refresh');
      });
    });
  }

  OnFilter()
  {
    this.currentJobs = [];
    this.currentJobService.getCurrentJob(this.saveForm.value).subscribe((result) => {
      if (result) {
        this.currentJobs = result;
        console.log(result);
      }
      else {
        this.currentJobs = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      setTimeout(() => {
        jQuery('.selectpicker').selectpicker('refresh');
      });
    });
  }
  //position
  getAllPosition() {
    this.positions = [];
    this.searchPosition.verticalId=1;
    this.positionService.getAllVerticalPosition(this.searchPosition).subscribe((result) => {
      if (result) {
        this.positions = result;
        console.log(result);
      }
      else {
        this.positions = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      setTimeout(() => {
        jQuery('.selectpicker').selectpicker('refresh');
      });
    });
  }
  ngOnInit() {
  }

}
