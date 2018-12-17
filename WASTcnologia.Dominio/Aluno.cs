using System;
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
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string  Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }

        [Required]
        public decimal Mensalidade { get; set; }
    }
}
