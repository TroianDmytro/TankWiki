using TankWiki.Models.ModelTank;

namespace TankWiki.Models.ModelOneToMany
{
    public class TankRadio
    {
        public int TankId { get; set; }
        public Tank Tank { get; set; }

        public int RadioId { get; set; }
        public Radio Radio { get; set; }

    }
}
