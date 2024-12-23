import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Discipline_TeacherPage } from '../intarfaces/discipline.intarface';

@Injectable({
  providedIn: 'root'
})
export class DisciplineServiceService {
  http: HttpClient = inject(HttpClient)

    baseapiURL: string = 'https://localhost:7260/Discipline/'

    getDisciplines(TeacherId: string) {
        return this.http.get<Discipline_TeacherPage[]>(`${this.baseapiURL}${TeacherId}`)
    }

    //getDiscipline(idTask: string) {
    //  return this.http.get<Task_Page>(`${this.baseapiURL}${idTask}`)
    //}
}
