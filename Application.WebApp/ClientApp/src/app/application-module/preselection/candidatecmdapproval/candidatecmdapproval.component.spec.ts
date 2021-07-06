import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidatecmdapprovalComponent } from './candidatecmdapproval.component';

describe('CandidatecmdapprovalComponent', () => {
  let component: CandidatecmdapprovalComponent;
  let fixture: ComponentFixture<CandidatecmdapprovalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CandidatecmdapprovalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CandidatecmdapprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
