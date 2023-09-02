namespace Ejemplo.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int? Dni { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual ICollection<Videos> Videos { get; set; }
    }
}
