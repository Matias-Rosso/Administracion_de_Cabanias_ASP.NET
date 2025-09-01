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
    public class UCEliminarTipo : IUCEliminarTipo
    {
        private IRepositorioTipo _repositorio;

        public UCEliminarTipo(IRepositorioTipo _repositorio)
        {
            this._repositorio = _repositorio;
        }

        public void EliminarTipo(string tipoNombre)
        {
            Tipo aBorrar = new Tipo();
            aBorrar.Nombre = tipoNombre;
            _repositorio.Delete(aBorrar);
        }
    }
}
