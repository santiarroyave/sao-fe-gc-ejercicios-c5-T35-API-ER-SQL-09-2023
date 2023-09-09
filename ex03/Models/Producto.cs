namespace ex03.Models
{
    public class Producto
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }


        public virtual ICollection<Venta>? v_venta { get; set; }
    }
}
