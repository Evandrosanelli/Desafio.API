using Desafio.API.Enuns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.API.Entities
{
    public class Pedido
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public decimal Longitude { get; set; }
        [Required]
        [ForeignKey("StatusPedido")]
        public StatusPedidoEnum StatusPedidoId { get; set; }
    }
}
