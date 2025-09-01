using DataAccess;
using GestionHotel.BusinessLogic.Entidades;
using GestionHotel.BusinessLogic.Excepciones;
using GestionHotel.BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.DataAccess.Repositorios
{
    public class SQLRepositorioMantenimiento : IRepositorioMantenimiento
    {
        public GestionHotelContext context { get; set; }

        public SQLRepositorioMantenimiento()
        {
            context = new GestionHotelContext();
        }

        public void Add(Mantenimiento mantenimiento, IRepositorioConfiguracion config)
        {
            try
            {
                if (context.Mantenimientos.Where(m => m.CabaniaNombre == mantenimiento.CabaniaNombre
                    && m.Fecha.Year == mantenimiento.Fecha.Year && m.Fecha.Month == mantenimiento.Fecha.Month && 
                    m.Fecha.Day == mantenimiento.Fecha.Day).Count() >= 3)
                {
                    throw new MantenimientoException("Una cabaña no puede tener más de tres mantenimientos por día");
                } else
                {
                    mantenimiento.Validar(config);
                    context.Mantenimientos.Add(mantenimiento);
                    context.SaveChanges();
                }
            }
            catch (MantenimientoException e)
            {
                throw e;
            }
        }

        public void Delete(Mantenimiento mantenimiento)
        {
            context.Mantenimientos.Remove(mantenimiento);
            context.SaveChanges();
        }

        public void Update(Mantenimiento mantenimiento)
        {
            context.Mantenimientos.Update(mantenimiento);
            context.SaveChanges();
        }

        public Mantenimiento GetById(int id)
        {
            Mantenimiento? toReturn = context.Mantenimientos.Where(mantenimiento => mantenimiento.Id == id)
                //.Include("Cabania")
                .FirstOrDefault();
            if (toReturn == null)
            {
                throw new MantenimientoException("No se encontró mantenimiento con ese id");
            }
            return toReturn;
        }

        public IEnumerable<Mantenimiento> GetAll()
        {
            return context.Mantenimientos
                .OrderBy(mantenimiento => mantenimiento.Id)
                .ToList();
        }
        public IEnumerable<Mantenimiento> GetAllBetween(string nombreCabania, DateTime fecha1, DateTime fecha2)
        {
            return context.Mantenimientos.Where(mantenimiento => mantenimiento.CabaniaNombre == nombreCabania
                && mantenimiento.Fecha > fecha1 && mantenimiento.Fecha < fecha2)
                .OrderByDescending(mantenimiento => mantenimiento.Costo)
                //.Include("Cabania")
                .ToList();
        }
    }
}
