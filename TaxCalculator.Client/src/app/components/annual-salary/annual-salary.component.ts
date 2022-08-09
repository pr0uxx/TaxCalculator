import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { IncomeTaxDto } from 'src/app/classes/income-tax-dto';
import { GrossAnnualSalaryForm } from 'src/app/interfaces/forms/gross-annual-salary-form';
import { AnnualSalaryService } from 'src/app/services/annual-salary-service/annual-salary.service';

@Component({
  selector: 'app-annual-salary',
  templateUrl: './annual-salary.component.html',
  styleUrls: ['./annual-salary.component.css']
})
export class AnnualSalaryComponent implements OnInit {

  model = new IncomeTaxDto();
  @ViewChild('pageContainer') pageContainer: ElementRef<HTMLElement> | null = null;


  constructor() { }

  ngOnInit(): void {
  }

  onInputResult(event: IncomeTaxDto){
    this.model = event;

    if (this.model.grossAnnualSalary > 0)
    {
      this.pageContainer?.nativeElement.setAttribute('aria-expanded', 'true');
    }
  }
}
