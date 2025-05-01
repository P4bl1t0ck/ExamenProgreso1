using System.ComponentModel.DataAnnotations;

namespace ExamenProgreso1.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string[] Motivo = { "Vacunacion", "Revision", "Cirugua", "Desparacitacion" }; //Queria ver si podia crear un array que contenga las opciones de la cita
        public int Consulta
        {
            get
            {
                if (Motivo == "Consulta")
                {
                    return 30;
                }
                else if (Motivo == "Revision")
                {
                    return 20;
                }
                else if (Motivo == "Cirugia")
                {
                    return 100;

                }
            }
        }

        
        public string NombreVeterinario { get; set; } 
    }
}
