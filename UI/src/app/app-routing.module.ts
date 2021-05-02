import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {PersonListComponent} from './components/person-list/person-list.component';
import {PersonFormComponent} from './components/person-form/person-form.component';

const routes: Routes = [
  { path: '', redirectTo: 'person', pathMatch: 'full' },
  { path: 'person', component: PersonListComponent },
  { path: 'person/:id', component: PersonFormComponent },
  { path: 'person/new', component: PersonFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
