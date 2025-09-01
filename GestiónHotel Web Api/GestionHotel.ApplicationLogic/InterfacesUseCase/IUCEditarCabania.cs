using GestionHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.ApplicationLogic.InterfacesUseCase
{
    public interface IUCEditarCabania
    {
        public CabaniaDTO EditarCabania(CabaniaDTO cabaniaDTO);
    }
}
