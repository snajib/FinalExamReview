//Sammy Najib
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

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            txtScore.Text = "0";
            List<string> genres = new List<string>();
            foreach (var movie in movieList)
            {
                var genreAttr = movie.genres.Split('|');

                //genre
                foreach (var genre in genreAttr)
                {
                    if(!genres.Contains(genre))
                    {
                        genres.Add(genre);
                        lstGenres.Items.Add(genre);
                    }
                    
                //350k voted users
                if(movie.num_voted_users > 350000)
                    {
                        lstVoted.Items.Add(movie.movie_title);
                    }    

                //highest IMDB score
                if(movie.imdb_score > Convert.ToDouble(txtScore.Text))
                    {
                        txtScore.Text = movie.imdb_score.ToString();
                    }

                }
            }

            


            //350k voted users
            
        }
    }
}
