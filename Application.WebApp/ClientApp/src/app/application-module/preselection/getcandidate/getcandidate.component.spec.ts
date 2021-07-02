import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetcandidateComponent } from './getcandidate.component';

describe('GetcandidateComponent', () => {
  let component: GetcandidateComponent;
  let fixture: ComponentFixture<GetcandidateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetcandidateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetcandidateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
