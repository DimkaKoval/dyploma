using System;
using System.Windows;
using System.Windows.Controls;
using Dyplom.Classes;
using System.Data.Entity.Infrastructure;
using Dyplom.DAL;
using Dyplom.BL;
using log4net;


namespace Dyplom
{
    /// <summary>
    /// Interaction logic for AddCoop.xaml
    /// </summary>
    public partial class AddCoop : Window
    {
        private bool _isEditing;
        private static readonly UnitOfWork UnitOfWorkInstance = new UnitOfWork();
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Corporation _corporation;

        public AddCoop()
        {
            InitializeComponent();
            _isEditing = false;
            ResetOrderInstance();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            NameBoxC = null;
            TownBoxC = null;
            StreetBoxC = null;
            NumberBuildBoxC = null;
            TYOHBoxC = null;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _corporation = new Corporation(NameBoxC.Text, PhoneBoxC.Text, MailBoxC.Text, TYOHBoxC.Text, DateCoop.Text, TownBoxC.Text, StreetBoxC.Text, NumberBuildBoxC.Text);
            try
            {
                UnitOfWorkInstance.Corporations.Insert(_corporation);
                UnitOfWorkInstance.Save();
                Util.Info("Client", "Уіпішно додано!");
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
            _corporation = new Corporation();
            DataContext = _corporation;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
