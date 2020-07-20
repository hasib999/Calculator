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

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BLClass bl = new BLClass();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFromDB_Click(object sender, RoutedEventArgs e)
        {
            //call BL Class
            String result = bl.DoThingFromDB();
            this.rtbDBResult.AppendText(result + Environment.NewLine);
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            //call BL class
            int num1 = Int32.Parse(txtNum1.Text);
            int num2 = Int32.Parse(txtNum2.Text);
            int result = bl.Operate(num1, num2, "+");
            this.rtbDBResult.AppendText(num1 + "+" + num2 + "=" + result + Environment.NewLine);
        }
    }
}
