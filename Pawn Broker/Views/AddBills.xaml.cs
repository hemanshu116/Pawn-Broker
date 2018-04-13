using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pawn_Broker.Views
{
    /// <summary>
    /// Interaction logic for AddBills.xaml
    /// </summary>
    public partial class AddBills : UserControl
    {
        public AddBills()
        {
            InitializeComponent();
        }

        private void AddBillWithData(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DateOfBill.SelectedDate.Value.ToShortDateString());
        }

        private void CancelAddBill(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
