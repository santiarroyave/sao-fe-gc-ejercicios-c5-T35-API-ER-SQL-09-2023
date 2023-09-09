namespace ex04.Models
{
    public class Equipo
    {
        public string numSerie { get; set; }
        public string nombre { get; set; }
        public int fk_facultad { get; set; }


        public virtual Facultad? v_facultad { get; set; }
        public virtual ICollection<Reserva>? v_reservas { get; set; }
    }
}
