using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;
using WASTcnologia.WebAPI.DTOs;
using WASTcnologia.WebAPI.HATEOAS.ResourceBuilder.Interfaces;

namespace WASTcnologia.WebAPI.HATEOAS.ResourceBuilder.Impl
{
    public class AlunoDTOResourceBuilder : IResourceBuilder
    {
        public void BuildResource(object resouce, HttpRequestMessage request)
        {
            //Operador "as" representa um "cast" silencioso;
            AlunoDTO dto = resouce as AlunoDTO;

            if (dto == null)
            {
                throw new ArgumentException($"Era esperado um AlunoDTO mas foi encontrado um {resouce.GetType().Name}");
            }

            //monta os links de acordo com s configurações de rotas do WebApiConfig recebendo a requisição atual;
            UrlHelper urlHelper = new UrlHelper(request);

            //string representando a rota de acordo com as configurações de rotas do WebApiConfig
            string alunoDTORoute = urlHelper.Link("DefaultApi", new { controller = "Alunos", id = dto.Id });

            //links vinculados ao RestResource( podem ser adicionados qnts links forem necessaio)
            dto.Links.Add(new RestLink
            {
                //recupera o proprio DTO
                Rel = "Self",
                //GET por Id
                Href = alunoDTORoute
            });
            dto.Links.Add(new RestLink
            {
                //recupera o proprio DTO
                Rel = "edit",
                //GET por Id
                Href = alunoDTORoute
            });
            dto.Links.Add(new RestLink
            {
                //recupera o proprio DTO
                Rel = "delete",
                //GET por Id
                Href = alunoDTORoute
            });

        }
    }
}