import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NzModule } from '../../common/nz.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonCompsModule } from '../common-comps/common-comps.module';
import { ProductionComponent } from './production.component';
import { ProductionTemplateComponent } from './production-template/production-template.component';

const routes: Routes = [
  {path: "", component: ProductionTemplateComponent, children: [
    {path: "", component: ProductionComponent},
  ]}
];

@NgModule({
  declarations: [
    ProductionComponent,
    ProductionTemplateComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    CommonCompsModule,
    NzModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ProductionModule { }
