using Dyplom.BL;
using Dyplom.Classes;
using Dyplom.DAL;
using System;
using System.Data.Common;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Dyplom
{
    /// <summary>
    /// Interaction logic for SearchPrvt.xaml
    /// </summary>
    public partial class SearchPrvt : Window
    {
        public UnitOfWork unitOfWork = new UnitOfWork();
        public ChangeOrder changeOrder;
        public SearchPrvt()
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
            foreach (var n in orderContext.Orders.ToList())
            {
                try
                {
                    if (DataSearch.Text == n.SecondName)
                    {
                        dataGrid.ItemsSource = orderContext.Orders.ToList().Where(x => x.SecondName == n.SecondName);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.Name)
                    {
                        dataGrid.ItemsSource = orderContext.Orders.ToList().Where(x => x.Name == n.Name);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.SurName)
                    {
                        dataGrid.ItemsSource = orderContext.Orders.ToList().Where(x => x.SurName == n.SurName);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.NumberOfPhone)
                    {
                        dataGrid.ItemsSource = orderContext.Orders.ToList().Where(x => x.NumberOfPhone == n.NumberOfPhone);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.Mail)
                    {
                        dataGrid.ItemsSource = orderContext.Orders.ToList().Where(x => x.Mail == n.Mail);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.Heating)
                    {
                        dataGrid.ItemsSource = orderContext.Orders.ToList().Where(x => x.Heating == n.Heating);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.Date)
                    {
                        dataGrid.ItemsSource = orderContext.Orders.ToList().Where(x => x.Date == n.Date);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.City)
                    {
                        dataGrid.ItemsSource = orderContext.Orders.ToList().Where(x => x.City == n.City);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.Street)
                    {
                        dataGrid.ItemsSource = orderContext.Orders.ToList().Where(x => x.Street == n.Street);
                        comboBox.Items.Add(n.Id);
                    }
                    if (DataSearch.Text == n.NumberHome)
                    {
                        dataGrid.ItemsSource = orderContext.Orders.ToList().Where(x => x.NumberHome == n.NumberHome);
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
            Order order = unitOfWork._GetOrder(Convert.ToInt32(comboBox.Text));
            changeOrder = new ChangeOrder();
            changeOrder.SecondNameBoxP.Text = order.SecondName;
            changeOrder.NameTextP.Text = order.Name;
            changeOrder.SurNameTextP.Text = order.SurName;
            changeOrder.PhoneBoxPr.Text = order.NumberOfPhone;
            changeOrder.MailBoxPr.Text = order.Mail;
            changeOrder.TownOrder.Text = order.City;
            changeOrder.StreetOrder.Text = order.Street;
            changeOrder.NumberBuildOrder.Text = order.NumberHome;
            changeOrder.TYOHBoxP.Text = order.Heating;
            changeOrder.DateOrder.Text = order.Date;
            changeOrder.key = order.Id;
            changeOrder.Show();
            Close();
        }

        private void DataSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
