import { Injectable } from '@angular/core';

@Injectable()
export class ShareddataService {
  public sharedData:number;

  constructor(){
    this.sharedData = 0;
  }

  setData (data) {
    this.sharedData = data;
  }
  getData () {
    return this.sharedData;
  }

}