using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WASTcnologia.WebAPI.FormatadoresMediTypes;

namespace WASTcnologia.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            //Configuarações da formatação do Json
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                //Coloca o Json para iniciar com letras minusculas
                ContractResolver = new CamelCasePropertyNamesContractResolver(),

                //Ignora valores nulos enviados via Json
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore

            };
            //registrandi o tipo csv (CsvMediaTypeFormatter)
            config.Formatters.Add(new CsvMediaTypeFormatter());

            //Remove a resposta em xml da api
            //var xmlFormatter = config.Formatters.XmlFormatter;
            //config.Formatters.Remove(xmlFormatter);


            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
