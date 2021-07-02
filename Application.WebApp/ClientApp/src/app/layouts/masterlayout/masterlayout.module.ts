import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AuthenticationGuard } from '../../auth/authentication.guard';
import { AuthguardserviceService } from '../../auth/authguardservice.service';
import { ShareddataService } from '../../sharedservices/shareddata.service';
import { PersistanceService } from '../../sharedservices/persitence.service';
import { MasterlayoutComponent } from '../masterlayout/masterlayout.component';
import { NavMenuComponent } from '../../nav-menu/nav-menu.component'
import { LoginlayoutComponent } from '../loginlayout/loginlayout.component';
import { DashboardComponent } from '../../commonpages/dashboard/dashboard.component';
import { LoginComponent } from '../../commonpages/login/login.component';
import { RequisitionplantComponent } from '../../application-module/preselection/requisitionplant/requisitionplant.component';
import { RequisitioncorporateComponent } from '../../application-module/preselection/requisitioncorporate/requisitioncorporate.component';
import { RequisitionsalesComponent } from '../../application-module/preselection/requisitionsales/requisitionsales.component';
import { ApproverrequisitionlistComponent } from '../../application-module/preselection/approverrequisitionlist/approverrequisitionlist.component';
import { RorequisitionlistComponent } from '../../application-module/preselection/rorequisitionlist/rorequisitionlist.component';
import { RmrequisitionlistComponent } from '../../application-module/preselection/rmrequisitionlist/rmrequisitionlist.component';
import { AllocatetormComponent } from '../../application-module/preselection/allocatetorm/allocatetorm.component';
import { AddcandidateComponent } from '../../application-module/preselection/addcandidate/addcandidate.component';
import { JobdescriptionComponent } from '../../application-module/master/jobdescription/jobdescription.component';
import { AllocatesourcechannelComponent } from '../../application-module/preselection/allocatesourcechannel/allocatesourcechannel.component';
import { GetcandidateComponent } from '../../application-module/preselection/getcandidate/getcandidate.component';
import { ViewcandidateComponent } from '../../application-module/preselection/viewcandidate/viewcandidate.component';
import { ViewallcandidateComponent } from '../../application-module/preselection/viewallcandidate/viewallcandidate.component';
@NgModule({
    declarations: [
        MasterlayoutComponent,
        NavMenuComponent,
        LoginlayoutComponent,
        DashboardComponent,
        LoginComponent,
        RequisitionplantComponent,
        RequisitioncorporateComponent,
        RequisitionsalesComponent,
        ApproverrequisitionlistComponent,
        RorequisitionlistComponent,
        RmrequisitionlistComponent,
        AllocatetormComponent,
        AddcandidateComponent,
        JobdescriptionComponent,
        AllocatesourcechannelComponent,
        GetcandidateComponent,
        ViewcandidateComponent,
        ViewallcandidateComponent
    ],
    imports: [
      CommonModule,
      RouterModule,
      FormsModule,
      ReactiveFormsModule,
      BrowserAnimationsModule,
      ToastrModule.forRoot()
    ],
    providers: [
      AuthenticationGuard,
      AuthguardserviceService,
      ShareddataService,
      PersistanceService
    ],
  })
  export class MasterLayoutModule { }