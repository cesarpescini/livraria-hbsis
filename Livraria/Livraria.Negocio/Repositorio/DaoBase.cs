using Livraria.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Negocio.Repositorio
{
    public class DaoBase<T> : DaoGenerico<T> where T : class
    {
        public DaoBase()
        {
            SingletonConexao.Instance.Create(ArquivoConexao.caminho, ArquivoConexao.mapeamentos);
            NHibernateConexao.OpenSession(SingletonConexao.Instance.Conexao, SingletonConexao.Instance.Mapeamentos);
        }
    }
}
