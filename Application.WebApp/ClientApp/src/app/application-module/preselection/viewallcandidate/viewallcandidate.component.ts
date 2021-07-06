import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { CandidateService } from '../../../services/preselection/candidate/candidate.service';
import { ICandidate, ICandidateDetail, ICandidateStatus, ISearchCandidate } from '../../../interfaces/preselection/candidate.interface';
import { Router } from '@angular/router';
import { NotificationService } from '../../../sharedservices/notification.service';
import { PersistanceService } from '../../../sharedservices/persitence.service';
import { ToastrService } from 'ngx-toastr';
declare var jQuery: any;
@Component({
  selector: 'app-viewallcandidate',
  templateUrl: './viewallcandidate.component.html',
  styleUrls: ['./viewallcandidate.component.css']
})
export class ViewallcandidateComponent implements OnInit {
  saveform: FormGroup;
  createdBy: number;
  candidateId: number;
  candidateStatus: ICandidateStatus;
  candidatesStatus: ICandidateStatus[] = [];
  //candidate
  candidate: ICandidateDetail[] = [];
  searchCandidate: ISearchCandidate =
    {
      candidateId: 0,
      isActive: true,
      search: ''
    };
  iom: string;
  constructor(private candidateService: CandidateService, private router: Router, private notificationService: NotificationService, private persistance: PersistanceService) { this.createdBy = this.persistance.get('loggedinuser').autoUserId; }
  ngAfterViewInit() {
  }
  ngOnInit() {
    this.openNav();
    this.closeNav();
    this.getCandidateDetails();
  }
  openNav() {
    document.getElementById("mySidenav").style.width = "300px";
    document.getElementById("main").style.marginRight = "300px";
  }

  closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("main").style.marginRight = "0";
  }
  Action(e) {

    var dothis = this;
    var i = 1;
    //dothis.candidatesStatus = [];
    jQuery("#dtCandidateList").find("tr").each(function () {
      if (jQuery(this).find("input[type=checkbox]").prop("checked") == true) {
        dothis.candidateStatus = ({
          candidateId: parseInt(jQuery(this).find("input[type=checkbox]").prop("id")),
          remarks: '',
          statusId: parseInt(e),
          createdBy: this.createdBy,
          requisitionId: 1
        });
        //save
        dothis.candidateService.saveCandidateStatus(dothis.candidateStatus).subscribe((result) => {
          console.log(result);
        }, error => {
          // display form values on success
          dothis.notificationService.showError("Something went wrong.. Try again later..", "")
          console.log(error);
        });
        i++;
      }
      dothis.candidatesStatus.push(this.candidateStatus);
    });
    if (i > 0)
      this.notificationService.showSuccess("Candidate status saved successfully", (e == 1 ? "Send To Hiring Manager" : (e == 2 ? "Shortlist Candidate" : "Reject Candidate")));
  }

  selectAll(event) {
    jQuery('#dtCandidateList tr').each(function () {
      jQuery(this).find("input[type=checkbox]").attr("checked", event.target.checked);
    });
  }
  select(event) {
    jQuery(this).find("input[type=checkbox]").attr("checked", event.target.checked);
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
