using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity.Infrastructure;
using log4net;
using Dyplom.Classes;
using Dyplom.DAL;
using Dyplom.BL;

namespace Dyplom
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private bool _isEditing;
        private static readonly UnitOfWork UnitOfWorkInstance = new UnitOfWork();
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Order _order;


        public AddWindow()
        {
            InitializeComponent();
            _isEditing = false;
            ResetOrderInstance();

        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _order = new Order(NameTextP.Text, SurNameTextP.Text, SecondNameBoxP.Text, PhoneBoxPr.Text, MailBoxPr.Text, TYOHBoxP.Text, DateOrder.Text, TownOrder.Text, StreetOrder.Text, NumberBuildOrder.Text);
            try
            {
                UnitOfWorkInstance.Orders.Insert(_order);
                UnitOfWorkInstance.Save();
                Util.Info("Client", "Успішно збережено!");
            }
            catch (InvalidCastException exc)
            {
                Logger.Error($"Error occurred while vaidating inputs.\nError: {exc}");
                Util.Error("Order saving error", exc.Message);
            }
            catch (DbUpdateException exc)
            {
                Logger.Error($"Error occurred while updating the databse.\nError: {exc}");
                Util.Error("Order saving error", exc.Message);
            }
            catch (Exception exc)
            {
                Logger.Error($"Error occurred while order saving or updating.\nError: {exc}");
                Util.Error("Order saving error", exc.Message);
            }
            Close();
        }
        private void ResetOrderInstance()
        {
            _order = new Order();
            DataContext = _order;
        }

        private void NumberBuildOrder_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
