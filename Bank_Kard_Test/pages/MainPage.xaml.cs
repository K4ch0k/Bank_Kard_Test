using Bank_Kard_Test.window;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bank_Kard_Test.pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            bank_cards = Core.DBentities.Bank_Card.ToList();
            DataContext = this;
        }


        private List<Bank_Card> bank_cards = new List<Bank_Card>();

        public List<Bank_Card> Bank_Cards
        {
            get { return bank_cards; }
            set { bank_cards = value; }
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var item = MainDataGrid.SelectedItem as Bank_Card;
            EditWindow ew = new EditWindow(item);
            ew.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = MainDataGrid.SelectedItem as Bank_Card;
            Core.DBentities.Bank_Card.Remove(item);
            Core.DBentities.SaveChanges();
        }
    }
}
