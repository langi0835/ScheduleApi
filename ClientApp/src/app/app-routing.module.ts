import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllScheduleViewComponent } from './all-schedule-view/all-schedule-view.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'allscheduleview',
    pathMatch: 'full'
  },
  {
    path: 'allscheduleview',
    component: AllScheduleViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
