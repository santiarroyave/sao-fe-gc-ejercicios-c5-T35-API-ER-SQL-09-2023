namespace ex02.Models
{
    public class Cientifico_Proyecto
    {
        public string fk_cientifico_dni { get; set; }
        public string fk_proyecto_id { get; set; }


        public virtual Proyecto? v_proyecto { get; set; }
        public virtual Cientifico? v_cientifico { get; set; }
    }
}
