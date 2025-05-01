using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenProgreso1.Models
{
    public class Dueno
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]//El nombre mas largo del mundo tiene 85 caracteres.
        public string Nombre { get; set; }
        [EmailAddress]
        [Required(ErrorMessage ="Nesecario el correo señor porfavor.")]
        public string Correo { get; set; }
        //Foreing Key
        public int CitaId { get; set; }
        [ForeignKey("CitaId")]
        public Cita?  Cita { get; set; }
    }
}
