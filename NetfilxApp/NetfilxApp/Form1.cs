/*
    Netflix Database Application using N-Tier Design
    
    Jun H Lee
    U. of Illinois, Chicago
    CS 341, Spring 2017
    Projecct 08 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;

namespace NetfilxApp
{
    public partial class Form1 : Form
    {
        private string filename;
        public Form1()
        {
            InitializeComponent();
            this.NetfilxIcon.ImageLocation = "http://www.userlogos.org/files/netflix-n-logo-png.png?1471467147";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filename = this.txtFilename.Text;

            connectionTest(filename);
        }

        private bool fileExists(string filename)
        {
            if(!System.IO.File.Exists(filename))
            {
                string msg = string.Format("Input file not found: '{0}'", filename);

                MessageBox.Show(msg);
                return false;
            }

            return true;
        }
        private bool connectionTest(string dbfilename)
        {
            BusinessTier.Business biztier = new BusinessTier.Business(dbfilename);

            if(!biztier.TestConnection())
            {
                string msg = string.Format("Connection failed!!");

                MessageBox.Show(msg);
                return false;
            }          

            return true;
        }

        private void clearForm1()
        {
            this.ListDisplay.Items.Clear();
        }
        private void clearForm2()
        {
            this.ListDisplay2.Items.Clear(); 
        }

        private void button1_Click(object sender, EventArgs e)  // button for All Movies
        {
            filename = this.txtFilename.Text;
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;

            clearForm1();

            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            var movies = biztier.GetAllMovies();

            foreach(var movie in movies)
            {
                this.ListDisplay.Items.Add(movie.MovieName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filename = this.txtFilename.Text;
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;

            clearForm2();

            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            var users = biztier.GetAllNamedUsers();

            foreach(var user in users)
            { 
                this.ListDisplay2.Items.Add(user.UserName);
            }
        }

        private void GetMovieReview_Click(object sender, EventArgs e)
        {
            filename = this.txtFilename.Text;
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;
            if (this.ListDisplay.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a movie...");
                return;
            }

            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            int movieID = Convert.ToInt32(this.MovieIdBox.Text);

            var movieData = biztier.GetMovieDetail(movieID);
            
            if(movieData == null)
            {
                MessageBox.Show("Invalid movie ID!!"); return;
            }
            
            var movieReview = movieData.Reviews;
            
            string name = movieData.movie.MovieName;

            SubForm frm = new SubForm();
            frm.label_header.Text = String.Format("Reviews for \"{0}\"", name);

            frm.listBox1.Items.Add(name);
            frm.listBox1.Items.Add(" ");

            string line;
            string userID;
            string rate;
            foreach (var data in movieReview)
            {
                userID = data.UserID.ToString();
                rate = data.Rating.ToString();
                line = string.Format("{0}: {1}", userID, rate);

                frm.listBox1.Items.Add(line);
            }
            frm.listBox1.Items.Add(" ");

            frm.ShowDialog();
        }
        private void GetUserReview_Click(object sender, EventArgs e)
        {
            filename = this.txtFilename.Text;
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;
            if (this.ListDisplay2.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a user...");
                return;
            }

            string userId = this.userIdBox.Text;
            BusinessTier.Business biztier = new BusinessTier.Business(filename);
            
            var userDataList = biztier.GetUserDetail(Convert.ToInt32(userId));

            if (userDataList == null)
            {
                MessageBox.Show("Invalid User ID!!"); return;
            }

            string userName;
            if (userDataList.user.UserName.IndexOf(userDataList.user.UserID.ToString()) != -1)
                userName = "<anonymous>";
            else
                userName = userDataList.user.UserName;

            SubForm frm = new SubForm();
            frm.label_header.Text = String.Format("Reviews by \"{0}\"", userName);

            string movieName;
            int rate;
            string line;
            foreach(var review in userDataList.Reviews)
            {
                movieName = biztier.GetMovie(review.MovieID).MovieName;
                rate = review.Rating;

                line = String.Format("{0} : {1}", movieName, rate);

                frm.listBox1.Items.Add(line);
            }

            frm.ShowDialog();          
        }
        

        private void EachRate_Click(object sender, EventArgs e)
        {
            filename = this.txtFilename.Text;
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;
            if (this.ListDisplay.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a movie...");
                return;
            }

            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            int movieID = Convert.ToInt32(this.MovieIdBox.Text);

            var movieData = biztier.GetMovieDetail(movieID);

            if (movieData == null)
            {
                MessageBox.Show("Invalid movie ID!!"); return;
            }
            
            var movieReview = movieData.Reviews;

            int[] eachRating = {0,0,0,0,0};
            int totalCount = 0;

            foreach(var data in movieReview)
            {
                eachRating[data.Rating-1]++;
            }

            Array.Reverse(eachRating);            

            SubForm frm = new SubForm();
            frm.label_header.Text = string.Format("Each Rating for \"{0}\"", movieData.movie.MovieName);

            frm.listBox1.Items.Add(movieData.movie.MovieName);
            frm.listBox1.Items.Add(" ");

            int num = 5;
            foreach(int count in eachRating)
            {
                totalCount += count;
                frm.listBox1.Items.Add(String.Format("{0}: {1}", num--, Convert.ToString(count)));
            }

            frm.listBox1.Items.Add(" ");
            frm.listBox1.Items.Add(String.Format("Total: {0}", totalCount.ToString()));
            
            frm.ShowDialog();
        }

        private void ListDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            filename = this.txtFilename.Text;
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;
            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            string name = this.ListDisplay.Text;

            var movieData = biztier.GetMovie(name);
            if (movieData == null) { MessageBox.Show("Invalid input!!"); return; }
            int movieID = movieData.MovieID;

            var movieDetail = biztier.GetMovieDetail(movieID);
            if(movieDetail == null) { MessageBox.Show("Invalid input!!"); return; }
            double avg = movieDetail.AvgRating;
            
            this.MovieIdBox.Text = movieID.ToString();
            this.AvgRateBox.Text = avg.ToString("0.00");
        }

        private void ListDisplay2_SelectedIndexChanged(object sender, EventArgs e)
        {
            filename = this.txtFilename.Text;
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;
            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            string name = this.ListDisplay2.Text;

            var user = biztier.GetNamedUser(name);

            if(user == null)
            {
                MessageBox.Show("User ID not found..."); return;
            }
            
            this.userIdBox.Text = user.UserID.ToString();
            this.occupationBox.Text = user.Occupation.ToString();
        }

        private void TopNMovies_Click(object sender, EventArgs e)
        {
            filename = this.txtFilename.Text;
            string N = this.topNtxt1.Text;
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;

            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            var TopNList = biztier.GetTopMoviesByAvgRating(Convert.ToInt32(N));

            SubForm frm = new SubForm();
            frm.label_header.Text = "Top Movies by Average Rating";
            
            string line;
            foreach(var data in TopNList)
            {
                var avg = biztier.GetMovieDetail(data.MovieID);
                line = String.Format("{0}: {1}", data.MovieName, avg.AvgRating);
                frm.listBox1.Items.Add(line);
            }

            frm.ShowDialog();
        }
        private void TopNUsers_Click(object sender, EventArgs e)
        {
            filename = this.txtFilename.Text;
            string N = this.topNtxt1.Text;          
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;

            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            var TopNList = biztier.GetTopUsersByNumReviews(Convert.ToInt32(N));

            SubForm frm = new SubForm();
            frm.label_header.Text = "Top Users by Number of Reviews";

            string userName;
            string line;
            foreach(var data in TopNList)
            {
                var count = biztier.GetUserDetail(data.UserID);

                if ( data.UserName.IndexOf(data.UserID.ToString()) != -1)
                    userName = "<anonymous>";
                else
                    userName = data.UserName;

                line = String.Format("{0}: {1}", userName, count.NumReviews);
                frm.listBox1.Items.Add(line);
            }

            frm.ShowDialog();

        }
        private void TopNReview_Click(object sender, EventArgs e)
        {
            filename = this.txtFilename.Text;
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;
            string N = this.topNtxt1.Text;

            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            var TopNList = biztier.GetTopMoviesByNumReviews(Convert.ToInt32(N));

            SubForm frm = new SubForm();
            frm.label_header.Text = "Top Movies by Number of Reviews";

            string movieName;
            string movieCount;
            string line;
            foreach (var data in TopNList)
            {
                movieName = data.MovieName.ToString();
                movieCount = biztier.GetMovieDetail(data.MovieID).NumReviews.ToString();

                line = string.Format("{0}: {1}", movieName, movieCount);

                frm.listBox1.Items.Add(line);
            }
            
            frm.ShowDialog();
        }
        private void InsertReview_Click(object sender, EventArgs e)
        {
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;
            if (this.ListDisplay.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a movie...");
                return;
            }
            if (this.ListDisplay2.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a user...");
                return;
            }
            if (this.RatingBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a rating...");
                return;
            }

            filename = this.txtFilename.Text;
            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            string movieId = MovieIdBox.Text;      // MovieNameBox.Text;
            string userId = userIdBox.Text;
            string rating = RatingBox.Text;

            BusinessTier.Movie movie = biztier.GetMovie(Convert.ToInt32(movieId));
            BusinessTier.User user = biztier.GetUser(Convert.ToInt32(userId));

            if (movie == null)
            {
                MessageBox.Show(String.Format("ID: {0} not found..!", movieId)); return;
            }
            else if(user == null)
            {
                MessageBox.Show(String.Format("ID: {0} not found..!", userId)); return;
            }

            int rate = Convert.ToInt32(rating);
            if (rate < 1 || rate > 5)
            {
                MessageBox.Show("Rating is not in range..!"); return;
            }

            var result = biztier.AddReview(movie.MovieID, user.UserID, rate);

            if (result == null)
                MessageBox.Show("Insert failed...");
            else
                MessageBox.Show(String.Format("Insert Success with new Review ID: {0}", result.ReviewID.ToString()));
            
        }
        
        private void RatingBox_SelectedIndexChanged(object sender, EventArgs e) {  }
        private void dataFile_TextChanged(object sender, EventArgs e) { }

        private void FindMovieID_Click(object sender, EventArgs e)
        {
            filename = this.txtFilename.Text;
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;
            if (MovieIDTextBox.Text.Length == 0)
            {
                MessageBox.Show("please enter movie ID"); return;
            }

            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            string movieID = MovieIDTextBox.Text;

            var movieData = biztier.GetMovie(Convert.ToInt32(movieID));

            if(movieData == null)
            {
                MessageBox.Show("Invalid movie ID!!"); return;
            }

            string movieName = movieData.MovieName;

            string msg = String.Format("Movie Name: {0}", movieName);

            MessageBox.Show(msg);

        }

        private void FindUserID_Click(object sender, EventArgs e)
        {
            filename = this.txtFilename.Text;
            if (!fileExists(filename)) return;
            if (!connectionTest(filename)) return;
            if (UserIDTextBox.Text.Length == 0)
            {
                MessageBox.Show("please enter user ID"); return;
            }

            BusinessTier.Business biztier = new BusinessTier.Business(filename);

            string userID = UserIDTextBox.Text;

            var userData = biztier.GetUser(Convert.ToInt32(userID));

            if(userData == null)
            {
                MessageBox.Show("Invalid user ID!!"); return;
            }

            string userName;
            if (userData.UserName.IndexOf(userData.UserID.ToString()) != -1)
                userName = "<anonymous>";
            else
                userName = userData.UserName;

            string msg = string.Format("User Name: {0}", userName);

            MessageBox.Show(msg);

        }
    }
}
