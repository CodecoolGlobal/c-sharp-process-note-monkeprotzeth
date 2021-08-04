using DevExpress.Utils.CommonDialogs.Internal;
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

namespace process_note
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //Alert user to save when closing
        private void windowClose(object sender, System.ComponentModel.CancelEventArgs e)
        {

            DialogResult dr = (DialogResult)MessageBox.Show("Don't forget to save your comments before exiting! Are you sure you wanna exit?", "Exit", MessageBoxButton.OKCancel);



            if (dr == DevExpress.Utils.CommonDialogs.Internal.DialogResult.OK) 
            {
                e.Cancel = false; //Close the form
            }
            else if (dr == DevExpress.Utils.CommonDialogs.Internal.DialogResult.Cancel)
            {
                e.Cancel = true; //No operation
            }

           
            }



        }

    }


