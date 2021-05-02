import { Component, OnInit } from '@angular/core';
import {Person} from '../../models/person.model';
import {PersonService} from '../../services/person.service';
import {faEdit, faTrash} from '@fortawesome/free-solid-svg-icons';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.scss']
})
export class PersonListComponent implements OnInit {

  persons?: Person[];
  title = '';
  icons = {
    faEdit,
    faTrash
  };

  constructor(private personService: PersonService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.retrievePersons();
  }

  retrievePersons(): void {
    this.personService.list()
      .subscribe(
        data => {
          this.persons = data;
        });
  }

  deletePerson(id: number): void {
    this.personService.delete(id)
      .subscribe(
        response => {
          this.toastr.success("Pessoa removida com sucesso!");
          this.retrievePersons();
        });
  }

}
