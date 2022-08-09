import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IncomeTaxDto } from 'src/app/classes/income-tax-dto';
import { GrossAnnualSalaryForm } from 'src/app/interfaces/forms/gross-annual-salary-form';
import { AnnualSalaryService } from 'src/app/services/annual-salary-service/annual-salary.service';

@Component({
  selector: 'app-annual-salary-input',
  templateUrl: './annual-salary-input.component.html',
  styleUrls: ['./annual-salary-input.component.css']
})
export class AnnualSalaryInputComponent implements OnInit {
  @Output() onUpdate = new EventEmitter<IncomeTaxDto>();
  @ViewChild('calculateButton') calculateButton: ElementRef<HTMLElement> | null = null;

  get grossAnnualSalary() {return this.annualSalaryForm.get('grossAnnualSalary')}

  constructor(private annualSalaryService: AnnualSalaryService) { }

  ngOnInit(): void {
  }

  annualSalaryForm = new FormGroup<GrossAnnualSalaryForm>({
    grossAnnualSalary: new FormControl(null, { nonNullable: false, validators: [Validators.required, Validators.min(0.01)] },  )
  });

  onSubmit() {
    this.calculateButton?.nativeElement.setAttribute('aria-busy', 'true');

    this.annualSalaryService.getAnnualSalaryDetails(Number(this.annualSalaryForm.value.grossAnnualSalary))
      .subscribe({
        next: result => {
          this.calculateButton?.nativeElement.setAttribute('aria-busy', 'false');
          this.onUpdate.emit(result);
        },
        error: e => console.error(e)
      })
  }

}
