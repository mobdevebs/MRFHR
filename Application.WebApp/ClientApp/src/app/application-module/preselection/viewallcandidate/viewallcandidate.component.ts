import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { CandidateService } from '../../../services/preselection/candidate/candidate.service';
import { ICandidate,ICandidateDetail, ISearchCandidate } from '../../../interfaces/preselection/candidate.interface';
import { Router } from '@angular/router';
declare var jQuery: any;

@Component({
  selector: 'app-viewallcandidate',
  templateUrl: './viewallcandidate.component.html',
  styleUrls: ['./viewallcandidate.component.css']
})
export class ViewallcandidateComponent implements OnInit {
  saveform: FormGroup;
  //candidate
  candidate: ICandidateDetail[] = [];
  searchCandidate: ISearchCandidate =
    {
      candidateId: 0,
      isActive: true,
      search:''
    };
  iom: string;
  constructor(private candidateService: CandidateService,private router: Router) { }
  ngAfterViewInit() {
  }
  ngOnInit() {
    this.getCandidateDetails();
  }  
  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
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
