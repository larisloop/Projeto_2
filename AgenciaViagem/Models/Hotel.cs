using System.ComponentModel.DataAnnotations;

namespace AgenciaViagem.Models
{
    public class Hotel
    {
        [Key]
        [Required]
        public int IdHotel{ get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int QtdHospede { get; set; }
       
    }
}
