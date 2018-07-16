export class Livro{
    public codigoLiv : number;
    public nomeLiv : string;
    public escritLiv : string;
    public editorLiv : string;
    public precoLiv : number;
    public qtdpagLiv : number;
    public qtdestLiv : number;

    constructor(livro?){
        Object.assign(this, livro);
    }
  }