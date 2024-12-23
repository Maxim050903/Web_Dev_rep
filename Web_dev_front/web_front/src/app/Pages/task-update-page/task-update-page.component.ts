import { Component, inject } from '@angular/core';
import { Task_Page } from '../../data/intarfaces/task.intarface';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../../data/services/task.service';

@Component({
  selector: 'app-task-update-page',
  imports: [ReactiveFormsModule],
  templateUrl: './task-update-page.component.html',
  styleUrl: './task-update-page.component.scss'
})
export class TaskUpdatePageComponent {
  TaskService = inject(TaskService)
  task!: Task_Page;
  adress!: string;
  isTeacher!: string;
  isCreate!: string;
  DisciplineName!: string;
  idTask!: string
  DisciplineId!: string
  TeacherId!: string

  form = new FormGroup({
      DateEnd: new FormControl(null,Validators.required),
      description: new FormControl(null,Validators.required)
    })
  location: any;

  constructor(public route: ActivatedRoute, public router: Router)
  {
      this.route.queryParams.subscribe(params => {
      this.adress = params["TaskId"],
      this.isTeacher = params["isTeacher"]
      this.isCreate = params["isCreate"]
      this.DisciplineName = params["DisciplineName"]
      this.idTask = params["TaskId"]
      this.DisciplineId = params["DisciplineId"],
      this.TeacherId = params["TeacherId"]
    })

    if(this.isCreate != 'true')
    {
    this.TaskService.getTask(this.adress)
        .subscribe(val => {
          this.task = val
          console.log(this.task)
        })
    }
  }

  onSubmit(){

    //if(this.form.valid)
    {
      if(this.isCreate == 'true')
      {
        const requestData = {
          dateFinish: this.form.value["DateEnd"],
          description: this.form.value["description"],
          idDiscipline: this.DisciplineId,
          idGroup:"39cb701e-bb8d-486c-aa0b-e6a34b94aca8",
          idTeacher:this.TeacherId
        };
        console.log("Создание задачи")
        console.log(requestData)
        this.TaskService.createTask(requestData)
        .subscribe()
        this.router.navigate(['TeacherDiscipline/Tasks'], { queryParams: {TeacherId:this.TeacherId, DisciplineId: this.DisciplineId, Headerstr: "Личный кабинет преподавателя", isTeacher: true, DisciplineName: this.DisciplineName}});
      }else{
        const requestData = {
          dateFinish: this.form.value["DateEnd"],
          description: this.form.value["description"]
        };
        console.log("Редактирование задачи")
        this.TaskService.updateTask(this.idTask,requestData)
        .subscribe()
        this.router.navigate(['TeacherDiscipline/Tasks'], { queryParams: {TeacherId:this.TeacherId, DisciplineId: this.DisciplineId, Headerstr: "Личный кабинет преподавателя", isTeacher: true, DisciplineName: this.DisciplineName}});
      }
    }
  }
}
