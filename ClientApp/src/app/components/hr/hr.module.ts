import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NzModule } from '../../common/nz.module';
import { CommonCompsModule } from '../common-comps/common-comps.module';
import { HrComponent } from './hr.component';
import { HrTemplateComponent } from './hr-template/hr-template.component';

const routes: Routes = [
  {path: "", component: HrTemplateComponent, children: [
    {path: "", component: HrComponent}
  ]}
];

@NgModule({
  declarations: [
    HrComponent,
    HrTemplateComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    CommonCompsModule,
    NzModule
  ]
})
export class HrModule { }
