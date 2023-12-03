using System.Windows;

namespace VetClinicApplication
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
          
            if (MedLogin.Text == "admin" && MedPassword.Password == "admin")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect login or password. Try again");
            }
        }
    }
}
