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
    public class UCEliminarMantenimiento : IUCEliminarMantenimiento
    {
        private IRepositorioMantenimiento _repositorio;

        public UCEliminarMantenimiento(IRepositorioMantenimiento repositorio)
        {
            _repositorio = repositorio;
        }

        public void EliminarMantenimiento(int idMantenimiento)
        {
            Mantenimiento aBorrar = new Mantenimiento();
            aBorrar.Id = idMantenimiento;
            _repositorio.Delete(aBorrar);
        }
    }
}
