using System;
using System.Windows;
using System.IO;
using System.Data;
using Dyplom.BL;
using System.Data.Common;
using Dyplom.DAL;
using System.Linq;
using Dyplom.TelegramD;
using Telegram.Bot;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Documents;
using System.Collections.Generic;

namespace Dyplom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AddWindow _adwindow;
        public AddCoop _addcoop;
        public SearchPrvt search;
        public SearchCoop searchCoop;
        public CheckPr checkPr;
        public OrderContext orderContext;
        public TelgramBot telegramBot;
        TelegramBotClient bot;

        public MainWindow()
        {
            string token = "1202707337:AAG3SFykj8ShysXTHd0rcH8vCaWArJz5Gkc";
            bot = new TelegramBotClient(token);
            this.SizeToContent = SizeToContent.Manual;
            InitializeComponent();
            startFunc();
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            if (CoopType.IsEnabled == false)
            {
                _addcoop = new AddCoop();
                _addcoop.Show();
            }
            if (PrivateType.IsEnabled == false)
            {
                _adwindow = new AddWindow();
                _adwindow.Show();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CoopType_Click_1(object sender, RoutedEventArgs e)
        {
            PrivateType.IsEnabled = true;
            CoopType.IsEnabled = false;
            startFunc();
        }
        private void startFunc()
        {
            try
            {
                try
                {
                    orderContext = new OrderContext();
                    dataGrid.ItemsSource = orderContext.Corporations.ToList();
                }
                catch (DbException exc)
                {
                    Util.Error("Exploring orders error", exc.Message);
                }
                catch (Exception exc)
                {
                    Util.Error("Exploring orders error", exc.Message);
                }
            }
            catch (FileNotFoundException ex)
            {
                dataGrid.ItemsSource = ex.Message;
            }
        }
        private void PrivateType_Click(object sender, RoutedEventArgs e)
        {
            PrivateType.IsEnabled = false;
            CoopType.IsEnabled = true;
            try
            {
                orderContext = new OrderContext();
                dataGrid.ItemsSource = orderContext.Orders.ToList();
            }
            catch (DbException exc)
            {
                Util.Error("Exploring orders error", exc.Message);
            }
        }

        private void CheckButtom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButtom_Click(object sender, RoutedEventArgs e)
        {
            if (CoopType.IsEnabled == false)
            {
                searchCoop = new SearchCoop();
                searchCoop.Show();
            }
            if (PrivateType.IsEnabled == false)
            {
                search = new SearchPrvt();
                search.Show();
            }
        }


        private void CheckButtom_Click_1(object sender, RoutedEventArgs e)
        {
            if (CoopType.IsEnabled == false)
            {
                DateTime localDate = DateTime.Now;
                checkPr = new CheckPr();
                var t = orderContext.Corporations.ToList().Where(x => Convert.ToDateTime(x.Date).Month == localDate.Month);
                checkPr.dataGrid.ItemsSource = t;
                var m = t.ToArray();
                for (int i = 0; i < m.Length; i++)
                    SendEmail(m[i].Mail);
                checkPr.Show();
            }
            if (PrivateType.IsEnabled == false)
            {
                DateTime localDate = DateTime.Now;
                checkPr = new CheckPr();
                var t = orderContext.Orders.ToList().Where(x => Convert.ToDateTime(x.Date).Month == localDate.Month);
                checkPr.dataGrid.ItemsSource = t;
                var m = t.ToArray();

                for (int i = 0; i < m.Length; i++)
                    SendEmail(m[i].Mail);
                checkPr.Show();
            }
        }

        private void telega_Click(object sender, RoutedEventArgs e)
        {
            telegramBot = new TelgramBot();
            telegramBot.Show();
        }
        private async void SendEmail(string mail)
        {
            MailAddress from = new MailAddress("leskovaldima@gmail.com", "Dmytro");
            MailAddress to = new MailAddress(mail);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            m.Body = "тет розсилки";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25);
            smtp.Credentials = new NetworkCredential("leskovaldima@gmail.com", "leschativ");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }

    }
}
