using System;
using System.Collections.Generic;
using webApiClubDeport.Models.ReservaModel;

namespace webApiClubDeport.Models.SocioModel
{
    public class SocioViewModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Mail { get; set; }
        public List<ReservaViewModel> Reservas { get; set; }
    }
}
