using System.ComponentModel.DataAnnotations;
using TankWiki.Models.ModelOneToMany;

namespace TankWiki.Models.ModelTank
{
    //Радіо
    public class Radio
    {
        [Key]
        public int RadioId { get; set; }
        public int Tier { get; set; } // Рівень
        public string Name { get; set; } // Назва
        public int SignalRange { get; set; } // Дальність сигналу
        public double Weight { get; set; } //вага
        public long Price { get; set; }//Ціна

        public List<TankRadio> TankRadios { get; set; }
    }
}
