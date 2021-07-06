import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class VendorService {
  private apiURL = environment.apiurl;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  httpOptionsFile = {
    headers: new HttpHeaders(
      
    )
  }
  constructor(private httpClient: HttpClient) { }
  getCurrentJob(formData: any): Observable<any> {
    return this.httpClient.post<any>(this.apiURL + '/vendor/getcurrentjob', JSON.stringify(formData), this.httpOptions)
        .pipe(
          catchError(this.errorHandler)
        )
    }
  getAllVendor(formData: any): Observable<any> {
    return this.httpClient.post<any>(this.apiURL + '/vendor/getallvendor', formData, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      )
  }

  allocateRequisitionToRM(formData: any): Observable<any> {
    return this.httpClient.post<any>(this.apiURL + '/requisition/allocaterequisitiontorm', formData, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      )
  }
  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
