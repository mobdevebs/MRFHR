import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CommonService {
  private apiURL = environment.apiurl;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(private httpClient: HttpClient) { }

  getAllStatus(): Observable<any> {
    return this.httpClient.get<any>(this.apiURL + '/common/getallstatus')
      .pipe(
        catchError(this.errorHandler)
      )
  }

  getAllAge(): Observable<any> {
    return this.httpClient.get<any>(this.apiURL + '/common/getallage')
      .pipe(
        catchError(this.errorHandler)
      )
  }

  getAllExperience(): Observable<any> {
    return this.httpClient.get<any>(this.apiURL + '/common/getallexperience')
      .pipe(
        catchError(this.errorHandler)
      )
  }

  getAllGender(formData: any): Observable<any> {
    return this.httpClient.post<any>(this.apiURL + '/gender/getallgender', JSON.stringify(formData), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      )
  }

  getAllPrefix(formData: any): Observable<any> {
    return this.httpClient.post<any>(this.apiURL + '/prefix/getallprefix', JSON.stringify(formData), this.httpOptions)
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
