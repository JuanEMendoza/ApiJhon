using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class carrito_detalle
    {
        [Key] public int id_detalle { get; set; }
        public int id_carrito { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }
    }
}
