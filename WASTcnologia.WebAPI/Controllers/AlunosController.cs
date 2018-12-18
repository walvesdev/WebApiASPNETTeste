using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WASTcnologia.AcessoDados.EF.Context;
using WASTcnologia.AcessoDados.EF.Repositorios;
using WASTcnologia.Dominio;
using WASTcnologia.WebAPI.AutoMapper;
using WASTcnologia.WebAPI.DTOs;
using WASTcnologia.WebAPI.Filtros;

namespace WASTcnologia.WebAPI.Controllers
{
    public class AlunosController : ApiController
    {
        private IRepositorio<Aluno, int> _repositorioAlunos = new RepositorioAlunos(new WebApiDbContext());

        /*Implementação WebApi 1.0 (HttpResponseMessage)
        public IEnumerable<Aluno> Get()
        {
           return  _repositorioAlunos.Selecionar();
        }*/

        /*Implementação WebApi 1.0 (HttpResponseMessage)
        public HttpResponseMessage Get(int? id)
        {
            if (!id.HasValue)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            Aluno aluno = _repositorioAlunos.SelecionarPorId((int)id);
            if (aluno == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Found, aluno);
        }*/

        //Implementação WebApi 2.0 (IHttpActionResult) Async Exemplo AutoMapper
        public IHttpActionResult Get()
        {
            List<Aluno> alunos = _repositorioAlunos.Selecionar();
            List<AlunoDTO> dtos = AutoMapperManager.Instance.Mapper.Map<List<Aluno>, List<AlunoDTO>>(alunos);
           return  Ok(dtos);
        }

        //Implementação WebApi 2.0 (IHttpActionResult) Async
        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            Aluno aluno = _repositorioAlunos.SelecionarPorId((int)id);
            if (aluno == null)
            {
                return NotFound();
            }
            return Content(HttpStatusCode.Found, aluno);
        }

        //Implementação WebApi 2.0 (IHttpActionResult) Async
        [ValidacaoModeState] //Filtro de Validação if (!ModelState.IsValid)
        public IHttpActionResult Post([FromBody]Aluno aluno)
        {           
                try
                {
                    _repositorioAlunos.Inserir(aluno);
                    return Created($"{Request.RequestUri}/{aluno.Id}", aluno);
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }           
            
        }

        [ValidacaoModeState]
        public IHttpActionResult Put(int? id, [FromBody]Aluno aluno)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }

                aluno.Id = id.Value;
                _repositorioAlunos.Atualizar(aluno);

                return Ok();
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }
        }

        [ValidacaoModeState]
        public IHttpActionResult Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }

                Aluno aluno = _repositorioAlunos.SelecionarPorId(id.Value);

                if (aluno == null)
                {
                    return NotFound();
                }
                _repositorioAlunos.ExcluirPorId(id.Value);

                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }


        }

    }
}
