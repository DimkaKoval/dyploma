using log4net;
using Dyplom.BL;
using Dyplom.Classes;
using Dyplom.DAL;
using System;
using System.Data.Entity.Infrastructure;
using System.Windows;

namespace Dyplom
{
    /// <summary>
    /// Interaction logic for ChangeOrder.xaml
    /// </summary>
    public partial class ChangeOrder : Window
    {
        public int key;
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Order _order;
        public UnitOfWork unitOfWork = new UnitOfWork();


        public ChangeOrder()
        {
            InitializeComponent();
        }


        private void CancelButtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateBttn_Click(object sender, RoutedEventArgs e)
        {
            unitOfWork.DeleteOrder(key);
            _order = new Order(NameTextP.Text, SecondNameBoxP.Text, SurNameTextP.Text, PhoneBoxPr.Text, MailBoxPr.Text, TYOHBoxP.Text, DateOrder.Text, TownOrder.Text, StreetOrder.Text, NumberBuildOrder.Text);
            try
            {
                unitOfWork.Orders.Insert(_order);
                unitOfWork.Save();
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
    }
}
