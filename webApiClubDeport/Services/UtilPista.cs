using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApiClubDeport.Context;
using webApiClubDeport.Entities;
using webApiClubDeport.Models.PistaModel;

namespace webApiClubDeport.Services
{
    public static class UtilPista
    {
        internal static async Task<Dictionary<Pista, List<int>>> GetPistaDisponible(ApplicationDbContext context, PistaBuscar pistaBuscar)
        {
            List<Reserva> reservasSocioDiaDeporte = await GetReservasSocioDiaDeporte(context, pistaBuscar);

            if (reservasSocioDiaDeporte.Count > 2)
            {
                return null;
            }

            List<Pista> pistas = await GetPistas(context, pistaBuscar);

            var estructuraSalida = new Dictionary<Pista, List<int>>();

            List<int> horasDisponiblesSocio = ObtenerHorasDisponibles(context, pistaBuscar);

            foreach (Pista pista in pistas)
            {
                List<int> horasDisponibles = horasDisponiblesSocio;

                if (pista.Reservas != null)
                {
                    pista.Reservas.ForEach(x =>
                    {
                        if (horasDisponibles.Contains(x.Hora))
                        {
                            horasDisponibles.Remove(x.Hora);
                        }
                    });
                }

                estructuraSalida.Add(pista, horasDisponibles);

            }

            return estructuraSalida;

        }

        private static async Task<List<Reserva>> GetReservasSocioDiaDeporte(ApplicationDbContext context, PistaBuscar pistaBuscar)
        {
            return await context.Reservas.Include(s => s.Socio).Where(s => s.Socio.Mail == pistaBuscar.Socio)
                                        .Include(p => p.Pista).Where(p => p.Pista.Deporte.Nombre == pistaBuscar.Deporte)
                                        .Where(r => r.Fecha.Equals(pistaBuscar.Fecha)).ToListAsync();
        }

        private static async Task<List<Pista>> GetPistas(ApplicationDbContext context, PistaBuscar pistaBuscar)
        {
            return await context.Pistas.Include(x => x.Deporte).Include(x => x.Reservas)
                                            .Where(x => x.Deporte.Nombre == pistaBuscar.Deporte).ToListAsync();
        }

        private static List<int> ObtenerHorasDisponibles(ApplicationDbContext context, PistaBuscar pistaBuscar)
        {
            var horasReservasSocio = context.Reservas.Include(x => x.Socio)
                .Where(x => x.Socio.Mail.Trim().ToLower().Contains(pistaBuscar.Socio.Trim().ToLower()))
                .Where(x => x.Fecha.Equals(pistaBuscar.Fecha)).ToList();

            List<int> horasDisponibles = new List<int> { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };

            foreach(Reserva reserva in horasReservasSocio){
                if (reserva != null) {
                    horasDisponibles.Remove(reserva.Hora);
                }
            }

            return horasDisponibles;
        }
    }

}
