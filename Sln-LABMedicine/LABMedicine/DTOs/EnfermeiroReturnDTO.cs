using System.ComponentModel.DataAnnotations;

namespace LABMedicine.DTOs
{
    public class EnfermeiroReturnDTO
    {
        [Required]
        public int intentificador { get; set; }

        [Required]
        [StringLength(100)]
        public string EnsinoEnfermeiro { get; set; }

        [Required]
        [StringLength(15)]
        public string Cofen { get; set; }
    }
}
