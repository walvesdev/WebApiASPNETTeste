using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WASTcnologia.Dominio;
using WASTcnologia.WebAPI.DTOs;

namespace WASTcnologia.WebAPI.AutoMapper
{
    // Padrão Singleton (Unica instacia para todo o sistema)


    public class AutoMapperManager
    {
        private static readonly Lazy<AutoMapperManager> _instance = new Lazy<AutoMapperManager>(() =>
        {
            return new AutoMapperManager(); 
        });

        public static AutoMapperManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private MapperConfiguration _config;

        public IMapper Mapper
        {
            get
            {
                return _config.CreateMapper();
            }
        }

        private AutoMapperManager()
        {
            _config = new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<Aluno, AlunoDTO>();
                cfg.CreateMap<AlunoDTO, Aluno>();

            });
        }
    }
}