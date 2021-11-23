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

namespace LeftNavigationPanel
{
    /// <summary>
    /// Логика взаимодействия для LeftNavigationPanel.xaml
    /// </summary>
    [LeftSpanInLinesAttribute(0)]
    [WidthInLinesAttributes(2)]
    [TopSpanInLinesAttribute(2)]
    [HeightInLinesAttribute(10)]
    public partial class LeftNavigationPanel : UserControl
    {
        public WebBrowser Browser { get; set; }

        public LeftNavigationPanel()
        {
            InitializeComponent();
        }

        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Browser.Source = new Uri(DefineLink(((Button)sender).Name));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string DefineLink(string siteName)
        {
            switch (siteName)
            {
                case "praca":
                    return "https://rabota.by/";
                case "math":
                    return "https://math.semestr.ru/";
                case "translate":
                    return "https://translate.google.lv/";
                case "news":
                    return "https://news.google.com/topstories?hl=ru&gl=RU&ceid=RU:ru";
                default:
                    return "https://www.google.by/";
            }
        }
    }
}
