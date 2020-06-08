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
using RhinoWpfIntro.ViewModels;

namespace RhinoWpfIntro.Views
{
    /// <summary>
    /// Interaction logic for WpfPanel.xaml
    /// </summary>
    public partial class RhinoWpfIntroPanel
    {
        public RhinoWpfIntroPanel(uint documentSerialNumber)
        {
            DataContext = new RhinoWpfIntroViewModel(documentSerialNumber);
            InitializeComponent(); 
        }

        private RhinoWpfIntroViewModel ViewModel => DataContext as RhinoWpfIntroViewModel;

        private void Button_Click_Line(object sender, RoutedEventArgs e)
        {
            Rhino.RhinoApp.RunScript(string.Format("_Line 0,0,0 {0},{0},0", MySlider.Value.ToString()), false);
           // MessageBox.Show("Line");
        }
        private void Button_Click_Circle(object sender, RoutedEventArgs e)
        {
            Rhino.RhinoApp.RunScript("_Circle 0,0,0 "+ MySlider2.Value.ToString(), false);
            //MessageBox.Show("Circle");
        }
 
    }
}
