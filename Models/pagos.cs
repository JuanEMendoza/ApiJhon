using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class pagos
    {
        [Key] public int id_pago { get; set; }
        public int id_pedido { get; set; }
        public decimal monto { get; set; }
        public DateTime fecha_pago { get; set; }
        public string metodo { get; set; }
        public string referencia { get; set; }
        public string estado { get; set; }
    }
}
