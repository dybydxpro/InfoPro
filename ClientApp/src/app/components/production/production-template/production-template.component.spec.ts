import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionTemplateComponent } from './production-template.component';

describe('ProductionTemplateComponent', () => {
  let component: ProductionTemplateComponent;
  let fixture: ComponentFixture<ProductionTemplateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProductionTemplateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProductionTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
