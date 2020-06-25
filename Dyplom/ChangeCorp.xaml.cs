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
    /// Interaction logic for ChangeCorp.xaml
    /// </summary>
    public partial class ChangeCorp : Window
    {
        public int key;
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Corporation _corporation;
        public UnitOfWork unitOfWork = new UnitOfWork();

        public ChangeCorp()
        {
            InitializeComponent();
        }

        private void CancelButtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateButtn_Click(object sender, RoutedEventArgs e)
        {
            unitOfWork.DeleteCorp(key);
            _corporation = new Corporation(NameBoxC.Text, PhoneBoxC.Text, MailBoxC.Text, TYOHBoxC.Text, DateCoop.Text, TownBoxC.Text, StreetBoxC.Text, NumberBuildBoxC.Text);
            try
            {
                unitOfWork.Corporations.Insert(_corporation);
                unitOfWork.Save();
                Util.Info("Client", "Уіпішно Змінено!");
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
