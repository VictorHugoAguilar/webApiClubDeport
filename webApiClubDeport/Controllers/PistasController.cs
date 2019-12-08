using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApiClubDeport.Context;
using webApiClubDeport.Entities;
using webApiClubDeport.Models.PistaModel;
using webApiClubDeport.Object;

namespace webApiClubDeport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PistasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PistasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /**
         * GET: api/pista
         * Obtenemos un enumerable de las pistas
         */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PistaViewModel>>> Get(int numPag = 1, int cantRegist = 5)
        {
            var query = context.Pistas.AsQueryable();
            var totalRegis = query.Count();

            var pista = await query
                                .Skip(cantRegist * (numPag - 1))
                                .Take(cantRegist)
                                .Include(x => x.Deporte).ToListAsync();

            Response.Headers["X-Total-Registros"] = totalRegis.ToString();
            Response.Headers["X-Cantidad-Paginas"] =
                ((int)Math.Ceiling((double)totalRegis / cantRegist)).ToString();
            
            var pistaDto = mapper.Map<List<PistaViewModel>>(pista);

            return pistaDto;
        }

        /**
         * GET: api/pista/{id}
         * Obtener una pista por id
         */
        [HttpGet("{id}", Name = "ObtenerPista")]
        public async Task<ActionResult<PistaViewModel>> Get(int id)
        {

            var pista = await context.Pistas.Include(x => x.Deporte).FirstOrDefaultAsync(x => x.Id == id);

            if (pista == null)
            {
                return NotFound(new Result(404, false, "No se ha encontrado pista con el Id pasado"));
            }

            var pistaDto = mapper.Map<PistaViewModel>(pista);
            return pistaDto;
        }

        /**
         * POST: api/pista
         * Crear una pista pasando por el cuerpo un objeto de la clase pista
         */
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]

        public async Task<ActionResult> Post([FromBody] PistaDto pistaCreated)
        {
            if (pistaCreated.Numero == null || pistaCreated.DeporteId.Equals(0) || pistaCreated.Descripcion == null)
            {
                return NotFound(new Result(404, false, "No se ha pasado el cuerpo con los datos requeridos").GetResultJson());
            }

            var pistaExist = await context.Pistas.FirstOrDefaultAsync(x => x.Numero.ToLower() == pistaCreated.Numero.ToLower());
            if (pistaExist != null)
            {
                return NotFound(new Result(404, false, "Ya existe una pista con ese número ingresado").GetResultJson());
            }

            var pista = mapper.Map<Pista>(pistaCreated);
            context.Add(pista);

            await context.SaveChangesAsync();
            var pistaDto = mapper.Map<PistaViewModel>(pista);

            return new CreatedAtRouteResult("ObtenerPista", new { id = pista.Id }, pistaDto);
        }

        /**
         * PUT: api/pista/{id}
         * Modificar datos de una pista enviando en el cuerpo el objeto de la clase pista
         */
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]

        public async Task<ActionResult> Put(int id, [FromBody] PistaDto pistaActualizada)
        {

            var pista = mapper.Map<Pista>(pistaActualizada);
            pista.Id = id;
            context.Entry(pista).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        /**
         * DELETE: api/pista/{id}
         * Eliminamos una pista pasando por parametros el id de la pista a eliminar
         * 
         */
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]

        public async Task<ActionResult<Pista>> Delete(int id)
        {

            var pistaId = await context.Pistas.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (pistaId == default)
            {
                return NotFound(new Result(404, false, "No se ha encontrado una pista con el id pasado"));
            }

            context.Remove(new Pista { Id = pistaId });
            await context.SaveChangesAsync();
            return NoContent();
        }




    }
}
