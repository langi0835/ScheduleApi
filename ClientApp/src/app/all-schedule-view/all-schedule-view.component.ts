import { Component, OnInit } from '@angular/core';
import { ScheduleService } from '../schedule.service';

@Component({
  selector: 'app-all-schedule-view',
  templateUrl: './all-schedule-view.component.html',
  styleUrls: ['./all-schedule-view.component.css']
})
export class AllScheduleViewComponent implements OnInit {
  allScheduleItems: any;
  constructor(private scheduleService: ScheduleService) { }

  ngOnInit() {
    this.search(1);
  }

  search(page: Number) {
    this.scheduleService.getAllScheduleView()
      .then(data => this.allScheduleItems = data);
  }

}
