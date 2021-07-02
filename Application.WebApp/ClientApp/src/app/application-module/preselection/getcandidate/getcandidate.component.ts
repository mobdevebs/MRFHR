import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { CandidateService } from '../../../services/preselection/candidate/candidate.service';
import { ICandidate,ICandidateDetail, ISearchCandidate } from '../../../interfaces/preselection/candidate.interface';

declare var jQuery: any;

@Component({
  selector: 'app-getcandidate',
  templateUrl: './getcandidate.component.html',
  styleUrls: ['./getcandidate.component.css']
})

export class GetcandidateComponent implements OnInit {
  //candidate
  candidate: ICandidateDetail[] = [];
  searchCandidate: ISearchCandidate =
    {
      candidateId: 1,
      isActive: true,
      search:'%'
    };
  iom: string;
  constructor(private candidateService: CandidateService) { }
  ngAfterViewInit() {
  }
  ngOnInit() {
    this.getCandidateDetails();
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
