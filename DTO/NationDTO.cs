using TankWiki.Models;

namespace TankWiki.DTO
{
    public class NationDTO
    {
        public int NationId { get; set; }
        public string NationName { get; set; }
        //public ICollection<TankDTO> Tanks { get; set; }

        public NationDTO(Nations nations) 
        {
            NationId = nations.NationId;
            NationName = nations.NationName;
        }
        public NationDTO(int nationId, string nationName)
        {
            NationId = nationId;
            NationName = nationName;
        }
    }
}
