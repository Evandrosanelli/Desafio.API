using Desafio.API.Enuns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.API.Entities
{
    public class Entrega
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [ForeignKey("Pedido")]
        public long PedidoId { get; set; }
        [Required]
        [ForeignKey("Drone")]
        public long DroneId { get; set; }
        
    }
}
