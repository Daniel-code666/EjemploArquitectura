using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entitites
{
    public class TblCreableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime fecha_creacion { get; protected set; } = ServerSettings.ObtenerFechaReal();
        public DateTime fecha_modificacion { get; set; }
    }
}
