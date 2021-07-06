import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { CandidateService } from '../../../services/preselection/candidate/candidate.service';
import { ICandidate,ICandidateDetail,ICandidateCMDStatus, ISearchCandidate } from '../../../interfaces/preselection/candidate.interface';
import { NotificationService } from '../../../sharedservices/notification.service';
import { ToastrService } from 'ngx-toastr';
declare var jQuery: any;

@Component({
  selector: 'app-candidatecmdapproval',
  templateUrl: './candidatecmdapproval.component.html',
  styleUrls: ['./candidatecmdapproval.component.css']
})
export class CandidatecmdapprovalComponent implements OnInit {
  @ViewChild('candidateResumeImport', { static: false }) candidateResumeImport: ElementRef;
 //candidate
 candidate: ICandidateDetail[] = [];
 candidateStatus: ICandidateCMDStatus;
 searchCandidate: ISearchCandidate =
   {
     candidateId: 4,
     isActive: true,
     search:'%'
   };
 iom: string;
 constructor(private candidateService: CandidateService, private toasterService: ToastrService,  private notificationService: NotificationService) { }
 ngAfterViewInit() {
 }
 ngOnInit() {
   this.getCandidateDetails();
 }
 formSubmit()
 {
  this.candidateStatus=({candidateId:1,
    cmdApprovalRequired:parseInt((<HTMLInputElement>document.getElementById("CMDApprovalRequired")).value),
    cmdApprovalStatus:Boolean((<HTMLInputElement>document.getElementById("CMDApprovalStatus")).value),
    cmdApprovalNo:String((<HTMLInputElement>document.getElementById("CMDApprovalNo")).value),
    cmdApprovalDocument:''});
 this.candidateService.saveCandidateCMDStatus(this.candidateStatus).subscribe((result) => {
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
