
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WASTcnologia.WebAPI.HATEOAS
{
    //estrutura que representa o processo de links do HATEOS
    public class RestLink
    {
        //Recuperar os elementos do Link, representa o porque esse link esta sendo criado, qual sua utilidade..
        public string Rel { get; set; }
        //Rota, link que vai prover o serviço de Rel
        public string Href { get; set; }

        public int MyProperty { get; set; }
    }
}