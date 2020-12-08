using Bank_Kard_Test.pages;
using Bank_Kard_Test.window;
using System.Windows;

namespace Bank_Kard_Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
        }

        private void AddCard_Click(object sender, RoutedEventArgs e)
        {
            EditWindow editwwin = new EditWindow(new Bank_Card());
            editwwin.Show();
        }

        private void AddOwner_Click(object sender, RoutedEventArgs e)
        {
            OwnerWindow ownwin = new OwnerWindow(new Owner_Card());
            ownwin.Show();
        }

        private void CardTable_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }

        private void OwnerTable_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OwnerTable());
        }
    }
}
