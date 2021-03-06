﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASTcnologia.Dominio
{
    [Table("Aluno", Schema = "dbo")]
    public class Aluno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatorio")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "O nome de ve conter entre 5 e 100 caracteras!")]
        public string  Nome { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatorio")]
        [MaxLength(100, ErrorMessage = "O endereço pode conter no maximo 100 caracteres!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "A mensalidade é obrigatorio")]
        [Range(0.01, 9999.99, ErrorMessage = "A mensalidade deve estar entre R$0.01 e R$9999.99")]
        public decimal Mensalidade { get; set; }
    }
}
