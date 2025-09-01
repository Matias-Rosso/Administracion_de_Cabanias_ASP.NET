using DataAccess;
using GestionHotel.BusinessLogic.Entidades;
using GestionHotel.BusinessLogic.Interfaces;
using GestionHotel.BusinessLogic.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestionHotel.DataAccess.Repositorios
{
    public class SQLRepositorioCabania : IRepositorioCabania
    {
        public GestionHotelContext context { get; set; }

        public SQLRepositorioCabania()
        {
            context = new GestionHotelContext();
        }

        public void Add(Cabania cabania, IRepositorioConfiguracion config)
        {
            try
            {
                cabania.Validar(config);
                context.Cabanias.Add(cabania);
                context.SaveChanges();
            }
            catch (CabaniaException e)
            {
                throw e;
            }
        }

        public void Delete(Cabania cabania)
        {
            context.Cabanias.Remove(cabania);
            context.SaveChanges();
        }

        public void Update(Cabania cabania)
        {
            context.Cabanias.Update(cabania);
            context.SaveChanges();
        }
        public Cabania GetByName(string nombreCabania)
        {
            Cabania? toReturn = context.Cabanias.Where(cabania => cabania.Nombre == nombreCabania)
                .Include("Tipo")
                .FirstOrDefault();
            if (toReturn == null)
            {
                throw new CabaniaException("No se encontró cabaña con ese nombre");
            }
            return toReturn;
        }

        public IEnumerable<Cabania> GetAll()
        {
            return context.Cabanias
                .OrderBy(cabania => cabania.Nombre)
                .Include("Tipo")
                .ToList();
        }
        public IEnumerable<Cabania> GetAllByName(string nombreCabania)
        {
            return context.Cabanias.Where(cabania => cabania.Nombre.Contains(nombreCabania))
                .OrderBy(cabania => cabania.Nombre)
                .Include("Tipo")
                .ToList();
        }
        public IEnumerable<Cabania> GetAllByTipo(string nombreTipo)
        {
            return context.Cabanias.Where(cabania => cabania.TipoNombre == nombreTipo)
                .OrderBy(cabania => cabania.TipoNombre)
                .Include("Tipo")
                .ToList();
        }
        public IEnumerable<Cabania> GetAllByCupos(int cupos)
        {
            return context.Cabanias.Where(cabania => cabania.MaxCupos >= cupos)
                .OrderBy(cabania => cabania.MaxCupos)
                .Include("Tipo")
                .ToList();
        }

        public IEnumerable<Cabania> GetAllHabilitadas()
        {
            return context.Cabanias.Where(cabania => cabania.Habilitada)
                .OrderBy(cabania => cabania.Nombre)
                .Include("Tipo")
                .ToList();
        }
        public IEnumerable<String> GetTipoNombres()
        {
            return context.Tipos
                .Select(tipo => tipo.Nombre)
                .ToList();
        }
    }
}
