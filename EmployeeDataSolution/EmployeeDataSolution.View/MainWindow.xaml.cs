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

namespace EmployeeDataSolution.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Hiding the error element so that on load error is not shown in the fields
            txtboxAge.Tag = Visibility.Collapsed;
            txtboxId.Tag = Visibility.Collapsed;
            txtboxName.Tag = Visibility.Collapsed;

            //on user input showing the error element
            txtboxAge.TextChanged += txtboxAge_TextChanged;
            txtboxId.TextChanged += txtboxId_TextChanged;
            txtboxName.TextChanged += txtboxname_TextChanged;
        }

        private void txtboxAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtboxAge.Tag = Visibility.Visible;
            txtboxAge.TextChanged -= txtboxAge_TextChanged;
        }

        private void txtboxId_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtboxId.Tag = Visibility.Visible;
            txtboxId.TextChanged -= txtboxId_TextChanged;
        }

        private void txtboxname_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtboxName.Tag = Visibility.Visible;
            txtboxName.TextChanged -= txtboxname_TextChanged;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            //show the error element if user clicks on button without entering any data
            txtboxAge.Tag = Visibility.Visible;
            txtboxId.Tag = Visibility.Visible;
            txtboxName.Tag = Visibility.Visible;
            grdInput.PreviewMouseDown -= OkButton_Click;
        }
    }

}
