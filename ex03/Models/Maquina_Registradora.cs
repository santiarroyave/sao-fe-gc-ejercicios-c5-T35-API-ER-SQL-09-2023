namespace ex03.Models
{
    public class Maquina_Registradora
    {
        public int codigo { get; set; }
        public int piso { get; set; }


        public virtual ICollection<Venta>? v_venta { get; set; }
    }
}
