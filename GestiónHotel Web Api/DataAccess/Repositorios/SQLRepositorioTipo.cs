using DataAccess;
using GestionHotel.BusinessLogic.Entidades;
using GestionHotel.BusinessLogic.Excepciones;
using GestionHotel.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.DataAccess.Repositorios
{
    public class SQLRepositorioTipo : IRepositorioTipo
    {
        public GestionHotelContext context { get; set; }

        public SQLRepositorioTipo()
        {
            context = new GestionHotelContext();
        }

        public void Add(Tipo tipo, IRepositorioConfiguracion config)
        {
            try
            {
                tipo.Validar(config);
                context.Tipos.Add(tipo);
                context.SaveChanges();
            }
            catch (TipoException e)
            {
                throw e;
            }
        }

        public void Delete(Tipo tipo)
        {
            if (!context.Cabanias.Any(cabania => cabania.TipoNombre == tipo.Nombre))
            {
                context.Tipos.Remove(tipo);
                context.SaveChanges();
            }
            else throw new TipoException("No se pudo eliminar. Existen cabañas con ese tipo");
        }

        public void Update(Tipo tipo)
        {
            context.Tipos.Update(tipo);
            context.SaveChanges();
        }

        public Tipo GetByName(string nombreTipo)
        {
            Tipo? toReturn = context.Tipos.Where(tipo => tipo.Nombre == nombreTipo)
                .FirstOrDefault();
            if (toReturn == null)
            {
                throw new TipoException("No se encontró tipo con ese nombre");
            }
            return toReturn;
        }

        public IEnumerable<Tipo> GetAll()
        {
            return context.Tipos
                .OrderBy(tipo => tipo.Nombre)
                .ToList();
        }
    }
}
