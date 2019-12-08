using System;
using System.ComponentModel.DataAnnotations;
using webApiClubDeport.Entities;

namespace webApiClubDeport.Models.ReservaModel
{
    public class ReservaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Range(8, 22, ErrorMessage = "La hora esta fuera del rango permitido")]
        public int Hora { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int SocioId { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int PistaId { get; set; }
        public Socio Socio { get; set; }
        public Pista Pista { get; set; }
    }
}
