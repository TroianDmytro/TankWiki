using TankWiki.Models.ModelTank;

namespace TankWiki.Models.ModelOneToMany
{
    public class TankEngine
    {
        public int TankId { get; set; }
        public Tank Tank { get; set; }

        public int EngineId {  get; set; }
        public Engine Engine { get; set; }

    }
}
