using System;
using webApiClubDeport.Entities;

namespace webApiClubDeport.Models.ReservaModel
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Hora { get; set; }
        public int SocioId { get; set; }
        public int PistaId { get; set; }
        public Socio Socio { get; set; }
        public Pista Pista { get; set; }
    }
}
