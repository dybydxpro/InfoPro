import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanningTemplateComponent } from './planning-template.component';

describe('PlanningTemplateComponent', () => {
  let component: PlanningTemplateComponent;
  let fixture: ComponentFixture<PlanningTemplateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PlanningTemplateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlanningTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
