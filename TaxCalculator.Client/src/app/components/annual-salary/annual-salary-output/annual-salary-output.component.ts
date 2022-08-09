import { Component, Input, OnInit } from '@angular/core';
import { IncomeTaxDto } from 'src/app/classes/income-tax-dto';

@Component({
  selector: 'app-annual-salary-output',
  templateUrl: './annual-salary-output.component.html',
  styleUrls: ['./annual-salary-output.component.css']
})
export class AnnualSalaryOutputComponent implements OnInit {

  @Input() model : IncomeTaxDto | null = null;

  constructor() { }

  ngOnInit(): void {
  }

}
