using System.ComponentModel.DataAnnotations;

namespace AgenciaViagem.Models
{
    public class Passageiro
    {
        [Key]
        [Required]
        public int CodigoCliente { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Identidade { get; set; }
        [Required]
        public int Idade { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public int DestinoIdDestino { get; set; }
        public Destino Destino { get; set; }

        [Required]
        public int HotelIdHotel { get; set; }

        public Hotel Hotel { get; set; }
    }
}
