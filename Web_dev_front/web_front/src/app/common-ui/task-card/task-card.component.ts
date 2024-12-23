import { Component,Input } from '@angular/core';
import { Task_StudentPage } from '../../data/intarfaces/task.intarface';
import { ActivatedRoute,Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-task-card',
  imports: [RouterOutlet],
  templateUrl: './task-card.component.html',
  styleUrl: './task-card.component.scss'
})
export class TaskCardComponent {
  @Input() task!: Task_StudentPage;
  @Input() TeacherId!: string
  Headerstr!: string
  isTeacher!: string
  DisciplineName!: string
  DisciplineId!: string
  constructor(public route: ActivatedRoute, private router: Router)
  {
    this.route.queryParams.subscribe(params => {
      this.Headerstr = params["Headerstr"],
      this.isTeacher = params["isTeacher"],
      this.DisciplineName = params["DiscplineName"],
      this.DisciplineId = params["DisciplineId"]
    })
  }

  stringToBoolean(value: string): boolean {
    return value.toLowerCase() === 'true';
  }

  onTextClick(TaskId: string,DisciplineName: string): void {
    if (this.stringToBoolean(this.isTeacher))
    {
      this.router.navigate(['TeacherDiscipline/Tasks/Task'], { queryParams: { TeacherId: this.TeacherId,DisciplineId: this.DisciplineId,TaskId ,isTeacher: true,DisciplineName: DisciplineName}});
    }else{
      this.router.navigate(['StudentTask/Task'], { queryParams: { TeacherId: this.TeacherId,TaskId,isTeacher: false}});
    }
  }


}
