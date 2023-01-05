using System.ComponentModel.DataAnnotations;

namespace BiodigestoresAPI.Models
{
    public class Biodigestor
    {
        public int Id { get; set; }
        [Required]
        public double Temperaturainterna { get; set; }
        [Required]
        public double Temperaturaexterna { get; set; }
        [Required]
        public double Humedad { get; set; }
        [Required]
        public double Caudal { get; set; }
        [Required]
        public double pH { get; set; }

        public int ExtensionId { get; set; }

        public Extension? Extension { get; set; }
    }
}
