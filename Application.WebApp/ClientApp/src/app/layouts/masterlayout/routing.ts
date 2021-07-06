import { ModuleWithProviders } from '@angular/core';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationGuard } from '../../auth/authentication.guard'
import { DashboardComponent } from 'src/app/commonpages/dashboard/dashboard.component';
import { LoginComponent } from 'src/app/commonpages/login/login.component';
import { LoginlayoutComponent } from '../loginlayout/loginlayout.component';
import { MasterlayoutComponent } from './masterlayout.component';
import { JobdescriptionComponent } from '../../application-module/master/jobdescription/jobdescription.component';
import { RequisitionplantComponent } from '../../application-module/preselection/requisitionplant/requisitionplant.component';
import { RorequisitionlistComponent } from '../../application-module/preselection/rorequisitionlist/rorequisitionlist.component';

import { ApproverrequisitionlistComponent } from '../../application-module/preselection/approverrequisitionlist/approverrequisitionlist.component';
import { RmrequisitionlistComponent } from '../../application-module/preselection/rmrequisitionlist/rmrequisitionlist.component';
import { AllocatetormComponent } from '../../application-module/preselection/allocatetorm/allocatetorm.component';
import { AddcandidateComponent } from '../../application-module/preselection/addcandidate/addcandidate.component';
import { GetcandidateComponent } from '../../application-module/preselection/getcandidate/getcandidate.component';
import { ViewcandidateComponent } from '../../application-module/preselection/viewcandidate/viewcandidate.component';
import { ViewallcandidateComponent } from '../../application-module/preselection/viewallcandidate/viewallcandidate.component';
import { AllocatesourcechannelComponent } from '../../application-module/preselection/allocatesourcechannel/allocatesourcechannel.component';

import { CurrentjobComponent } from '../../application-module/vendor/currentjob/currentjob.component';
import { VendorcandidateComponent } from '../../application-module/vendor/vendorcandidate/vendorcandidate.component';


const routes: Routes = [
  {
    path: '',
    component: MasterlayoutComponent,
    canActivate: [AuthenticationGuard],
    children: [
      {
        path: 'home',
        component: DashboardComponent
      },
      {
        path: 'jobdescription',
        component: JobdescriptionComponent
      },
      {
        path: 'requisition/plant',
        component: RequisitionplantComponent
      },
      {
        path: 'approverrequisitionlist',
        component: ApproverrequisitionlistComponent
      },
      {
        path: 'rorequisitionlist',
        component: RorequisitionlistComponent
      },
      {
        path: 'rorequisitionlist/allocatetorm',
        component: AllocatetormComponent
      },
      {
        path: 'rmrequisitionlist',
        component: RmrequisitionlistComponent
      },
      {
        path: 'allocatesourcechannel',
        component: AllocatesourcechannelComponent
      },
      { path: 'getcandidate/:id', component: GetcandidateComponent },
      {
        path: 'addcandidate',
        component: AddcandidateComponent
      },
      {
        path: 'getcandidate',
        component: GetcandidateComponent
      },
      {
        path: 'viewcandidate',
        component: ViewcandidateComponent
      },
      {
        path: 'viewallcandidate',
        component: ViewallcandidateComponent
      },
      {
        path: 'currentjob',
        component: CurrentjobComponent
      },
      {
        path: 'vendorcandidate',
        component: VendorcandidateComponent
      }
    ]
  },
  {
    path: '',
    component: LoginlayoutComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent
      }
    ]
  }
];
//export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
