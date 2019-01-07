using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using WASTcnologia.WebAPI.HATEOAS.ResourceBuilder.Interfaces;

namespace WASTcnologia.WebAPI.HATEOAS.Helpers
{
    public class RestResourceBuilder
    {
        public static void BuildResource(object resource, HttpRequestMessage request)
        {
            IEnumerable enumerable = resource as IEnumerable;
            Type dtoType;

            //verifica se enumerable não for nullo, se é um objeto ou uma lista de objetos, e atribui ao dtoType seu tipo atravez do GetType()
            if (enumerable == null)
            {
                dtoType = resource.GetType();
            }
            else
            {
                dtoType = resource.GetType().GetGenericArguments()[0];
            }

            //verifica se dtoType é do tipo(herda) RestResource
            if (dtoType.BaseType != typeof(RestResource))
            {
                throw new ArgumentException($"Era esperado um RestResource e foi informado um {resource.GetType().FullName}");
            }

            //Pega o Assembly correspondente a API
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            IResourceBuilder resourceBuilder =
                //Classe Activator cria instancian de maneira dinamica
                (IResourceBuilder)Activator.CreateInstance(currentAssembly.GetType($"WASTcnologia.WebAPI.HATEOAS.ResourceBuilder.Impl.{dtoType.Name}ResourceBuilder"));

            if (enumerable == null)
            {
                resourceBuilder.BuildResource(resource, request);
            }
            else
            {
                foreach (var item in enumerable)
                {
                    resourceBuilder.BuildResource(item, request);
                }
            }
        }
    }
}