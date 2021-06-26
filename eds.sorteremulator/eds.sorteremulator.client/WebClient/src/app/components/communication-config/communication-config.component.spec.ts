import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CommunicationConfigComponent } from './communication-config.component';

describe('CommunicationConfigComponent', () => {
  let component: CommunicationConfigComponent;
  let fixture: ComponentFixture<CommunicationConfigComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CommunicationConfigComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CommunicationConfigComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
