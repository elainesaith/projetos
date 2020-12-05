using System;
using System.ComponentModel.DataAnnotations;

namespace ApiTeste.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [MinLength(10, ErrorMessage = "Nome do evento deve conter entre 10 e 100 caracteres")]
        [MaxLength(100, ErrorMessage = "Nome do evento deve conter entre 10 e 100 caracteres")]
        public string NomeEvento { get; set; }

        [MaxLength(1000, ErrorMessage = "Descrição do evento deve conter, no máximo, 1000 caracteres")]
        public string DescricaoEvento { get; set; }

        [Required(ErrorMessage = "Data do evendo deve ser informada")]
        public DateTime DataEvento { get; set; }
    }
}
