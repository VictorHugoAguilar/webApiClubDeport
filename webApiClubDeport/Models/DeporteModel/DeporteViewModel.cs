using System.Collections.Generic;
using webApiClubDeport.Models.PistaModel;

namespace webApiClubDeport.Models.Deportes
{
    public class DeporteViewModel
    {
        public string Nombre { get; set; }
        /**
         * Vamos a instanciar solo las descripciones que tenemos en PistaViewModel
         */
        public List<PistaViewModel> Pistas { get; set; }
                
    }
}
