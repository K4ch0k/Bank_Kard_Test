using System.Windows;

namespace Bank_Kard_Test.window
{
    /// <summary>
    /// Логика взаимодействия для OwnerWindow.xaml
    /// </summary>
    public partial class OwnerWindow : Window
    {
        public OwnerWindow(Owner_Card ownercard)
        {
            InitializeComponent();
            owner = ownercard;
            DataContext = this;
        }

        public Owner_Card owner { get; set; }


        private void EditOwner_Click(object sender, RoutedEventArgs e)
        {
            if (owner.id == 0)
            {
                Core.DBentities.Owner_Card.Add(owner);
            }
            Core.DBentities.SaveChanges();
            this.Close();
        }
    }
}
