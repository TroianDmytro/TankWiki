using System.ComponentModel.DataAnnotations;
using TankWiki.Models.ModelOneToMany;

namespace TankWiki.Models.ModelTank
{
    //Підвіска
    public class Suspension
    {
        [Key]
        public int SuspensionId { get; set; }
        public string Name { get; set; } // Назва

        public int Tier { get; set; } // Рівень
        public double LoadLimit { get; set; } // Обмеження навантаження
        public int TraverseSpeed { get; set; } // Швидкість повороту
        public double Weight { get; set; } //вага
        public long Price { get; set; }//Ціна

        public List<TankSuspension> TankSuspensions { get; set; }
    }
}
