import { Component } from '@angular/core';
import { Person } from "../models/person";

@Component({
  selector: 'app-people-page',
  templateUrl: './people-page.component.html',
  styleUrls: ['./people-page.component.scss']
})
export class PeoplePageComponent {

  people: Array<Person> = [
    {id: 1, firstName: "Remus-Nicolae", lastName: "Pelle", nickname: "Nicholas"} as Person,
    {id: 2, firstName: "Norbert", lastName: "Bordas", nickname: "Norbi"} as Person,
    {id: 3, firstName: "Marcela", lastName: "Popa-Bota", nickname: "Marci"} as Person,
    {id: 4, firstName: "Adriana", lastName: "Gavrilut", nickname: "Iaia"} as Person,
  ];
}
