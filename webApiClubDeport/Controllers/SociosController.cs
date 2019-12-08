using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApiClubDeport.Context;
using webApiClubDeport.Entities;
using webApiClubDeport.Models.SocioModel;
using webApiClubDeport.Object;

namespace webApiClubDeport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SociosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SociosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /**
         *  GET: api/socios
         *  Obtenemos todos los socios
         */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocioViewModel>>> Get(int numPag = 1, int cantRegist = 10)
        {
            var query = context.Socios.AsQueryable();
            var totalRegis = query.Count();

            var socio = await query
                                .Skip(cantRegist * (numPag - 1))
                                .Take(cantRegist)
                                .Include(x => x.Reservas).ToListAsync();

            Response.Headers["X-Total-Registros"] = totalRegis.ToString();
            Response.Headers["X-Cantidad-Paginas"] =
                ((int)Math.Ceiling((double)totalRegis / cantRegist)).ToString();

            var socioViewModel = mapper.Map<List<SocioViewModel>>(socio);

            return socioViewModel;
        }

        /**
       *  GET: api/socios/{id}
       *  Obtenemos un socio por id que pasamos por parametro
       */
        [HttpGet("{id}", Name = "ObtenerSocio")]
        public async Task<ActionResult<SocioViewModel>> Get(int id)
        {
            var socio = await context.Socios.Include(x => x.Reservas).FirstOrDefaultAsync(x => x.Id == id);
            if (socio == null)
            {
                return NotFound(new Result(404, false, "No se ha encontrado socio con el Id pasado").GetResultJson());
            }

            var socioViewModel = mapper.Map<SocioViewModel>(socio);

            return socioViewModel;
        }

        /**
        * POST: api/socio
        * Crear un socio pasando por el cuerpo un objeto de la clase socio
        */
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SocioDto socioCreated)
        {
            if (socioCreated.Nombre == null || socioCreated.Mail == null || socioCreated.Telefono.Equals(0))
            {
                return NotFound(new Result(404, false, "No se ha pasado el cuerpo con los datos requeridos").GetResultJson());
            }

            var socioExistMail = context.Socios
                .FirstOrDefault(x => x.Mail.Trim().ToLower() == socioCreated.Mail.Trim().ToLower());
            if (socioExistMail != null)
            {
                return NotFound(new Result(404, false, "Ya se ha registrado un socio con el mail pasado").GetResultJson());
            }

            var socioExistTel = context.Socios
                .FirstOrDefault(x => x.Telefono == socioCreated.Telefono);
            if (socioExistTel != null)
            {
                return NotFound(new Result(404, false, "Ya se ha registrado un socio con el teléfono pasado").GetResultJson());
            }

            var socio = mapper.Map<Socio>(socioCreated);
            context.Add(socio);
            await context.SaveChangesAsync();
            var socioDto = mapper.Map<SocioDto>(socio);

            return new CreatedAtRouteResult("ObtenerSocio", new { id = socio.Id }, socioDto);
        }

        /**
         * PUT: api/pista/{id}
         * Modificar datos de una pista enviando en el cuerpo el objeto de la clase pista
         */
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SocioDto socioActualizado)
        {
            var socio = mapper.Map<Socio>(socioActualizado);
            socio.Id = id;
            context.Entry(socio).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        /**
         * DELETE: api/pista/{id}
         * Eliminamos una pista pasando por parametros el id de la pista a eliminar
         * 
         */
        [HttpDelete("{id}")]
        public async Task<ActionResult<Socio>> Delete(int id)
        {
            var socioId = await context.Socios.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);
            if (socioId == default)
            {
                return NotFound(new Result(404, false, "No se ha encontrado un socio con el id pasado").GetResultJson());
            }

            context.Remove(new Socio { Id = socioId });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
