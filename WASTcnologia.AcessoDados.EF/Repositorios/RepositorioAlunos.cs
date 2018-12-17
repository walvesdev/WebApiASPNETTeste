using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WASTcnologia.AcessoDados.EF.Context;
using WASTcnologia.Dominio;

namespace WASTcnologia.AcessoDados.EF.Repositorios
{
    public class RepositorioAlunos : Repositorio<Aluno, int>
    {
        public RepositorioAlunos(WebApiDbContext banco): base(banco)
        {

        }
    }
}
