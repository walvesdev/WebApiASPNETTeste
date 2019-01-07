using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WASTcnologia.WebAPI.HATEOAS
{
    //Recurso que será restornada pela api, deve ser herdado pelos DTOs
    public abstract class RestResource
    {
        public List<RestLink> Links { get; set; } = new List<RestLink>();

    }
}