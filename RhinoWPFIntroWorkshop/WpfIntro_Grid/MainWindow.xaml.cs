using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfIntro_Grid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public List<ObjectAttribute> objects = new List<ObjectAttribute>();
        public Log LogObject { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
            
            objects.Add(new ObjectAttribute { Name = "SurfaceName", ObjectType = "Surface" });
            objects.Add(new ObjectAttribute { Name = "ExtrudionName", ObjectType = "Extrude" });
            objects.Add(new ObjectAttribute { Name = "SurfaceName2", ObjectType = "Surface" });

            LogObject = new Log { LogList = new ObservableCollection<string>() };
            DataContext = LogObject;





        }

        private void Button_Click_Line(object sender, RoutedEventArgs e)
        {
            string Length = MySlider.Value.ToString();
            string Name = ObjectName.Text;
            string log = string.Format( "Line : Name {0}, Length {1} is created", Name,Length);
            LogObject.LogList.Add(log);
        }

        private void Button_Click_Circle(object sender, RoutedEventArgs e)
        {
            string Radius = MySlider2.Value.ToString();
            string Name = ObjectName.Text;
            string log = string.Format("Circle : Name {0}, Length {1} is created", Name, Radius);
            LogObject.LogList.Add(log);
        }

    

        private void Button_Click_Select(object sender, RoutedEventArgs e)
        {
            SelectedObjects.ItemsSource = objects;
        }
    }
}
