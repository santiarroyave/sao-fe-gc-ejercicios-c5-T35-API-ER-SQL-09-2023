using System.ComponentModel.DataAnnotations.Schema;

namespace ex01.Models
{
    public class Piezas_Proveedores
    {
        public int fk_codigoPieza { get; set; }
        public string fk_idProveedor { get; set; }
        public int precio { get; set; }

        [ForeignKey("fk_idProveedor")]
        public virtual Proveedor? v_proveedores { get; set;}
        [ForeignKey("fk_codigoPieza")]
        public virtual Pieza? v_pieza { get; set; }
    }
}
