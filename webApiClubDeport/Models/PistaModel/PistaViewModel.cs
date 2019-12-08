using System.ComponentModel.DataAnnotations;

namespace webApiClubDeport.Models.PistaModel
{
    public class PistaViewModel
    {
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public string Localizacion { get; set; }

        /**
         * Display(Name ="XXX") 
         * Lo utilizamos para mapear del objeto Deporte en este caso
         * solo la propiedad del nombre
         */
        [Display(Name = "Deporte")]
        public string DeporteNombre { get; set; }
    }
}
