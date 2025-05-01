using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenProgreso1.Models
{
    public class Dueno
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        //Foreing Key
        public int CitaId { get; set; }
        [ForeignKey("CitaId")]
        public Cita?  Cita { get; set; }
    }
}
