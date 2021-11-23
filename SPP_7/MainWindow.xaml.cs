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

namespace SPP_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GUIUpdateController controller;

        public MainWindow()
        {
            InitializeComponent();
            controller = new GUIUpdateController("F:\\Coding\\C#\\SPP_7\\", new List<DependencyObject>() { browser, searchLine, searchBtn }, this);
            controller.CheckNewElements();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                browser.Source = new Uri(searchLine.Text);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
