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
using System.Windows.Shapes;

namespace VetClinicApplication
{
    /// <summary>
    /// Interaction logic for EditPatientWindow.xaml
    /// </summary>
    public partial class EditPatientWindow : Window
    {   
        public EditPatientWindow()
        {
            InitializeComponent();
            
        }
     
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
       
    }
}
