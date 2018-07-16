using Livraria.ConexaoBD;
using Livraria.Model.Entidades;
using Livraria.Negocio.Repositorio;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Negocio.DAO
{
    // Essa classe é abstrata para obrigar que o programar crie uma herança e para que não possa ser instanciada
    public abstract class LivroDao : DaoBase<Livro>
    {

        /*  Se necessário aqui podemos usar o 'new' para ocultar os métodos do DaoBase para a camada de negócio, assim fazemos com que
        seja necessário passar pelo inserir do DAO da classe para ai chegar no inserir do DAO base.
        Essa implementação pode ser usada quando necessitamos fazer alguma alteração no banco de dados ou no objeto a ser excluido/editado/inserido
        Um exemplo seria se tivessemos um campo na tabela livro que guarda a data e hora da inserção do registro no banco, poderiamos 
        fazer algo do tipo

        livro.dahinsLiv = DateTime.Now

        Assim iriamos garantir que a data de inserção estaria sempre correta
         */

        public new void Inserir(Livro livro)
        {
            base.Inserir(livro);
        }

        public new IList<Livro> Buscar(){
            using(ISession _session = NHibernateConexao.OpenSession())
            {
               return _session.QueryOver<Livro>().OrderBy(x => x.nomeLiv).Asc.List();
            }
        }
    }
}
