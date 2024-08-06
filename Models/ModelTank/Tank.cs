using System.ComponentModel.DataAnnotations;
using TankWiki.Models.ModelOneToMany;

namespace TankWiki.Models.ModelTank
{
    public class Tank
    {
        //Танк
        [Key]
        public int TankId { get; set; } // Ідентифікатор
        public string Name { get; set; } // Назва
        public int NationId { get; set; }//id нації
        public Nations Nation { get; set; } // Нація
        public int Tier { get; set; } // Рівень
        public int HitPoints { get; set; } // Очки міцності
        public bool Status { get; set; } //премiальний танк true
        /*public double Weight { get; set; }*/ //вага
        public long Price { get; set; }//Ціна
        public string? Description { get; set; }//опис
        public int TypeId { get; set; } // Тип
        public TankType TankType { get; set; } // Тип
        public Armor Armor { get; set; } // Броня
        public int ArmorId { get; set; } // Броня
        public List<string> Crew { get; set; } = new List<string>(); // Екіпаж

        public List<TankTurret> TankTurrets { get; set; } = [];//Башні
        public List<TankEngine> TankEngines { get; set; } = []; // Двигун
        //public int EngineId { get; set; } // Двигун
        public List<TankSuspension> TankSuspensions { get; set; } = []; // Підвіска
        //public int SuspensionID { get; set; } // Підвіска
        public List<TankRadio> TankRadios { get; set; } = [];// Радіо
        //public int RadioId { get; set; } // Радіо
    }
}
