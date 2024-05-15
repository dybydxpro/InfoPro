import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NzModule } from '../../common/nz.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonCompsModule } from '../common-comps/common-comps.module';
import { PlanningTemplateComponent } from './planning-template/planning-template.component';
import { PlanningComponent } from './planning.component';
import { GeneratePlanComponent } from './generate-plan/generate-plan.component';

const routes: Routes = [
  {path: "", component: PlanningTemplateComponent, children: [
    {path: "", component: PlanningComponent},
    {path: "generate", component: GeneratePlanComponent}
  ]}
];

@NgModule({
  declarations: [
    PlanningTemplateComponent,
    PlanningComponent,
    GeneratePlanComponent,
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
export class PlanningModule { }
