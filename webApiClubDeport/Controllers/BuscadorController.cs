using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using webApiClubDeport.Context;
using webApiClubDeport.Models.PistaModel;
using webApiClubDeport.Object;
using webApiClubDeport.Services;

namespace webApiClubDeport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscadorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public BuscadorController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<PistaDispViewModel>>> Get([FromBody] PistaBuscar pistaBuscar) {

            if (pistaBuscar.Deporte == null || pistaBuscar.Socio == null) {
                return NotFound(new Result(404, false, "No ha introducido los parámetros necesarios").GetResultJson());
            }

            var deportExist = await context.Deportes.FirstOrDefaultAsync(x => x.Nombre.Trim().ToLower() == pistaBuscar.Deporte.Trim().ToLower());
            if (deportExist == null)
            {
                return NotFound(new Result(404, false, "El deporte ingresado no existe en la BD").GetResultJson());
            }

            var pistaExist = await context.Pistas.FirstOrDefaultAsync(x => x.Deporte.Nombre.Trim().ToLower() == pistaBuscar.Deporte.Trim().ToLower());
            if (pistaExist == null)
            {
                return NotFound(new Result(404, false, "No existen pistas en la BD para el deporte ingresado").GetResultJson());
            }

            var pistas = await UtilPista.GetPistaDisponible(context, pistaBuscar);
            if (pistas == null)
            {
                return NoContent();
            }

            List<PistaDispViewModel> lista = new List<PistaDispViewModel>();

            foreach (var pista in pistas)
            {
                PistaDispViewModel pistaDisp = new PistaDispViewModel
                {
                    Numero = pista.Key.Numero,
                    Descripcion = pista.Key.Descripcion,
                    Localizacion = pista.Key.Localizacion,
                    DeporteNombre = pista.Key.Deporte.Nombre,
                    HorasDisponibles = pista.Value
                };
                lista.Add(pistaDisp);
            }
                      
            return Ok(lista);
        } 
    }
}
