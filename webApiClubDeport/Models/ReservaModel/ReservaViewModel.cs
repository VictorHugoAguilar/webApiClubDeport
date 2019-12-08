using System;
using System.ComponentModel.DataAnnotations;

namespace webApiClubDeport.Models.ReservaModel
{
    public class ReservaViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Hora { get; set; }
        [Display(Name="Nombre")]
        public string SocioNombre { get; set; }
        [Display(Name = "Mail")]
        public string SocioMail { get; set; }
        [Display(Name = "Numero")]
        public string PistaNumero { get; set; }
        [Display(Name = "Localizacion")]
        public string PistaLocalizacion { get; set; }
    }
}
