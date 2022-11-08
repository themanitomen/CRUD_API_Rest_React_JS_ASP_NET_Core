using System.ComponentModel.DataAnnotations;

namespace apiGestores.Models
{
    public class GestoresBD
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public int Launch { get; set; }
        public string Developer { get;set; }

    }
}
