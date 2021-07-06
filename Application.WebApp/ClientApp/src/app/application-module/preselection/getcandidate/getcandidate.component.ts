import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { CandidateService } from '../../../services/preselection/candidate/candidate.service';
import { ICandidate,ICandidateDetail, ICandidateStatus, ISearchCandidate } from '../../../interfaces/preselection/candidate.interface';
import { PersistanceService } from '../../../sharedservices/persitence.service';
import { NotificationService } from '../../../sharedservices/notification.service';
import { ToastrService } from 'ngx-toastr';
declare var jQuery: any;

@Component({
  selector: 'app-getcandidate',
  templateUrl: './getcandidate.component.html',
  styleUrls: ['./getcandidate.component.css']
})

export class GetcandidateComponent implements OnInit {
  createdBy:number;
  //candidate
  candidate: ICandidateDetail[] = [];
  candidateStatus:ICandidateStatus;
  searchCandidate: ISearchCandidate =
    {
      candidateId: 1,
      isActive: true,
      search:''
    };
  iom: string;
  constructor(private candidateService: CandidateService,private notificationService:NotificationService, private persistance:PersistanceService) { }
  ngAfterViewInit() {
  }
  ngOnInit() {
    this.createdBy=this.persistance.get('loggedinuser').autoUserId;
    this.getCandidateDetails();
  }
  
  formSubmit(){

     this.candidateStatus=({candidateId:1,
      remarks:(<HTMLInputElement>document.getElementById("Remarks")).value,
      statusId:( <HTMLInputElement> document.getElementById("rdbHiringManager")).checked==true?1:( (<HTMLInputElement> document.getElementById("rdbShortlist")).checked==true?2:3),
      createdBy:this.createdBy,
      requisitionId:1});
   this.candidateService.saveCandidateStatus(this.candidateStatus).subscribe((result) => {
       console.log(result);this.notificationService.showSuccess(result.msg, "Add Candidate");
       console.log(result);
     }, error => {
       // display form values on success
         this.notificationService.showError("Something went wrong.. Try again later..", "")        
       console.log(error);
     
     });
  }
  getCandidateDetails() {
    //locations
    this.candidate = [];
    this.candidateService.getCandidateDetails(this.searchCandidate).subscribe((result) => {
      if (result) {
        this.candidate = result;
        console.log(result);
      }
      else {
        this.candidate = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      setTimeout(() => {
        jQuery('.selectpicker').selectpicker('refresh');
      });
    });
  }
}
