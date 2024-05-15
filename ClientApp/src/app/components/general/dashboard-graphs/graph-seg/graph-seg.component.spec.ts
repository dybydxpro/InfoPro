import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphSegComponent } from './graph-seg.component';

describe('GraphSegComponent', () => {
  let component: GraphSegComponent;
  let fixture: ComponentFixture<GraphSegComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GraphSegComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GraphSegComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
