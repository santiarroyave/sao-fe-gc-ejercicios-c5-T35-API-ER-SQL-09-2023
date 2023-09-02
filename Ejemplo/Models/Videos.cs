namespace Ejemplo.Models
{
    public class Videos
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int? CliId { get; set; }

        public virtual Cliente Cli { get; set; }
    }
}
