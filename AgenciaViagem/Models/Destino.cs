using System.ComponentModel.DataAnnotations;

namespace AgenciaViagem.Models
{
    public class Destino
    {
       [Key]
        [Required]
        public  int IdDestino { get; set; }
        [Required]
        public string LocalDestino { get; set; }
        [Required]
        public string DataIda { get; set; }
        [Required]
        public int QtdPassageiros { get; set; }
    }
}
