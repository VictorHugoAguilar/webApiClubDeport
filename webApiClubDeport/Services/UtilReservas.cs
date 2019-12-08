using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using webApiClubDeport.Context;
using webApiClubDeport.Entities;
using webApiClubDeport.Models.ReservaModel;

namespace webApiClubDeport.Services
{
    public static class UtilReservas
    {
        public static IEnumerable<Reserva> GetReservasSocio(ApplicationDbContext context, ReservaDto reserva)
        {
            return context.Reservas.Include(x => x.Pista).Include(x => x.Socio)
                 .Where(x => x.Socio.Id == reserva.SocioId)
                 .Where(x => x.Fecha.Equals(reserva.Fecha))
                 .ToList();
        }

        public static IEnumerable<Reserva> GetReservaPistaHora(ApplicationDbContext context, ReservaDto reserva)
        {
            return context.Reservas.Include(x => x.Pista).Include(x => x.Socio)
                .Where(x => x.PistaId == reserva.PistaId)
                .Where(x => x.Hora == reserva.Hora)
                .Where(x => x.Fecha.Equals(reserva.Fecha))
                .Where(x => x.Socio.Id == reserva.SocioId)
                .ToList();
        }

        public static IEnumerable<Reserva> GetReservaSocioHora(ApplicationDbContext context, ReservaDto reserva)
        {
            return context.Reservas.Include(x => x.Pista).Include(x => x.Socio)
                .Where(x => x.Socio == reserva.Socio)
                .Where(x => x.Hora == reserva.Hora)
                .ToList();
        }

    }

}
