using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WASTcnologia.AcessoDados.EF.Repositorios
{
    public abstract class Repositorio<T, TChave> : IRepositorio<T, TChave>, IDisposable where T : class
    {
        protected DbContext _banco;

        public Repositorio(DbContext banco)
        {
            this._banco = banco;
        }

        public void Atualizar(T entidade)
        {
            _banco.Entry(entidade).State = EntityState.Modified;
            _banco.SaveChanges();
        }

        public void Dispose()
        {
            _banco.Dispose();
        }

        public void Excluir(T entidade)
        {
            _banco.Entry(entidade).State = EntityState.Deleted;
            _banco.SaveChanges();
        }

        public void ExcluirPorId(TChave id)
        {
            T entidade = SelecionarPorId(id);
            Excluir(entidade);
        }

        public void Inserir(T entidade)
        {
            _banco.Set<T>().Add(entidade);
            _banco.SaveChanges();
        }

        public List<T> Selecionar(Expression<Func<T, bool>> where = null)
        {
            DbSet<T> dbset = _banco.Set<T>();
            if (where == null)
            {
                return dbset.ToList();
            }
            else
            {
                return dbset.Where(where).ToList();
            }
        }

        public T SelecionarPorId(TChave id)
        {
            return _banco.Set<T>().Find(id);
        }
    }
}
