using Livraria.Model.Entidades;
using Livraria.Negocio.Negocio;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Livraria.WebApi.Controllers
{
    [Route("WebApi/Livro")]
    public class LivroController : ApiController
    {
        private LivroNegocio livroNeg;

        public LivroController()
        {
            livroNeg = new LivroNegocio();
        }

        [HttpPost]
        public Livro PostLivro([FromBody]Livro livro)
        {
            livroNeg.Inserir(livro);

            return livro;
        }

        [HttpGet]
        public IEnumerable<Livro> GetLivros()
        {
            return livroNeg.Buscar();
        }

        [Route("WebApi/Livro/{id}")]
        [HttpGet]
        public Livro GetLivro(string id)
        {
            return livroNeg.Buscar(int.Parse(id));
        }

        [Route("WebApi/Livro/{id}")]
        [HttpPut]
        public void PutLivro([FromBody]Livro livro)
        {
            livroNeg.Atualizar(livro);
        }

        [Route("WebApi/Livro/{id}")]
        [HttpDelete]
        public void DeleteLivro(string id)
        {
            livroNeg.Deletar(livroNeg.Buscar(int.Parse(id)));
        }
    }
}
