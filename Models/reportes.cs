using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class reportes
    {
        [Key] public int id_reporte { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_generacion { get; set; }
        public int? generado_por { get; set; }
    }
}
