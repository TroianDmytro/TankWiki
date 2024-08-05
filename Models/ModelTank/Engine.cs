using System.ComponentModel.DataAnnotations;
using TankWiki.Models.ModelOneToMany;

namespace TankWiki.Models.ModelTank
{
    // мотор
    public class Engine
    {
        [Key]
        public int EngineId { get; set; }
        public string Name { get; set; } // Назва
        public int Tier { get; set; } // Рівень
        public int Power { get; set; } // Потужність
        public double FireChance { get; set; } // Ймовірність загоряння
        public double Weight { get; set; } //вага
        public long Price { get; set; }//Ціна

        public List<TankEngine> TankEngines { get; set; }
    }
}
