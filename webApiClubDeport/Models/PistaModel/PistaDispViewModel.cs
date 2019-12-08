using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApiClubDeport.Models.PistaModel
{
    public class PistaDispViewModel
    {
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public string Localizacion { get; set; }

        [Display(Name = "Deporte")]
        public string DeporteNombre { get; set; }

        public List<int> HorasDisponibles { get; set; }

    }
}
