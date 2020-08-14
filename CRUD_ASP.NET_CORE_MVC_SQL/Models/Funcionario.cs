using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_ASP.NET_CORE_MVC_SQL.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cidade { get; set; }
        public string Departamento { get; set; }
        [Required]
        public string Sexo { get; set; }
    }
}
