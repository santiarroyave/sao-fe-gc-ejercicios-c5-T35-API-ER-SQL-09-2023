namespace ex04.Models
{
    public class Investigador
    {
        public string dni { get; set; }
        public string nomApels { get; set; }
        public int fk_facultad { get; set; }


        public virtual Facultad? v_facultad { get; set; }
        public virtual ICollection<Reserva>? v_reservas { get; set; }
    }
}
