namespace ex03.Models
{
    public class Venta
    {
        public int fk_cajero { get; set; }
        public int fk_maquina { get; set; }
        public int fk_producto { get; set; }


        public virtual Cajero? v_cajero { get; set; }
        public virtual Maquina_Registradora? v_maquina { get; set; }
        public virtual Producto? v_producto { get; set; }
    }
}
