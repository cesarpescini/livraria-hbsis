import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LivrariaListagemComponent } from './livraria-listagem.component';

describe('LivrariaListagemComponent', () => {
  let component: LivrariaListagemComponent;
  let fixture: ComponentFixture<LivrariaListagemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LivrariaListagemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LivrariaListagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
