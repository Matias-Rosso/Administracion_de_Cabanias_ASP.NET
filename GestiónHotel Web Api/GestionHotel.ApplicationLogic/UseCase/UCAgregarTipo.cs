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
    public class UCAgregarTipo : IUCAgregarTipo
    {
        private IRepositorioTipo _repositorio;

        public UCAgregarTipo(IRepositorioTipo repositorio)
        {
            _repositorio = repositorio;
        }

        public TipoDTO AgregarTipo(TipoDTO tipoDTO, IRepositorioConfiguracion config)
        {
            Tipo aAgregar = new Tipo();
            aAgregar.Nombre = tipoDTO.Nombre;
            aAgregar.Descripcion = tipoDTO.Descripcion;
            aAgregar.CostoPorHuesped = tipoDTO.CostoPorHuesped;

            _repositorio.Add(aAgregar, config);
            return new TipoDTO(_repositorio.GetByName(tipoDTO.Nombre));
        }
    }
}
