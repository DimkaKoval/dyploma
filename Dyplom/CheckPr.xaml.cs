using System.Windows;
using System.Windows.Controls;

namespace Dyplom
{
    /// <summary>
    /// Interaction logic for CheckPr.xaml
    /// </summary>
    public partial class CheckPr : Window
    {
        public CheckPr()
        {
            InitializeComponent();
        }

        private void CancelButtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PrintButtn_Click(object sender, RoutedEventArgs e)
        {

            var dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(dataGrid, "Друкування таблиці");
            }
        }
    }
}
