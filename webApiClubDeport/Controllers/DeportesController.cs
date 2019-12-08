using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using webApiClubDeport.Context;
using AutoMapper;
using webApiClubDeport.Entities;
using Microsoft.EntityFrameworkCore;
using webApiClubDeport.Models.Deportes;
using webApiClubDeport.Object;
using System.Linq;
using System;

namespace webApiClubDeport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="admin")]
    public class DeportesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DeportesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        /**
         * GET: api/deportes
         * Obtenemos un enumerado de deportes
         */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeporteViewModel>>> Get(int numPag = 1, int cantRegist = 10)
        {
            var query = context.Deportes.AsQueryable();
            var totalRegis = query.Count();

            var deportes = await query
                .Skip(cantRegist * (numPag - 1))
                .Take(cantRegist)
                .Include(x => x.Pistas).ToListAsync();

            Response.Headers["X-Total-Registros"] = totalRegis.ToString();
            Response.Headers["X-Cantidad-Paginas"] =
                ((int)Math.Ceiling((double)totalRegis / cantRegist)).ToString();

            var deportesDto = mapper.Map<List<DeporteViewModel>>(deportes);

            return deportesDto;
        }

        /**
         * Get: api/deportes/{id}
         */
        [HttpGet("{id}", Name = "ObtenerDeporte")]
        public async Task<ActionResult<DeporteViewModel>> Get(int id)
        {
            var deporte = await context.Deportes.Include(x => x.Pistas).FirstOrDefaultAsync(x => x.Id == id);
            if (deporte == null)
            {
                return NotFound(new Result(404, false, "No se ha encontrado deporte con el id asociado"));
            }

            var deporteDto = mapper.Map<DeporteViewModel>(deporte);

            return deporteDto;
        }

        /**
         * POST: api/deportes
         * Cuerpo: { id, nombre }
         * Añadimos un deporte
         */
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DeporteDto deporteCreate)
        {
            if (deporteCreate.Nombre == null)
            {
                return NotFound(new Result(404, false, "No se ha pasado el cuerpo con los datos requeridos").GetResultJson());
            }

            var deportExist = await context.Deportes.FirstOrDefaultAsync(x => x.Nombre.ToLower() == deporteCreate.Nombre.ToLower());
            if (deportExist != null)
            {
                return NotFound(new Result(404, false, "Ya existe un deporte con el nombre ingresado").GetResultJson());
            }

            var deporte = mapper.Map<Deporte>(deporteCreate);
            context.Add(deporte);
            await context.SaveChangesAsync();

            return Ok(new Result(201, true, "Deporte creado satisfatoriamente").GetResultJson());
        }



        /**
         * Put: api/deportes/{id}
         * Modificar un deporte
         */
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DeporteDto deporteDto)
        {
            var deporte = mapper.Map<Deporte>(deporteDto);

            deporte.Id = id;
            context.Entry(deporte).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        /**
         * Delete: api/deportes/{id}
         * Eliminar un deporte
        */
        [HttpDelete("{id}")]
        public async Task<ActionResult<Deporte>> Delete(int id)
        {
            var deporteId = await context.Deportes.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);
            if (deporteId == default)
            {
                return NotFound(new Result(404, false, "No existe deporte con el Id pasado"));
            }

            context.Remove(new Deporte { Id = deporteId });
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
