using System.ComponentModel.DataAnnotations;

namespace BiodigestoresAPI.Models
{
    public class Extension
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; } = String.Empty;
        
        public int UbicacionId { get; set; }

        public Ubicacion? Ubicacion { get; set; }
    }
}
