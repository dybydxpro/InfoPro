import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NzModule } from '../../common/nz.module';
import { CommonCompsModule } from '../common-comps/common-comps.module';
import { HrComponent } from './hr.component';
import { HrTemplateComponent } from './hr-template/hr-template.component';
import { OfficeComponent } from './office/office.component';

const routes: Routes = [
  {path: "", component: HrTemplateComponent, children: [
    {path: "", component: HrComponent},
    {path: "office", component: OfficeComponent},
  ]}
];

@NgModule({
  declarations: [
    HrComponent,
    HrTemplateComponent,
    OfficeComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    CommonCompsModule,
    NzModule
  ]
})
export class HrModule { }
