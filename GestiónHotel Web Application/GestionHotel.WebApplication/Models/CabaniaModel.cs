namespace GestionHotel.WebApplication.Models
{
    public class CabaniaModel
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string TipoNombre { get; set; }

        public double TipoCostoPorHuesped { get; set; }

        public bool PoseeJacuzzi { get; set; }

        public bool Habilitada { get; set; }

        public int NumeroHabitacion { get; set; }

        public int MaxCupos { get; set; }

        public string Foto { get; set; }
    }
}
