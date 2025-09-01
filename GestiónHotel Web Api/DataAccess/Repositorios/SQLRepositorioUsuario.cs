using DataAccess;
using GestionHotel.BusinessLogic.Entidades;
using GestionHotel.BusinessLogic.Excepciones;
using GestionHotel.BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.DataAccess.Repositorios
{
    public class SQLRepositorioUsuario : IRepositorioUsuario
    {
        public GestionHotelContext context { get; set; }

        public SQLRepositorioUsuario()
        {
            context = new GestionHotelContext();
        }
        /*
        public void Login(Usuario usuario)
        {
            if (!context.Usuarios.Any(u => u.Email == usuario.Email &&
                u.Clave == usuario.Clave))
            {
                throw new UsuarioException("Email o contraseña incorrecto.");
            }
        }
        */
        public void Add(Usuario usuario, IRepositorioConfiguracion config)
        {
            try
            {
                usuario.Validar(config);
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
            catch (UsuarioException e) 
            {
                throw e;
            }
        }

        public void Delete(Usuario usuario)
        {
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            context.Usuarios.Update(usuario);
            context.SaveChanges();
        }

        public Usuario GetById(int id)
        {
            Usuario? toReturn = context.Usuarios.Where(usuario => usuario.Id == id)
                .FirstOrDefault();
            if (toReturn == null)
            {
                throw new UsuarioException("No se encontró usuario con ese id");
            }
            return toReturn;
        }

        public Usuario GetByEmail(string email)
        {
            Usuario? toReturn = context.Usuarios.Where(usuario => usuario.Email == email)
                .FirstOrDefault();
            if (toReturn == null)
            {
                throw new UsuarioException("No se encontró usuario con ese email");
            }
            return toReturn;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return context.Usuarios
                .OrderBy(usuario => usuario.Id)
                .ToList();
        }
        public IEnumerable<String> GetTipoNombres()
        {
            return context.Tipos
                .Select(tipo => tipo.Nombre)
                .ToList();
        }
        public IEnumerable<String> GetCabaniaNombres()
        {
            return context.Cabanias
                .Select(cabania => cabania.Nombre)
                .ToList();
        }
    }
}
