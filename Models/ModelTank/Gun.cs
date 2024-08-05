using System.ComponentModel.DataAnnotations;
using TankWiki.Models.ModelOneToMany;

namespace TankWiki.Models.ModelTank
{
    public class Gun
    {
        //гармата
        [Key]
        public int GunId { get; set; }
        public int Tier { get; set; } // Рівень
        public string Name { get; set; } // Назва
        public int Penetration { get; set; } // Пробивна здатність
        public int Damage { get; set; } // Шкода
        public double RateOfFire { get; set; } // Швидкість стрільби
        public double Accuracy { get; set; } // Точність
        public double AimTime { get; set; } // Час прицілювання
        public int Ammunition { get; set; }//боекомплект
        public double Weight { get; set; } //вага
        public long Price { get; set; }//Ціна
        //public List<Turret> Turrets { get; set; } = [];

        public List<TurretGun> TurretGuns { get; set; } = [];// Связь многие ко многим
    }
}
