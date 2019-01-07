using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WASTcnologia.WebAPI.HATEOAS.ResourceBuilder.Interfaces
{
    //devera ser implementada pelas class que irão contruir os RestResource
    interface IResourceBuilder
    {
        //recebera um intancia dos DTOS
        void BuildResource(object resouce, HttpRequestMessage request);
    }
}
