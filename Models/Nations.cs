using System.ComponentModel.DataAnnotations;
using TankWiki.Models.ModelTank;

namespace TankWiki.Models
{
    public class Nations
    {
        [Key]
        public int NationId { get; set; }
        [Required]
        public string NationName { get; set;}
        public List<Tank> Tanks { get; set; } = [];
    }
}
