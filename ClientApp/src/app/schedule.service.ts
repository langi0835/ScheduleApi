import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/do';

@Injectable()
export class ScheduleService {
  private scheduleUrl = 'http://localhost:5000/api/AllSchedule';
  private headers = new Headers({ 'Content-Type': 'appliation/json' });
  constructor(private http: Http) { }

  getAllScheduleView(): Promise<any> {
    const url = `${this.scheduleUrl}/GetAllSchedulePagination?InfoName=info&ScheduleID=id&TaskSetName=name`;
    return this.http.get(url)
      .do(data => console.log(data))
      .toPromise()
      .then(res => res.json().data)
      .catch(this.handleError);
  }

  // getAllScheduleView(condition: AllScheduleConditions): Promise<any> {
  //   const url = `${this.scheduleUrl}/GetAllSchedulePagination`;
  //   return this.http.get(url, JSON.stringify(condition))
  //     .toPromise()
  //     .then(res => res.json().data)
  //     .catch(this.handleError);
  // }

  private handleError(error: any) {
    console.error(error); // log to console instead
    return Promise.reject(error.message || error);
  }
}
