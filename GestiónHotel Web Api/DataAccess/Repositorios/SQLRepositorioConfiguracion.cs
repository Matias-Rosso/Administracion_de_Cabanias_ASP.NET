using DataAccess;
using GestionHotel.BusinessLogic.Entidades;
using GestionHotel.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.DataAccess.Repositorios
{
    public class SQLRepositorioConfiguracion : IRepositorioConfiguracion
    {
        public GestionHotelContext context { get; set; }

        public SQLRepositorioConfiguracion()
        {
            context = new GestionHotelContext();
        }
        public void Add(Configuracion item, IRepositorioConfiguracion config)
        {
            throw new NotImplementedException();
        }

        public void Delete(Configuracion item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Configuracion> GetAll()
        {
            throw new NotImplementedException();
        }

        public int ObtenerInferiorPorAtributo(string atributo)
        {
            Configuracion config = context.Configuracion
                .Where(config => config.Atributo == atributo)
                .FirstOrDefault();

            if (config == null)
            {
                throw new Exception("Atributo inexistente");
            }
            return config.LimiteInferior;
        }

        public int ObtenerSuperiorPorAtributo(string atributo)
        {
            Configuracion config = context.Configuracion
                .Where(config => config.Atributo == atributo)
                .FirstOrDefault();

            if (config == null)
            {
                throw new Exception("Atributo inexistente");
            }
            return config.LimiteSuperior;
        }

        public void Update(Configuracion item)
        {
            throw new NotImplementedException();
        }
    }
}
