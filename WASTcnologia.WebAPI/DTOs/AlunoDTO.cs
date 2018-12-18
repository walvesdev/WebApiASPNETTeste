﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WASTcnologia.WebAPI.DTOs
{
    public class AlunoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatorio")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "O nome de ve conter entre 5 e 100 caracteras!")]
        public string Nome { get; set; }

        [MaxLength(100, ErrorMessage = "O endereço pode conter no maximo 100 caracteres!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "A mensalidade é obrigatorio")]
        [Range(0.01, 9999.99, ErrorMessage = "A mensalidade deve estar entre R$0.01 e R$9999.99")]
        public decimal Mensalidade { get; set; }


    }
}