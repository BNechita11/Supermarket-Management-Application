using System.Windows;
using WpfApp3.Models;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.Views;
using WpfApp3.DataBase;

namespace WpfApp3
{
    public partial class Login : Window
    {
        private readonly MagazinContextDb db;
       public Login()
        {
            InitializeComponent();
        }

        private void Autentificare_Click(object sender, RoutedEventArgs e)
        {
            string numeUtilizator = txtNumeUtilizator.Text;
            string parola = txtParola.Password;

           
            Utilizator utilizatorAutentificat = VerificaUtilizator(numeUtilizator, parola);

            if (utilizatorAutentificat != null)
            {
                MessageBox.Show($"Autentificare reușită pentru {utilizatorAutentificat.TipUtilizator}!");

              
                if (utilizatorAutentificat.TipUtilizator == "Admin")
                {
                    var adminDashboard = new AdminDashboard();
                    adminDashboard.Show();
                }
                else if (utilizatorAutentificat.TipUtilizator == "Casier")
                {
                    var casierDashboard = new CashierDashboard(db);
                    casierDashboard.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Autentificare eșuată. E probabil sa fi gresit numele de utilizator, parola sau Casierul a fost sters din baza de date.");
            }
        }

        private Utilizator VerificaUtilizator(string numeUtilizator, string parola)
        {
   
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                return context.Utilizator.FirstOrDefault(u => u.Nume == numeUtilizator && u.Parola == parola && u.IsActive == true);
            }
        }

        private bool AutentificareSucces()
        {
            return true; 
        }
    }
}
