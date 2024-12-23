import { HttpClient } from '@angular/common/http';
import { inject,Injectable } from '@angular/core';
import { Task_Page, Task_StudentPage } from '../intarfaces/task.intarface';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  http: HttpClient = inject(HttpClient)

  baseapiURL: string = 'https://localhost:7260/Task/'

  getTasks() {
      return this.http.get<Task_StudentPage[]>(`${this.baseapiURL}?StudentId=74cb4c4c-274d-43d4-b806-30a88636eaa0`)
  }

  getTask(idTask: string) {
    return this.http.get<Task_Page>(`${this.baseapiURL}${idTask}`)
  }

  updateTask(TaskId: string,data: any){
    return this.http.put(`${this.baseapiURL}${TaskId}`,data)
  }

  deleteTask(idTask: string){
    return this.http.delete(`${this.baseapiURL}${idTask}`)
  }

  createTask(data: any){
    return this.http.post(`https://localhost:7260/createTask`, data)
  }
}
