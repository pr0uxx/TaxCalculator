import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AnnualSalaryComponent } from './components/annual-salary/annual-salary.component';
import { AnnualSalaryInputComponent } from './components/annual-salary/annual-salary-input/annual-salary-input.component';
import { AnnualSalaryOutputComponent } from './components/annual-salary/annual-salary-output/annual-salary-output.component';

@NgModule({
  declarations: [
    AppComponent,
    AnnualSalaryComponent,
    AnnualSalaryInputComponent,
    AnnualSalaryOutputComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
