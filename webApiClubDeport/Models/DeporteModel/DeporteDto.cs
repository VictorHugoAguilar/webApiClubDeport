using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using webApiClubDeport.Models.PistaModel;

namespace webApiClubDeport.Models.Deportes
{
    public class DeporteDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [MinLength(5, ErrorMessage = "El nombre del deporte tiene que contener más 5 carácteres")]
        [MaxLength(50, ErrorMessage = "El nombre del deporte no puede tener más de 50 carácteres")]
        public string Nombre { get; set; }
        public List<PistaDto> Pistas { get; set; }
    }
}
