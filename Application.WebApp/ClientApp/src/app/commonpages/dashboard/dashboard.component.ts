import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ILocation,ISearchLocation } from '../../interfaces/common/location.interface';
import { LocationService } from '../../services/common/location/location.service';
import * as $ from 'jquery';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  locations:ILocation[]=[];
  searchLocation: ISearchLocation = 
  { 
    locationId: null, 
    verticalId: null, 
    locationCode:null,
    locationNo:null,
    isActive: true 
  };
  constructor(
    private locationService: LocationService,
    private fb: FormBuilder
    ) { 
      this.createForm();
    }

  ngOnInit() {
    this.getAllLocation();
  }

  createForm() {
    
  }

  getAllLocation() {
    this.locations=[];
    // this.locationService.getAllLocation(this.searchLocation).subscribe((result) => {
    //   if (result) {
    //     this.locations = result;
    //     console.log(result);
    //   }
    //   else {
    //     this.locations = [];
    //   }
    // })
  }

}
