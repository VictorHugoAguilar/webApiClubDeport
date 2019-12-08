using System.Collections.Generic;
using webApiClubDeport.Entities;

namespace webApiClubDeport.Models.PistaModel
{
    public class PistaDto
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public string Localizacion { get; set; }
        public int DeporteId { get; set; }
        public Deporte Deporte { get; set; }
        public List<Reserva> Reservas { get; set; }

    }
}
