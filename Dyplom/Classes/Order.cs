using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dyplom.Classes
{
    [Table("Order")]
    public class Order
    {
        [Key, Column("Ключ")]
        public int Id { get; set; }
        [Required, MaxLength(50), Column("Прізвище")]
        public string SurName { get; set; }
        [Required, MaxLength(50), Column("Ім'я")]
        public string Name { get; set; }
        [Required, MaxLength(50), Column("По батькові")]
        public string SecondName { get; set; }
        [Required, MaxLength(50), Column("Номер телефону")]
        public string NumberOfPhone { get; set; }
        [Required, MaxLength(50), Column("Електрона пошта")]
        public string Mail { get; set; }
        [Required, MaxLength(50), Column("Тип опалення")]
        public string Heating { get; set; }
        [Required, Column("Дата встановлення")]
        public string Date { get; set; }
        [Required, MaxLength(256), Column("Місто")]
        public string City { get; set; }
        [Required, MaxLength(256), Column("Вулиця")]
        public string Street { get; set; }
        [Required, Column("Номер будинку")]
        public string NumberHome { get; set; }

        public Order(string NO, string LN, string SN, string NP, string ML, string HT, string DT, string CT, string ST, string NH)
        {
            this.City = CT;
            this.Street = ST;
            this.NumberHome = NH;
            this.Date = DT;
            this.Heating = HT;
            this.Mail = ML;
            this.Name = NO;
            this.NumberOfPhone = NP;
            this.SecondName = LN;
            this.SurName = SN;
        }
        public Order()
        { }
    }
}
