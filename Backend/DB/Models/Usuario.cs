using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;

namespace DB.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("usuarioid")]
        public int UsuarioID { get; set; }

        [Column("nombre")]
        public string? Nombre { get; set; } = null;

        [Column("apellido")]
        public string? Apellido { get; set; } = null;

        [Column("email")]
        public string? Email { get; set; } = null;
        [Column("telefono")]
        public string? Telefono { get; set; } = null;
        [Column("password")]
        public string? Password { get; set; } = null;

        [Column("idperfil")]
        public int PerfilID { get; set; }

    }
}
