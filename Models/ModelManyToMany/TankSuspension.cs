using TankWiki.Models.ModelTank;

namespace TankWiki.Models.ModelOneToMany
{
    public class TankSuspension
    {
        public int TankId { get; set; }
        public Tank Tank { get; set; }

        public int SuspensionId { get; set; }
        public Suspension Suspension { get; set; }

    }
}
