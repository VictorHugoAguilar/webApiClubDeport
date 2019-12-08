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
using webApiClubDeport.Models.ReservaModel;
using webApiClubDeport.Object;
using webApiClubDeport.Services;

namespace webApiClubDeport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ReservasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /**
         * GET: api/reservas
         * Obtenemos un enumerable de las pistas
         */
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<ReservaViewModel>>> Get(int numPag = 1, int cantRegist = 5)
        {
            var query = context.Reservas.AsQueryable();
            var totalRegis = query.Count();

            var reservas = await query
                                .Skip(cantRegist * (numPag - 1))
                                .Take(cantRegist)
                                .Include(x => x.Pista).Include(x => x.Socio).ToListAsync();

            Response.Headers["X-Total-Registros"] = totalRegis.ToString();
            Response.Headers["X-Cantidad-Paginas"] =
                ((int)Math.Ceiling((double)totalRegis / cantRegist)).ToString();

            var reservasViewModel = mapper.Map<List<ReservaViewModel>>(reservas);

            return reservasViewModel;
        }

        /**
         * GET: api/reserva/{id}
         * Devuelve el listado de reservas para la fecha pasada por el cuerpo 
         */
        [HttpGet("{id}", Name = "obtenerReserva")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<ReservaViewModel>>> Get(int id)
        {
            var reservas = await context.Reservas.Include(x => x.Pista).Include(x => x.Socio)
                            .Where(x => x.Id == id).ToListAsync();
            if (!reservas.Any())
            {
                return NotFound(new Result(404, false, "No hay reservas asociadas al id").GetResultJson());
            }

            var reservaViewModel = mapper.Map<List<ReservaViewModel>>(reservas);

            return reservaViewModel;
        }


        /**
         * GET: api/reserva/{fecha}
         * Devuelve el listado de reservas para la fecha pasada por el cuerpo 
         */
        [HttpGet("obtenerReservasFecha", Name = "obtenerReservasFecha")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<ReservaViewModel>> Get([FromBody]FechaDto fechaBuscar, int numPag = 1, int cantRegist = 5)
        {
            var query = context.Reservas.AsQueryable();
            var totalRegist = query.Count();

            var reservas = query
                            .Skip(cantRegist * (numPag - 1))
                            .Take(cantRegist)
                            .Include(x => x.Pista).Include(x => x.Socio)
                            .Where(x => x.Fecha.Equals(fechaBuscar.Fecha)).ToList();

            if (!reservas.Any())
            {
                return NotFound(new Result(404, false, "No hay reservas para la fecha solicitada").GetResultJson());
            }

            Response.Headers["X-Total-Registros"] = totalRegist.ToString();
            Response.Headers["X-Cantidad-Paginas"] =
                ((int)Math.Ceiling((double)totalRegist / cantRegist)).ToString();

            var reservaViewModel = mapper.Map<List<ReservaViewModel>>(reservas);

            return reservaViewModel;
        }


        /**
         * POST: api/reserva
         * Crear una reserva pasandole en el cuerpo los datos
         */
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post([FromBody] ReservaDto reservaCreated)
        {
            if (reservaCreated.Hora < 8 || reservaCreated.Hora > 22)
            {
                return NotFound(new Result(404, false, "La hora pasada esta fuera del rango de horas de reservas").GetResultJson());
            }

            var socio = await context.Socios.FirstOrDefaultAsync(x => x.Id == reservaCreated.SocioId);
            if (socio == null)
            {
                return NotFound(new Result(404, false, "No se ha introducido un id Socio válido").GetResultJson());
            }

            var pista = await context.Pistas.FirstOrDefaultAsync(x => x.Id == reservaCreated.PistaId);
            if (pista == null)
            {
                return NotFound(new Result(404, false, "No se ha introducido un id Pista válido").GetResultJson());
            }

            if (UtilReservas.GetReservasSocio(context, reservaCreated).Count() > 2)
            {
                return NotFound(new Result(404, false, "No se permite más de 3 reservas al día para un socio").GetResultJson());
            }

            if (UtilReservas.GetReservaPistaHora(context, reservaCreated).Any())
            {
                return NotFound(new Result(404, false, "La pista esta reservada ya").GetResultJson());
            }

            if (UtilReservas.GetReservaSocioHora(context, reservaCreated).Any())
            {
                return NotFound(new Result(404, false, "El socio ya tiene una pista a esa hora").GetResultJson());
            }

            var reserva = mapper.Map<Reserva>(reservaCreated);
            context.Add(reserva);

            await context.SaveChangesAsync();
            var reservaViewModel = mapper.Map<ReservaViewModel>(reserva);

            return new CreatedAtRouteResult("ObtenerSocio", new { id = reserva.Id }, reservaViewModel);
        }


        /**
         * PUT: api/reserva
         * Modificar una reserva pasandole en el cuerpo los datos
         */
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put(int id, [FromBody] ReservaDto reservaModificated)
        {
            if (reservaModificated.Hora < 8 || reservaModificated.Hora > 22)
            {
                return NotFound(new Result(404, false, "La hora pasada esta fuera del rango de horas de reservas").GetResultJson());
            }

            var socio = await context.Socios.FirstOrDefaultAsync(x => x.Id == reservaModificated.SocioId);
            if (socio == null)
            {
                return NotFound(new Result(404, false, "No se ha introducido un id Socio válido").GetResultJson());
            }

            var pista = await context.Pistas.FirstOrDefaultAsync(x => x.Id == reservaModificated.PistaId);
            if (pista == null)
            {
                return NotFound(new Result(404, false, "No se ha introducido un id Pista válido").GetResultJson());
            }

            if (UtilReservas.GetReservasSocio(context, reservaModificated).Count() > 2)
            {
                return NotFound(new Result(404, false, "No se permite más de 3 reservas al día para un socio").GetResultJson());
            }

            if (UtilReservas.GetReservaPistaHora(context, reservaModificated).Any())
            {
                return NotFound(new Result(404, false, "La pista esta reservada ya").GetResultJson());
            }

            if (UtilReservas.GetReservaSocioHora(context, reservaModificated).Any())
            {
                return NotFound(new Result(404, false, "El socio ya tiene una pista a esa hora").GetResultJson());
            }

            var reserva = mapper.Map<Reserva>(reservaModificated);
            reserva.Id = id;
            context.Entry(reserva).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        /**
         * DELETE: api/reserva/{id}
         * Eliminamos una reserva pasando por parametros el id de la pista a eliminar
         * 
         */
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<ActionResult<Reserva>> Delete(int id)
        {
            var reservaId = await context.Socios.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);
            if (reservaId == default)
            {
                return NotFound(new Result(404, false, "No se ha encontrado una reserva con el id pasado").GetResultJson());
            }

            context.Remove(new Reserva { Id = reservaId });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }

}


