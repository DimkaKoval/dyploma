using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Dyplom.TelegramD
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramUser : INotifyPropertyChanged, IEquatable<TelegramUser>
    {
        public TelegramUser(string FName, string SName, long ChatId)
        {
            this.name = FName;
            this.secondName = SName;
            this.id = ChatId;
            Messages = new ObservableCollection<string>();
        }
        public string Nick
        {
            get { return this.name + " " + this.secondName; }
        }

        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Nick)));
            }
        }
        private string secondName;
        public string SecondName
        {
            get { return this.secondName; }
            set
            {
                this.secondName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SecondName)));
            }
        }
        private long id;

        public long Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Id)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Equals(TelegramUser other) => other.Id == this.id;

        public ObservableCollection<string> Messages { get; set; }

        public void AddMessage(string Text) => Messages.Add(Text);
    }
}
