using Livraria.Model.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Livraria.Negocio.Repositorio
{
    public static class ArquivoConexao
    {
       /*
        Esse arquivo juntaente com o DaoBase são os dois unicos arquivos necessários para conectar com BD após ter referenciado
        o projeto ConexaoBD
            */
        public static string caminho { get; set; }
        public static ArrayList mapeamentos { get; set; }

        // Construtor static da classe, sempre será chamado
        // Obs: Para cada novo mapeamento criado deve ser adicionado no construtor a baixo conforme o exemplo
        static ArquivoConexao()
        {
            caminho = GetCaminho();
            #region MAPEAMENTOS
            mapeamentos = new ArrayList();
            //Exemplo de utilizacao AddMap<MinhaClasseMap>();
            AddMap<LivroMap>();
            #endregion
        }

        // Método que retorna o caminho do arquivo de conexão, deve ser escrito conforme a necessidade de cada projeto
        private static string GetCaminho()
        {
            return HttpRuntime.AppDomainAppPath + "connection.snc";
        }

        // Método para adicionar o mapeamento a uma lista de mapeamentos que será usada na configuração da conexão com o banco
        private static void AddMap<Classe>() where Classe : class
        {
            mapeamentos.Add(typeof(Classe).AssemblyQualifiedName);
        }
    }
}
