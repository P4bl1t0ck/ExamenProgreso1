using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace ExamenProgreso1.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        public DateTime cumple { get; set; }
        [StringLength(60,ErrorMessage ="No mas de 60 digitos el aspecto de la mascota")]
        public string aspecto { get; set; }
        public string pablomontalvo { get; set; }
        public int DuenoId { get; set; }
        [ForeignKey("DuenoId")]
        public Dueno? Dueno { get; set; }


    }
}
