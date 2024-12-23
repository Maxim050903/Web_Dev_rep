import { Task_Page } from './../../data/intarfaces/task.intarface';
import { Component, inject, Input } from '@angular/core';
import { TaskService } from '../../data/services/task.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-task-page',
  imports: [],
  templateUrl: './task-page.component.html',
  styleUrl: './task-page.component.scss'
})
export class TaskPageComponent {
  TaskService = inject(TaskService)
  task!: Task_Page;
  adress!: string;
  isTeacher!: string;
  DisciplineName!: string
  TeacherId!: string
  DisciplineId!: string

  form = new FormGroup({
      DateEnd: new FormControl(null,Validators.required),
      description: new FormControl(null,Validators.required)
    })

  constructor(public route: ActivatedRoute, public router: Router)
  {
    this.route.queryParams.subscribe(params => {
      this.adress = params["TaskId"],
      this.isTeacher = params["isTeacher"]
      this.DisciplineName = params["DisciplineName"]
      this.TeacherId = params["TeacherId"]
      this.DisciplineId = params["DisciplineId"]
    })

    this.TaskService.getTask(this.adress)
        .subscribe(val => {
          this.task = val
        })
  }
  onTextClick(TaskId: string): void {
    this.router.navigate(['TeacherDiscipline/Tasks/Task/UpdateTask'], { queryParams: {TeacherId: this.TeacherId,DisciplineId:this.DisciplineId,TaskId: this.adress , Headers: "Личный кабинет преподавателя", isTeacher: true, DisciplineName:this.DisciplineName} })
  }
  onTextClickDel(TaskId: string): void {
    this.TaskService.deleteTask(this.adress)
    .subscribe()
    this.router.navigate(['TeacherDiscipline/Tasks'], { queryParams: {TeacherId:this.TeacherId, DisciplineId: this.DisciplineId, Headerstr: "Личный кабинет преподавателя", isTeacher: true, DisciplineName: this.DisciplineName}});
  }
}

