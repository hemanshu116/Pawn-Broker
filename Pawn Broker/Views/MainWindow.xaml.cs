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
using MaterialDesignThemes.Wpf;
using Pawn_Broker.db.dataManagers;
using Pawn_Broker.db.models;
using Pawn_Broker.ViewModels;

namespace Pawn_Broker.Views
{
    /// <summary>
    /// Interaction logic for MainWIndow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new SetListBoxHomepage();
            InitializeComponent();
            BillManager billManager =  new BillManager();
            //MessageBox.Show(billManager.GetBills().ToString());
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new AddBills());
            
        }
    }
}
