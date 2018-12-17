using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WASTcnologia.Dominio;

namespace WASTcnologia.AcessoDados.EF.Context
{
    public class WebApiDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        public WebApiDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
    }
}
