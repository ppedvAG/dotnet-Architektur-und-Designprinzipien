using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using System.Xml.Serialization;

namespace WPF_GoogleBooks
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

        private async void Suchen(object sender, RoutedEventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={suchTb.Text}";

            var http = new HttpClient();
            var json = await http.GetStringAsync(url);

            jsonTb.Text = json;

            GoogleBooksResult result = JsonConvert.DeserializeObject<GoogleBooksResult>(json);

            myGrid.ItemsSource = result.items.Select(x => x.volumeInfo).ToList();

        }

        private void ExportXML(object sender, RoutedEventArgs e)
        {
            using (var sw = new StreamWriter("books.xml"))
            {
                var serial = new XmlSerializer(typeof(List<Volumeinfo>));
                serial.Serialize(sw, myGrid.ItemsSource);
            }
        }
    }
}
