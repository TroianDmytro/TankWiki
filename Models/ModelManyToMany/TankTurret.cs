using TankWiki.Models.ModelTank;

namespace TankWiki.Models.ModelOneToMany
{
    public class TankTurret
    {
        public int TankId { get; set; }
        public Tank Tank { get; set; }

        public int TurretId { get; set; }
        public Turret Turret { get; set; }
    }
}
