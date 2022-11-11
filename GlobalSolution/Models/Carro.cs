using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GlobalSolution.Models
{
    [Table("GS_CARRO")]
    public class Carro
    {

        public int Id { get; set; }
        public String Placa { get; set; }
        public String Modelo { get; set; }

        public int EstacionamentoId { get; set; }


    }
}
