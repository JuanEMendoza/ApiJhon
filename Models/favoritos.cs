using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class favoritos
    {
        [Key] public int id_favorito { get; set; }
        public int id_usuario { get; set; }
        public int id_producto { get; set; }
        public DateTime fecha_agregado { get; set; }
    }
}
