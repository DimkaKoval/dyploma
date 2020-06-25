using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Telegram.Bot;

namespace Dyplom.TelegramD
{
    /// <summary>
    /// Interaction logic for TelgramBot.xaml
    /// </summary>
    /// 
    public partial class TelgramBot : Window
    {
        ObservableCollection<TelegramUser> Users;
        TelegramBotClient bot;

        public TelgramBot()
        {
            InitializeComponent();
            Users = new ObservableCollection<TelegramUser>();
            usersList.ItemsSource = Users;
            string token = "1202707337:AAG3SFykj8ShysXTHd0rcH8vCaWArJz5Gkc";
            bot = new TelegramBotClient(token);
            bot.OnMessage += delegate (object sender, Telegram.Bot.Args.MessageEventArgs e)
            {
                string msg = $"{DateTime.Now}: {e.Message.Chat.FirstName} {e.Message.Chat.LastName} {e.Message.Chat.Id} {e.Message.Text}";
                File.AppendAllText("data.log", $"{msg}\n");

                Debug.WriteLine(msg);
                this.Dispatcher.Invoke(() =>
                {
                    var person = new TelegramUser(e.Message.Chat.FirstName, e.Message.Chat.LastName, e.Message.Chat.Id);
                    if (!Users.Contains(person)) Users.Add(person);
                    Users[Users.IndexOf(person)].AddMessage($"{person.Nick}: {e.Message.Text}");
                });
            };
            bot.StartReceiving();
            btnSendMsg.Click += delegate { SendMsg(); };
            txtBxSendMsg.KeyDown += (s, e) => { if (e.Key == Key.Return) { SendMsg(); } };
        }
        public void SendMsg()
        {
            var concreteUser = Users[Users.IndexOf(usersList.SelectedItem as TelegramUser)];
            string responseMsg = $"Support: {txtBxSendMsg.Text}";
            concreteUser.Messages.Add(responseMsg);
            bot.SendTextMessageAsync(concreteUser.Id, txtBxSendMsg.Text);
            MessageBox.Show($"{concreteUser.Id}");
            string logText = $"{DateTime.Now}: >> {concreteUser.Id} {concreteUser.Nick} {responseMsg}\n";
            File.AppendAllText("data.log", logText);
            txtBxSendMsg.Text = String.Empty;
        }
    }                                                                           
}
