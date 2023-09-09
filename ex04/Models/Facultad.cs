namespace ex04.Models
{
    public class Facultad
    {
        public int codigo { get; set; }
        public string nombre { get; set; }


        public virtual ICollection<Equipo>? v_equipos { get; set; }
        public virtual ICollection<Investigador>? v_investigadores { get; set; }
    }
}
