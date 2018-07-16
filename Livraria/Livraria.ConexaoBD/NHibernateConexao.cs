using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ConexaoBD
{
    public class NHibernateConexao
    {
        private static ISessionFactory session;
        public static FluentConfiguration _configuration;
        private static Hashtable connectionVars;
        private static ArrayList assemblies;

        /// <summary>
        ///     Configura a conexão com banco de dados
        /// </summary>
        private static void Configure()
        {
            try
            {
                if (_configuration == null)
                {
                    _configuration = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(
                        x => x.Server(connectionVars["server"].ToString())
                        .Username(connectionVars["username"].ToString())
                        .Password(connectionVars["password"].ToString())
                        .Database(connectionVars["database"].ToString())).ShowSql())
                        .ExposeConfiguration(cfg => new SchemaExport(cfg));

                    foreach (string assembly in assemblies)
                    {
                        Type tipo = Type.GetType(assembly);
                        _configuration.Mappings(c => c.FluentMappings.Add(tipo));
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        ///     Cria uma nova sessão caso ainda não exista uma criada
        /// </summary>
        /// <returns></returns>
        private static ISessionFactory CreateSession()
        {
            if (session != null)
                return session;

            session = _configuration.BuildSessionFactory();
            return session;
        }

        /// <summary>
        ///     Abre uma sessão
        /// </summary>
        /// <param name="conexao">Hashtable contendo as configurações da conexão</param>
        /// <param name="mappings">Arraylist contendo a lista de mapeamentos</param>
        /// <returns>Retorna uma nova sessão</returns>
        public static ISession OpenSession(Hashtable conexao, ArrayList mappings)
        {
            connectionVars = conexao;
            assemblies = mappings;
            Configure();
            return CreateSession().OpenSession();
        }

        /// <summary>
        ///     Abre uma nova sessão com as váriaveis já configuradas.
        /// </summary>
        /// <returns></returns>
        public static ISession OpenSession()
        {
            Configure();
            return CreateSession().OpenSession();
        }
    }
}
