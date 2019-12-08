using System;
using System.Collections.Generic;
using webApiClubDeport.Entities;

namespace webApiClubDeport.Models.SocioModel
{
    public class SocioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Mail { get; set; }
        public Boolean Baja { get; set; }
        public List<Reserva> Reservas { get; set; }
    }
}
