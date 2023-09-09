namespace ex04.Models
{
    public class Reserva
    {
        public string fk_dni { get; set; }
        public string fk_numSerie { get; set; }
        public DateTime comienzo { get; set; }
        public DateTime fin { get; set; }


        public virtual Investigador? v_investigador { get; set;}
        public virtual Equipo? v_equipo { get; set; }
    }
}
