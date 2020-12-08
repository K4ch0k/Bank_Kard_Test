using Bank_Kard_Test.window;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bank_Kard_Test.pages
{
    /// <summary>
    /// Логика взаимодействия для OwnerTable.xaml
    /// </summary>
    public partial class OwnerTable : Page
    {
        public OwnerTable()
        {
            InitializeComponent();
            owners = Core.DBentities.Owner_Card.ToList();
            DataContext = this;
        }

        private List<Owner_Card> owners = new List<Owner_Card>();

        public List<Owner_Card> Owners
        {
            get { return owners; }
            set { owners = value; }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var item = MainDataGrid.SelectedItem as Owner_Card;
            OwnerWindow ownwin = new OwnerWindow(item);
            ownwin.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = MainDataGrid.SelectedItem as Owner_Card;
            Core.DBentities.Owner_Card.Remove(item);
            Core.DBentities.SaveChanges();
        }
    }
}
