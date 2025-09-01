using GestionHotel.ApplicationLogic.InterfacesUseCase;
using GestionHotel.BusinessLogic.Entidades;
using GestionHotel.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.ApplicationLogic.UseCase
{
    public class UCEliminarCabania : IUCEliminarCabania
    {
        private IRepositorioCabania _repositorio;

        public UCEliminarCabania(IRepositorioCabania repositorio)
        {
            _repositorio = repositorio;
        }

        public void EliminarCabania(string cabaniaNombre)
        {
            Cabania aBorrar = new Cabania();
            aBorrar.Nombre = cabaniaNombre;
            _repositorio.Delete(aBorrar);
        }
    }
}
