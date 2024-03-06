import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TablestudentsComponent } from './tablestudents.component';

describe('TablestudentsComponent', () => {
  let component: TablestudentsComponent;
  let fixture: ComponentFixture<TablestudentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TablestudentsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TablestudentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
