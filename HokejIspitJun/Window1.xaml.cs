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

namespace HokejIspitJun
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtIme1.Text.Length == 0 || txtIme2.Text.Length == 0)
            {
                MessageBox.Show("Prazna polja ne smeju biti");

            }
            else
            {
                string ime1 = txtIme1.Text.ToString();
                string ime2 = txtIme2.Text.ToString();

                IgrajHokej igh = new IgrajHokej(ime1, ime2);
                igh.Show();
            }
        }
    }
}
