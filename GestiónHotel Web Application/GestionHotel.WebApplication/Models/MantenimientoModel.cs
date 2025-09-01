namespace GestionHotel.WebApplication.Models
{
    public class MantenimientoModel
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public string Tecnico { get; set; }

        public double Costo { get; set; }

        public string CabaniaNombre { get; set; }
    }
}
