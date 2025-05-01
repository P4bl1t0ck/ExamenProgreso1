using System.ComponentModel.DataAnnotations;

namespace ExamenProgreso1.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese una fecha")]
        public DateTime Fecha { get; set; }
   
        public string Hora { get; set; }
        public string[] Descripcion = { "Consulta", "Urgencia", "Vacunacion", "Desparacitacion" };
        public int Consulta
        {
            get
            {
                if (Descripcion[0] == "Consulta")
                {
                    return 1;
                }
                else if (Descripcion[1] == "Urgencia")
                {
                    return 2;
                }
                else if (Descripcion[2] == "Vacunacion")
                {
                    return 3;
                }
                else if (Descripcion[3] == "Desparacitacion")
                {
                    return 4;
                }
                else
                {
                    return 0;
                }
            }
        }
        [StringLength(150,ErrorMessage = "No mas de 150 caractares por descripcion de malestar dle paciente!.")]
        public string razon { get; set; }

        public string NombreVeterinario { get; set; } 
    }
}
