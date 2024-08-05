using TankWiki.Models;

namespace TankWiki.DTO
{
    public class TankTypeDTO
    {
        public int TankTypeId {  get; set; }
        public string TankType { get; set; }

        public TankTypeDTO(TankType tankType)
        {
            TankTypeId = tankType.TankTypeId;
            TankType = tankType.TypeMachine;
        }
    }
}
