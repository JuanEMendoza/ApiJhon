using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class metodos_pago
    {
        [Key] public int id_metodo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
