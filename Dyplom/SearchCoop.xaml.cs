using Dyplom.BL;
using Dyplom.Classes;
using Dyplom.DAL;
using System.Windows;
using System;
using System.Data.Common;
using System.Linq;

namespace Dyplom
{
    /// <summary>
    /// Interaction logic for SearchCoop.xaml
    /// </summary>
    public partial class SearchCoop : Window
    {
        public UnitOfWork unitOfWork = new UnitOfWork();
        ChangeCorp changeCorp;
        public SearchCoop()
        {
            InitializeComponent();
        }

        private void CancelButtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SearchBut_Click(object sender, RoutedEventArgs e)
        {
            comboBox.Items.Clear();
            OrderContext orderContext = new OrderContext();
            foreach (var n in orderContext.Corporations.ToList())
            {
                try
                {
                    if (DataSearch.Text == n.NameCorp)
                    {
                        dataGrid.ItemsSource = orderContext.Corporations.ToList().Where(x => x.NameCorp == n.NameCorp);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.NumberHome)
                    {
                        dataGrid.ItemsSource = orderContext.Corporations.ToList().Where(x => x.NumberHome == n.NumberHome);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.City)
                    {
                        dataGrid.ItemsSource = orderContext.Corporations.ToList().Where(x => x.City == n.City);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.Date)
                    {
                        dataGrid.ItemsSource = orderContext.Corporations.ToList().Where(x => x.Date == n.Date);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.Mail)
                    {
                        dataGrid.ItemsSource = orderContext.Corporations.ToList().Where(x => x.Mail == n.Mail);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.Heating)
                    {
                        dataGrid.ItemsSource = orderContext.Corporations.ToList().Where(x => x.Heating == n.Heating);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.Street)
                    {
                        dataGrid.ItemsSource = orderContext.Corporations.ToList().Where(x => x.Street == n.Street);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.NumberOfPhone)
                    {
                        dataGrid.ItemsSource = orderContext.Corporations.ToList().Where(x => x.NumberOfPhone == n.NumberOfPhone);
                        comboBox.Items.Add(n.Id);
                    }
                }
                catch (DbException exc)
                {
                    Util.Error("Даних не знайдено:(", exc.Message);
                }
            }
            dataGrid.AutoGenerateColumns = true;
        }

        private void DeleteButtn_Click(object sender, RoutedEventArgs e)
        {
            unitOfWork.DeleteOrder(Convert.ToInt32(comboBox.Text));
            Util.Info("Видалено!", "Видалення пройшло успішно!");
        }

        private void ChangeButtn_Click(object sender, RoutedEventArgs e)
        {
            Corporation corporation = unitOfWork._GetCorporation(Convert.ToInt32(comboBox.Text));
            changeCorp = new ChangeCorp();
            changeCorp.NameBoxC.Text = corporation.NameCorp;
            changeCorp.TownBoxC.Text = corporation.City;
            changeCorp.StreetBoxC.Text = corporation.Street;
            changeCorp.NumberBuildBoxC.Text = corporation.NumberHome;
            changeCorp.TYOHBoxC.Text = corporation.Heating;
            changeCorp.PhoneBoxC.Text = corporation.NumberOfPhone;
            changeCorp.MailBoxC.Text = corporation.Mail;
            changeCorp.DateCoop.Text = corporation.Date;
            changeCorp.key = corporation.Id;
            changeCorp.Show();
            Close();
        }
    }
}
