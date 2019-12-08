using System.Collections.Generic;
using webApiClubDeport.Entities;

namespace webApiClubDeport.Models.Deportes
{
    public class DeporteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Pista> Pistas { get; set; }
    }
}
