import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IeTemplateComponent } from './ie-template.component';

describe('IeTemplateComponent', () => {
  let component: IeTemplateComponent;
  let fixture: ComponentFixture<IeTemplateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [IeTemplateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(IeTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
