using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entitites
{
    [Table("users")]
    public class TblUsersEntity : TblCreableEntity
    {
        [Key]
        public Guid id_user { get; set; }
        public string username { get; set; } = string.Empty;
        public string user_dni { get; set; } = string.Empty;
        public string user_email { get; set; } = string.Empty;
        public string user_password { get; set; } = string.Empty;
        public bool activo { get; set; }
    }
}
