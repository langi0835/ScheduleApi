export class PaginationConditions {
  Page: Number;
  PageSize: Number;
}

export class AllScheduleConditions extends PaginationConditions {
  InfoName: string;
  ScheduleID: string;
  TaskSetName: string;
}

export class AllScheduleItem {
  INFO_NAME: string;
  JOB_SCHEDULE_ID: string;
  TASKSET_NAME: string;
  ACTION: string;
  DESCRIPTION: string;
  SELECTEDDATE: Date;
  SELECTEDTIME: string;
  ISENABLED: Number;
}


