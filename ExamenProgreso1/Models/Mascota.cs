using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenProgreso1.Models
{
    public class Mascota
    {
        [Key]
       public int Id { get; set; }
       public string Nombre { get; set; }
       public DateTime cumple { get; set; }
        public string pablomontalvo { get; set; }
        public string DuenoId { get; set; }
        [ForeignKey("DuenoId")]
        public Dueno Dueno { get; set; }


    }
}
