using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class usuarios
    {
        [Key] public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string contrasena { get; set; }
        public string direccion { get; set; }
        public string foto_perfil { get; set; }
        public string rol { get; set; }
        public string estado { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}
