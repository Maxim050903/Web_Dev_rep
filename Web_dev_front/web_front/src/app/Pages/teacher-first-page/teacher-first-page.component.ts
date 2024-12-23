import { Component, inject } from '@angular/core';
import { DisciplineServiceService } from '../../data/services/discipline.service.service';
import { Discipline_TeacherPage } from '../../data/intarfaces/discipline.intarface';
import { ActivatedRoute } from '@angular/router';
import { DisciplineCardComponent } from "../../common-ui/Discipline-card/discipline-card.component";

@Component({
  selector: 'app-teacher-first-page',
  imports: [DisciplineCardComponent],
  templateUrl: './teacher-first-page.component.html',
  styleUrl: './teacher-first-page.component.scss'
})
export class TeacherFirstPageComponent {
  DisciplineService = inject(DisciplineServiceService)
  Disciplines: Discipline_TeacherPage[] = []
  adress!: string
  Hearedstr!: string
  isTeacher!: boolean

  constructor(public route: ActivatedRoute){
    this.route.queryParams.subscribe(params => {
      this.adress = params["Teacherid"]
      this.isTeacher = params["isTeacher"],
      this.Hearedstr = params["Headerstr"]
    })
    this.DisciplineService.getDisciplines(this.adress)
      .subscribe(val => {
        this.Disciplines = val
      })
  }
}
