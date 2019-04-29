using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

namespace FinalExamReview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Movie> movieList = new List<Movie>();

        public MainWindow()
        {
           

            InitializeComponent();

            string path = @"http://pcbstuou.w27.wh-2.com/webservices/3033/api/Movies?number=100";

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(path).Result;
                if(response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var movList = JsonConvert.DeserializeObject<List<Movie>>(content);

                    foreach (var mov in movList)
                    {
                        movieList.Add(mov);
                    }
                }
                
                
            }
 
        }


    }
}
