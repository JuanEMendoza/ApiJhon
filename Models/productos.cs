using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class productos
    {
        [Key]  public int id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public string categoria { get; set; }
        public string imagen { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string estado { get; set; }
    }
}
