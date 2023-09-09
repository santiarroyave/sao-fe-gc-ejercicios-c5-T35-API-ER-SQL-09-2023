using System.ComponentModel.DataAnnotations;

namespace ex01.Models
{
    public class Pieza
    {
        public int codigo { get; set; }
        public string nombre { get; set; }


        public ICollection<Piezas_Proveedores>? v_piezas_proveedores { get; set; }
    }
}
