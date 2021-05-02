import { Component, OnInit } from '@angular/core';
import {Person} from '../../models/person.model';
import {PersonService} from '../../services/person.service';
import {ToastrService} from 'ngx-toastr';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-add-person',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.scss']
})
export class PersonFormComponent implements OnInit {

  person: Person = new Person();
  update = false;

  constructor(private personService: PersonService,
              private toastr: ToastrService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.update = !isNaN(this.route.snapshot.params.id);
    if (this.update) {
      this.getPerson(this.route.snapshot.params.id);
    }
  }

  savePerson(): void {

    if (this.update) {
      this.personService.update(this.person.id, this.person)
        .subscribe(
          response => {
            this.toastr.success("Pessoa alterada com sucesso!");
            this.router.navigate(['/person']);
          });
    } else {
      this.personService.create(this.person)
        .subscribe(
          response => {
            this.toastr.success("Pessoa cadastrada com sucesso!");
            this.router.navigate(['/person']);
          });
    }
  }

  getPerson(id: number): void {
    this.personService.get(id)
      .subscribe(
        data => {
          this.person = data;
        });
  }


}
