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
    public class UCEditarTipo : IUCEditarTipo
    {
        private IRepositorioTipo _repositorio;

        public UCEditarTipo(IRepositorioTipo repositorio)
        {
            _repositorio = repositorio;
        }

        public TipoDTO EditarTipo(TipoDTO tipoDTO)
        {
            Tipo aEditar = new Tipo();
            aEditar.Nombre = tipoDTO.Nombre;
            aEditar.Descripcion = tipoDTO.Descripcion;
            aEditar.CostoPorHuesped = tipoDTO.CostoPorHuesped;

            _repositorio.Update(aEditar);
            return new TipoDTO(_repositorio.GetByName(tipoDTO.Nombre));
        }
    }
}
