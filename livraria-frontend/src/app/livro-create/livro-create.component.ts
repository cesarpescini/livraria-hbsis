import { Component, OnInit } from '@angular/core';
import { Livro } from 'src/app/modelos/Livro';
import { LivrariaService } from '../livraria.service';
import { NG_VALIDATORS, Validator, Validators, AbstractControl, FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute,Router } from '@angular/router';


@Component({
  selector: 'app-livro-create',
  templateUrl: './livro-create.component.html',
  styleUrls: ['./livro-create.component.css']
})

export class LivroCreateComponent implements OnInit {
  public livro: Livro;
  form : FormGroup;
  public editando : boolean = false;

  constructor(private livrariaService : LivrariaService, private _Activatedroute:ActivatedRoute, private Router:Router) { 
    this.livro = new Livro();
  }

  ngOnInit() {
    if(this._Activatedroute.snapshot.data['action']){
      if(this._Activatedroute.snapshot.data['action'] = 'delete'){
        this.livrariaService.getLivro(this._Activatedroute.snapshot.params['id']).subscribe(x => {this.livro = new Livro(x); this.deletar()});
      }
    }
    if(this._Activatedroute.snapshot.params['id']){
      this.livrariaService.getLivro(this._Activatedroute.snapshot.params['id']).subscribe(x => this.livro = new Livro(x));
      this.editando = true;
    }else{
      this.editando = false;
    }
    this.form = new FormGroup({});
  }

  inserir(){
    this.livrariaService.inserir(this.livro).subscribe(x => {this.Router.navigate(['livro']);});
  }

  salvar(){
    this.livrariaService.salvar(this.livro).subscribe(x => {this.Router.navigate(['livro']);});
  }

  deletar(){
    this.livrariaService.deletar(this.livro).subscribe(x => {this.Router.navigate(['livro']);});
  }

}
