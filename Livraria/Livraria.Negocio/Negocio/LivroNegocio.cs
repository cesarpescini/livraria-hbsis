using Livraria.Model.Entidades;
using Livraria.Negocio.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Negocio.Negocio
{
    
    public class LivroNegocio : LivroDao
    {
       /*
        Assim como no DAO aqui podemos usar o 'new' para ocultar o método do Dao da classe.
        Neste caso fariamos com que o programador seja sempre obrigado a passar por persistências
        relacionadas a regra de negócio não podendo assim acessar diretamente o inserir do Dao.
        */
        public void Persistencia(Livro livro)
        {
            

        }
        public new void Inserir(Livro livro)
        {
            Persistencia(livro);
            base.Inserir(livro);
        }

    }
}
