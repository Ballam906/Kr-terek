using System;
using System.Collections.Generic;
using System.IO;
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

namespace Kráterek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Krater> lista = new List<Krater>();
        public MainWindow()
        {
            InitializeComponent();
            beolvas();




            //var max = lista.Max(item => item.R, );
            var max = lista[0].R;
            var nev = lista[0].Nev;
            foreach (var item in lista) {
                if (item.R > max) { 
                    max = item.R;
                    nev = item.Nev;
                }

            }
            Label2.Content =  $"A legnagyobb kráter neve és sugara: {nev} , {max}";
            

        }

        private void beolvas()
        {
            using (var sr = new StreamReader("felszin.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine().Split('\t');
                    var krater = new Krater(double.Parse(sor[0]), double.Parse(sor[1]), double.Parse(sor[2]), sor[3]);
                    lista.Add(krater);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var index = -1;
            foreach (var item in lista) {
                if (item.Nev == Textbox1.Text) {
                    index = lista.IndexOf(item);
                    break;
                }
              
            }

            if (index >= 0)
            {
                Label1.Content=lista[index].ToString();
            }
            else
            {
                Label1.Content = "Nincs ilyen nevű kráter!";
            }
        }
    }
}
