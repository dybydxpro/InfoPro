import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HrTemplateComponent } from './hr-template.component';

describe('HrTemplateComponent', () => {
  let component: HrTemplateComponent;
  let fixture: ComponentFixture<HrTemplateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HrTemplateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HrTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
