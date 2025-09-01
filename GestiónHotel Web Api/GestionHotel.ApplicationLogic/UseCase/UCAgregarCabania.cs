using GestionHotel.ApplicationLogic.InterfacesUseCase;
using GestionHotel.BusinessLogic.Entidades;
using GestionHotel.BusinessLogic.Interfaces;
using GestionHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.ApplicationLogic.UseCase
{
    public class UCAgregarCabania : IUCAgregarCabania
    {
        private IRepositorioCabania _repositorio;

        public UCAgregarCabania(IRepositorioCabania repositorio)
        {
            _repositorio = repositorio;
        }

        public CabaniaDTO AgregarCabania(CabaniaDTO cabaniaDTO, IRepositorioConfiguracion config)
        {
            Cabania aAgregar = new Cabania();
            aAgregar.Nombre = cabaniaDTO.Nombre;
            aAgregar.Descripcion = cabaniaDTO.Descripcion;
            aAgregar.TipoNombre = cabaniaDTO.TipoNombre;
            aAgregar.PoseeJacuzzi = cabaniaDTO.PoseeJacuzzi;
            aAgregar.Habilitada = cabaniaDTO.Habilitada;
            aAgregar.NumeroHabitacion = cabaniaDTO.NumeroHabitacion;
            aAgregar.MaxCupos = cabaniaDTO.MaxCupos;

            _repositorio.Add(aAgregar, config);
            return new CabaniaDTO(_repositorio.GetByName(cabaniaDTO.Nombre));
        }
    }
}
