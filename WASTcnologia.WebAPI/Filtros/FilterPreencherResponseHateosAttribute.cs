using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using WASTcnologia.WebAPI.HATEOAS.Helpers;

namespace WASTcnologia.WebAPI.Filtros
{
    public class FilterPreencherResponseHateosAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //HATEOS só sera utilizado caso tenho sido obtido status de sucesso no processamento
            if (actionExecutedContext.Response.IsSuccessStatusCode &&
                //verifica se contem a  palavra hal(Hipermedia Application Language) no cabeçalho da requisição
                //o Header tem que ver enviado dessa forma: key: Accept value: "application/hal+json"
                actionExecutedContext.Request.Headers.SelectMany(s => s.Value).Any(a => a.Contains("hal")))
            {
                ObjectContent reponseContent = actionExecutedContext.Response.Content as ObjectContent;
                object responseValue = reponseContent.Value;
                RestResourceBuilder.BuildResource(responseValue, actionExecutedContext.Request);
            }            
        }
    }
}