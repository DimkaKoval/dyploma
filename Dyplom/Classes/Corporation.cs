using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dyplom.Classes
{
    [Table("Corporation")]
    public class Corporation : INotifyPropertyChanged, IEquatable<Corporation>
    {
        [Key, Column("Номер")]
        public int id { get; set; }
        [Required, MaxLength(50), Column("Назва закладу")]
        public string NameCorp { get; set; }
        [Required, MaxLength(50), Column("Номер телефону")]
        public string NumberOfPhone { get; set; }
        [Required, MaxLength(50), Column("Електрона пошта")]
        private string mail { get; set; }
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

        public Corporation(string NC, string NP, string ML, string HT, string DT, string CT, string ST, string NH)
        {
            this.City = CT;
            this.Street = ST;
            this.NumberHome = NH;
            this.Date = DT;
            this.Heating = HT;
            this.mail = ML;
            this.NumberOfPhone = NP;
            this.NameCorp = NC;
        }

        public Corporation()
        { }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Id)));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Mail
        {
            get { return this.mail; }
            set
            {
                this.mail = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Mail)));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Corporation other) => other.Id == this.id;

    }
}
