using GestionHotel.BusinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Interfaces
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        //public void Login(Usuario usuario);
        public Usuario GetById(int id);
        public Usuario GetByEmail(string email);
        public IEnumerable<String> GetTipoNombres();
        public IEnumerable<String> GetCabaniaNombres();
    }
}
