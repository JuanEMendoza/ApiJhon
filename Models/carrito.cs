using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class carrito
    {
        [Key] public int id_carrito { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha_actualizacion { get; set; }
    }
}
