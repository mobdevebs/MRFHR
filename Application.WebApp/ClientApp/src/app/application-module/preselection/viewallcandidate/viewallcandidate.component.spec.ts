import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewallcandidateComponent } from './viewallcandidate.component';

describe('ViewallcandidateComponent', () => {
  let component: ViewallcandidateComponent;
  let fixture: ComponentFixture<ViewallcandidateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewallcandidateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewallcandidateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
