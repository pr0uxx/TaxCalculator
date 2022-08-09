import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { IncomeTaxDto } from 'src/app/classes/income-tax-dto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AnnualSalaryService {

  controller = environment.apiUrl + 'api/incometax';

  constructor(private http: HttpClient) { }

  getAnnualSalaryDetails(grossAnnualSalary: number) : Observable<IncomeTaxDto>{
    return this.http.get<IncomeTaxDto>(`${this.controller}`, {params: {
      'grossAnnualSalary': grossAnnualSalary.toString(),
      'year': '2022'
    }});
  }
}
