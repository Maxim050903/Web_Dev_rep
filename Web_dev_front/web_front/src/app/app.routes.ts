import { Routes } from '@angular/router';
import { LoginPageComponent } from './Pages/login-page/login-page.component';
import { StudentTaskPageComponent } from './Pages/student-task-page/student-task-page.component';
import { TaskPageComponent } from './Pages/task-page/task-page.component';
import { TeacherFirstPageComponent } from './Pages/teacher-first-page/teacher-first-page.component';
import { TaskUpdatePageComponent } from './Pages/task-update-page/task-update-page.component';

export const routes: Routes = [
  {path: 'StudentTask', component: StudentTaskPageComponent},
  {path: '', component: LoginPageComponent},
  {path: 'StudentTask/Task', component: TaskPageComponent},
  {path: 'TeacherDiscipline', component: TeacherFirstPageComponent},
  {path: 'TeacherDiscipline/Tasks',component: StudentTaskPageComponent},
  {path: 'TeacherDiscipline/Tasks/Task',component: TaskPageComponent},
  {path: 'TeacherDiscipline/Tasks/Task/UpdateTask',component: TaskUpdatePageComponent},
  {path: 'TeacherDiscipline/Tasks/CreateTask', component: TaskUpdatePageComponent}
];
