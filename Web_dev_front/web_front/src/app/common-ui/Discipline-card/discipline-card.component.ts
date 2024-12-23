import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Discipline_TeacherPage } from '../../data/intarfaces/discipline.intarface';

@Component({
  selector: 'app-discipline-card',
  imports: [],
  templateUrl: './discipline-card.component.html',
  styleUrl: './discipline-card.component.scss'
})
export class DisciplineCardComponent {
  @Input() discipline!: Discipline_TeacherPage;
  @Input() TeacherId!: string;

  constructor(private router: Router){}

  onTextClick(TeacherId: string): void {
    console.log(TeacherId)
    const Headerstr: string = "Личный кабинет преподавателя"
    this.router.navigate(['TeacherDiscipline/Tasks'], { queryParams: {TeacherId:TeacherId, DisciplineId: this.discipline.id, Headerstr: Headerstr, isTeacher: true, DisciplineName: this.discipline.name}});
  }
}


