using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string DataNascimento { get; set; }

    }
}