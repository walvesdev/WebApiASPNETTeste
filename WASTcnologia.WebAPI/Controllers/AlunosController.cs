using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WASTcnologia.AcessoDados.EF.Context;
using WASTcnologia.AcessoDados.EF.Repositorios;
using WASTcnologia.Dominio;

namespace WASTcnologia.WebAPI.Controllers
{
    public class AlunosController : ApiController
    {
        private IRepositorio<Aluno, int> _repositorioAlunos = new RepositorioAlunos(new WebApiDbContext());

        public IEnumerable<Aluno> Get()
        {
           return  _repositorioAlunos.Selecionar();
        }
        public Aluno Get(int? id)
        {
            return _repositorioAlunos.SelecionarPorId((int)id);
        }
    }
}
