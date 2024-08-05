using System.ComponentModel.DataAnnotations;

namespace TankWiki.Models.ModelTank
{
    //Броня
    public class Armor
    {
        [Key]
        public int ArmorId { get; set; }
        public string Name { get; set; }
        public int HullFront { get; set; } // Лобова броня корпусу
        public int HullSide { get; set; } // Бічна броня корпусу
        public int HullRear { get; set; } // Задня броня корпусу
        public int? TankId { get; set; } 
        public Tank Tank { get; set; }
       
    }
}
