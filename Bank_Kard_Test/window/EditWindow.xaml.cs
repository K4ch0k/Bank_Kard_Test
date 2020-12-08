using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Bank_Kard_Test.window
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow(Bank_Card bankcard)
        {
            InitializeComponent();
            Bank_Card = bankcard;
            Owner_Card = Core.DBentities.Owner_Card.ToList();
            if (Bank_Card.id == 0)
            {
                Bank_Card.finish_date = DateTime.Today;
            }
            DataContext = this;
        }

        public List<Owner_Card> Owner_Card { get; set; }
        public Bank_Card Bank_Card { get; set; }

        private void AddOwner_Click(object sender, RoutedEventArgs e)
        {
            OwnerWindow ownwin = new OwnerWindow(new Owner_Card());
            ownwin.Show();
        }

        private void EditOwner_Click(object sender, RoutedEventArgs e)
        {
            OwnerWindow ownwin = new OwnerWindow(Owner.SelectedItem as Owner_Card);
            ownwin.Show();
        }

        private void Save_Card_Click(object sender, RoutedEventArgs e)
        {
            var f = 0;
            if (Finish_Date_Card.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Карта не действительна!", "Ошибка");
                f += 1;
            }
            if (Number_Card.Text.Length != 16)
            {
                MessageBox.Show("Длина номера карты должна быть 16 цифр", "Ошибка");
                f += 1;
            }
            if (Cvv_Card.Text.Length != 3)
            {
                MessageBox.Show("Длина CVV всегда равна 3 цифрам", "Ошибка");
                f += 1;
            }
            if (f == 0)
            {
                if (Bank_Card.id == 0)
                {
                    Core.DBentities.Bank_Card.Add(Bank_Card);
                }
                Core.DBentities.SaveChanges();
            }
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
