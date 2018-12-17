using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WASTcnologia.AcessoDados.EF.Repositorios
{
    public interface IRepositorio<T, TChave> where T : class
    {
        List<T> Selecionar(Expression<Func<T, bool>> where = null);
        T SelecionarPorId(TChave id);
        void Inserir(T etidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);
        void ExcluirPorId(TChave id);

    }
}
