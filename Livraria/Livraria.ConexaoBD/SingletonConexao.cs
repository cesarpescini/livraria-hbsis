using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ConexaoBD
{

    // Singleton responsável por manter os mapeamentos e a configurações da conexão
    public class SingletonConexao
    {
        private static SingletonConexao _instance;
        public Hashtable Conexao;
        public ArrayList Mapeamentos;

        public static SingletonConexao Instance => _instance ?? (_instance = new SingletonConexao());

        public void Create(dynamic caminho, ArrayList mappings)
        {
            if (_instance == null)
                _instance = new SingletonConexao();

            Conexao = AES.DecriptarArquivoConexao(caminho);
            Mapeamentos = mappings;
        }
    }
}
