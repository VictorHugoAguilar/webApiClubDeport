using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApiClubDeport.Entities
{
    public class Socio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede contener mas de 50 carácteres.")]
        public string Nombre { get; set; }
        [StringLength(50, ErrorMessage = "El nombre no puede contener mas de 50 carácteres.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [EmailAddress]
        public string Mail { get; set; }
        public Boolean Baja { get; set; }
        public List<Reserva> Reservas { get; set; }
    }
}
