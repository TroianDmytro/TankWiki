using System.ComponentModel.DataAnnotations;
using TankWiki.Models.ModelTank;

namespace TankWiki.Models
{
    public class TankType
    {
        [Key]
        public int TankTypeId { get; set; }
        public string TypeMachine { get; set; }
        public List<Tank> Tanks { get; set; } = [];
    }
}
