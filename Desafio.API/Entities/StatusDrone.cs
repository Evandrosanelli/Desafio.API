using System.ComponentModel.DataAnnotations;

namespace Desafio.API.Entities
{
    public class StatusDrone
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
