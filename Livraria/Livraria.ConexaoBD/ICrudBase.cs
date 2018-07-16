using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Livraria.ConexaoBD
{
    // Interface para classes CRUD
    public interface ICrudBase<T>
    {
        void Inserir(T entidade);
        void Atualizar(T entidade);
        void Deletar(T entidade);
        T Buscar(int id);
        IList<T> Buscar();
    }
}
