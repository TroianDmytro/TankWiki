using TankWiki.Models.ModelTank;

namespace TankWiki.Models.ModelOneToMany
{
    public class TurretGun
    {
        public int TurretId { get; set; }
        public Turret Turret { get; set; }

        public int GunId { get; set; }
        public Gun Gun { get; set; }

    }
}
