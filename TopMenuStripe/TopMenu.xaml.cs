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
using AttributesLibraryForSPP7;

namespace TopMenuStripe
{
    /// <summary>
    /// Логика взаимодействия для TopMenu.xaml
    /// </summary>
    [LeftSpanInLinesAttribute(0)]
    [WidthInLinesAttributes(12)]
    [TopSpanInLinesAttribute(0)]
    [HeightInLinesAttribute(1)]
    public partial class TopMenu : UserControl
    {
        public WebBrowser Browser { get; set; }

        public TopMenu()
        {
            InitializeComponent();
        }

        private void Backward_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Browser?.GoBack();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            try {
                Browser?.GoForward();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
