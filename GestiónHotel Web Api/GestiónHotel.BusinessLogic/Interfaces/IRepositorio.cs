using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.BusinessLogic.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        public void Add(T item, IRepositorioConfiguracion config);
        public void Update(T item);
        public void Delete(T item);
        public IEnumerable<T> GetAll();
    }
}
