import { Component, OnInit, Input } from '@angular/core';

import { Person } from '../Models/Person'

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {

  @Input() personOutput: Person;
  constructor() { }

  ngOnInit() {
  }

}
