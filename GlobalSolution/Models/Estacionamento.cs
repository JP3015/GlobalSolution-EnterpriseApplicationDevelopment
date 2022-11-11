using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("GS_ESTACIONAMENTO_NET")]
    public class Estacionamento
    {
        public int Id { get; set; }

        public String Local { get; set; }

    }
}
