import { Component, OnInit } from '@angular/core';
import { LivrariaService } from '../livraria.service';

@Component({
  selector: 'app-livraria-listagem',
  templateUrl: './livraria-listagem.component.html',
  styleUrls: ['./livraria-listagem.component.css']
})
export class LivrariaListagemComponent implements OnInit {

  livros : Array<any>;

  constructor(private livrariaService : LivrariaService) { }

  ngOnInit() {
    this.listar();
  }

  listar(){
    this.livrariaService.listar().subscribe(dados => this.livros = dados);
  }

}
