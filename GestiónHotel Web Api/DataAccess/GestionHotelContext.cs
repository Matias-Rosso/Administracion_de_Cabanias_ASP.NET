using System.Collections.Generic;
using GestionHotel.BusinessLogic.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class GestionHotelContext : DbContext
    {
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cabania> Cabanias { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Configuracion> Configuracion { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cadenaConexion =
                @"SERVER=(localdb)\MSsqlLocaldb;
                DATABASE=C:\Users\Usuario\GestionHotel.mdf;
                INTEGRATED SECURITY=TRUE;
                ENCRYPT=False";
            optionsBuilder.UseSqlServer(cadenaConexion)
                .EnableDetailedErrors();
        }

    }
}