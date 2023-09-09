namespace ex03.Models
{
    public class Cajero
    {
        public int codigo { get; set; }
        public string nomApels { get; set; }


        public virtual ICollection<Venta>? v_venta { get; set; }
    }
}
