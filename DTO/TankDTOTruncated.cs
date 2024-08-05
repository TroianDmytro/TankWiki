using TankWiki.Models.ModelTank;

namespace TankWiki.DTO
{
    public class TankDTOTruncated
    {
        public int TankId { get; set; }
        public string TankName { get; set; }
        public TankDTOTruncated(Tank tank)
        {
            TankId = tank.TankId;
            TankName = tank.Name;
        }
    }
}
