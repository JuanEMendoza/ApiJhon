using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class pedidos
    {
        [Key] public int id_pedido { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha_pedido { get; set; }
        public decimal total { get; set; }
        public string estado { get; set; }
        public string direccion_envio { get; set; }
        public int? id_metodo { get; set; }
    }
}
