import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Livro } from './modelos/Livro';

@Injectable({
  providedIn: 'root'
})
export class LivrariaService {

  livrariaUrl = "http://localhost:54999/WebApi/Livro";
  constructor(private http: HttpClient) { }

  listar(){   
    return this.http.get<any[]>(`${this.livrariaUrl}`);
  }

  getLivro(id:number){
    let getLivroUrl = this.livrariaUrl + "/" +id;
    return this.http.get(getLivroUrl);
  }

  public inserir(livro : Livro){
    return this.http.post(this.livrariaUrl,livro,{headers: {'Contet-Type' : 'application/json'}});
  }

  public salvar(livro : Livro){
    let urlEdicao = this.livrariaUrl + "/" + livro.codigoLiv;
    return this.http.put(urlEdicao,livro,{headers: {'Contet-Type' : 'application/json'}});
  }

  public deletar(livro : Livro){
    console.log(livro);
    let urlEdicao = this.livrariaUrl + "/" + livro.codigoLiv;
    return this.http.delete(urlEdicao);
  }
}
