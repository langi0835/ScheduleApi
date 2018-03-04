import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { AllScheduleViewComponent } from './all-schedule-view/all-schedule-view.component';
import { ScheduleService } from './schedule.service';
import { HttpModule } from '@angular/http';


@NgModule({
  declarations: [
    AppComponent,
    AllScheduleViewComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule
  ],
  providers: [ScheduleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
