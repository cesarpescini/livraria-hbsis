using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ConexaoBD
{
    // Classe que implementar a interface ICrudBase
    public class DaoGenerico<T> : ICrudBase<T> where T : class
    {
        public void Atualizar(T entidade)
        {
            using (ISession _session = NHibernateConexao.OpenSession())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Update(entidade);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                            throw new Exception("Erro ao atualizar: " + ex.Message);
                        }
                    }
                }
            }
        }

        public T Buscar(int id)
        {
            using (ISession _session = NHibernateConexao.OpenSession())
            {
                return _session.Get<T>(id);
            }
        }

        public IList<T> Buscar()
        {
            using (ISession _session = NHibernateConexao.OpenSession())
            {
                return (from rs in _session.Query<T>() select rs).ToList();
            }
        }

        public void Deletar(T entidade)
        {
            using (ISession _session = NHibernateConexao.OpenSession())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Delete(entidade);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                            throw new Exception("Erro ao Deletar: " + ex.Message);
                        }

                    }
                }
            }
        }

        public void Inserir(T entidade)
        {
            using (ISession _session = NHibernateConexao.OpenSession())
            {

                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Save(entidade);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                            throw new Exception("Erro ao salvar: " + ex.Message);
                        }
                    }
                }

            }
        }
    }
}
