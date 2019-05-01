import { Component, OnInit } from '@angular/core';
import { Person } from '../Models/Person'
import { Observable, of } from 'rxjs';

import { HomeService } from '../Services/home.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  person: Person = {
    Name: '',
    Salary: 0,
    SalaryInWords: ''
  };

  personOutput: Person;

  constructor(private homeService: HomeService) { }

  ngOnInit() {
  }

  ProcessRequest(): Observable<Person> {

    this.homeService.ConvertNumberToWords(this.person).subscribe(resp => {
      this.personOutput = {
        Name: resp["Name"],
        Salary: resp["Salary"],
        SalaryInWords: resp["SalaryInWords"]
      };
    });
    return of(this.personOutput);
  }

}
