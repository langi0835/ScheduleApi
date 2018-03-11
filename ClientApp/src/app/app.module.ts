import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { HttpModule } from '@angular/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { AllScheduleViewComponent } from './all-schedule-view/all-schedule-view.component';
import { ScheduleService } from './schedule.service';


@NgModule({
  declarations: [
    AppComponent,
    AllScheduleViewComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule,
    NgbModule.forRoot()
  ],
  providers: [ScheduleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
