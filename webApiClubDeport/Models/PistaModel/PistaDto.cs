using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using webApiClubDeport.Entities;

namespace webApiClubDeport.Models.PistaModel
{
    public class PistaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(50, ErrorMessage = "La descripción no puede tener mas de 50 carácteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [MinLength(10, ErrorMessage = "La localización debe tener un mínimos de carácteres")]
        public string Localizacion { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int DeporteId { get; set; }
        public Deporte Deporte { get; set; }
        public List<Reserva> Reservas { get; set; }

    }
}
