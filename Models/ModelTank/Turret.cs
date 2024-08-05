using System.ComponentModel.DataAnnotations;
using TankWiki.Models.ModelOneToMany;

namespace TankWiki.Models.ModelTank
{
    //Башня
    public class Turret
    {
        [Key]
        public int TurretId { get; set; }
        public string TurretName { get; set; }// Назва
        public int Tier { get; set; } // Рівень
        public int TurretFront { get; set; } // Лобова броня башти
        public int TurretSide { get; set; } // Бічна броня башти
        public int TurretRear { get; set; } // Задня броня башти
        public double Turn {  get; set; }//поворот
        public int Overview { get; set; }//обзор
        public int Weight { get; set; } //вага
        public long Price { get; set; } //ціна
        //public List<Gun> Guns { get; set; } = [];
        //public List<Tank> Tanks { get; set; } = [];
        public List<TankTurret> TankTurrets { get; set; } = [];// Танки
        public List<TurretGun> TurretGuns { get; set; } = [];// Гармати Связь многие ко многим
     
    }

}
