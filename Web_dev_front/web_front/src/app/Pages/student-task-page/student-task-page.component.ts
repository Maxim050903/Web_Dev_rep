import { Component,inject } from '@angular/core';
import { Task_StudentPage } from '../../data/intarfaces/task.intarface';
import { TaskService } from '../../data/services/task.service';
import { TaskCardComponent } from '../../common-ui/task-card/task-card.component';
import { ActivatedRoute,Router } from '@angular/router';

@Component({
  selector: 'app-student-task-page',
  imports: [TaskCardComponent],
  templateUrl: './student-task-page.component.html',
  styleUrl: './student-task-page.component.scss'
})
export class StudentTaskPageComponent {
  TaskService = inject(TaskService)
  Tasks: Task_StudentPage[] = []
  Headerstr!: string
  isTeacher!: string
  DisciplineId!: string
  DisciplineName!: string
  TeacherId!: string

  constructor(public route: ActivatedRoute,public router: Router){
      this.route.queryParams.subscribe(params => {
        this.Headerstr = params["Headerstr"],
        this.isTeacher = params["isTeacher"],
        this.DisciplineId = params["DisciplineId"]
        this.DisciplineName = params["DisciplineName"]
        this.TeacherId = params["TeacherId"]
      })
    this.TaskService.getTasks()
      .subscribe(val => {
        this.Tasks = val
      })
  }

  onTextClick(): void {
      this.router.navigate(['TeacherDiscipline/Tasks/CreateTask'],{ queryParams: {TeacherId: this.TeacherId, DisciplineId:this.DisciplineId, Headers: "Личный кабинет преподавателя", isTeacher: true, isCreate: true,DisciplineName:this.DisciplineName}});
  }

}
