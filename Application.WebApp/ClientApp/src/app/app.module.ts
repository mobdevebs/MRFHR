import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

import {MasterLayoutModule} from './layouts/masterlayout/masterlayout.module';
import {AppRoutingModule} from './layouts/masterlayout/routing';


@NgModule({
  declarations: [
    AppComponent,
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    MasterLayoutModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
