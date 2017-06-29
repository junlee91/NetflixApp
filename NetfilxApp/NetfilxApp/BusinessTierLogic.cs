//
// BusinessTier:  business logic, acting as interface between UI and data store.
//

using System;
using System.Collections.Generic;
using System.Data;


namespace BusinessTier
{

  //
  // Business:
  //
  public class Business
  {
    //
    // Fields:
    //
    private string _DBFile;
    private DataAccessTier.Data dataTier;


    //
    // Constructor:
    //
    public Business(string DatabaseFilename)
    {
      _DBFile = DatabaseFilename;

      dataTier = new DataAccessTier.Data(DatabaseFilename);
    }


    //
    // TestConnection:
    //
    // Returns true if we can establish a connection to the database, false if not.
    //
    public bool TestConnection()
    {
      return dataTier.TestConnection();
    }


    //
    // GetUser:
    //
    // Retrieves User object based on USER ID; returns null if user is not
    // found.
    //
    // NOTE: if the user exists in the Users table, then a meaningful name and 
    // occupation are returned in the User object.  If the user does not exist 
    // in the Users table, then the user id has to be looked up in the Reviews 
    // table to see if he/she has submitted 1 or more reviews as an "anonymous"
    // user.  If the id is found in the Reviews table, then the user is an
    // "anonymous" user, so a User object with name = "<UserID>" and no occupation
    // ("") is returned.  In other words, name = the user’s id surrounded by < >.
    //
    public User GetUser(int UserID)
    {
            string sql = string.Format("Select * From Users Where UserID = {0}", UserID);

            DataSet userData = dataTier.ExecuteNonScalarQuery(sql);
            DataTable dt = userData.Tables["TABLE"];

            if (dt.Rows.Count == 0)                 // not in users table
            {
                string sql2 = string.Format("Select * From Reviews Where UserID = {0}", UserID);
                DataSet userData2 = dataTier.ExecuteNonScalarQuery(sql2);
                DataTable dt2 = userData2.Tables["Table"];

                if(dt2.Rows.Count == 0)             // also not int reviews table
                {
                    return null;
                }
                else
                {
                    string userName = string.Format("<anonymous>");

                    User s = new User(UserID, userName, null);

                    return s;
                }
            }
            else       // in users table
            {
                foreach(DataRow row in dt.Rows)
                {
                    string userName = row["UserName"].ToString();
                    string occupation = row["Occupation"].ToString();

                    User s = new User(UserID, userName, occupation);

                    return s;
                }
            }

            return null;
    }


    //
    // GetNamedUser:
    //
    // Retrieves User object based on USER NAME; returns null if user is not
    // found.
    //
    // NOTE: there are "named" users from the Users table, and anonymous users
    // that only exist in the Reviews table.  This function only looks up "named"
    // users from the Users table.
    //
    public User GetNamedUser(string UserName)
    {
            UserName = UserName.Replace("'", "''");
            string sql = string.Format("Select * From Users Where UserName = '{0}'", UserName);

            DataSet userData = dataTier.ExecuteNonScalarQuery(sql);
            DataTable dt = userData.Tables["TABLE"];

            if(dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                foreach(DataRow row in dt.Rows)
                {
                    int userid = Convert.ToInt32(row["UserID"].ToString());
                    string occupation = row["Occupation"].ToString();

                    User s = new User(userid, UserName, occupation);

                    return s;
                }
            }

            return null;
    }


    //
    // GetAllNamedUsers:
    //
    // Returns a list of all the users in the Users table ("named" users), sorted 
    // by user name.
    //
    // NOTE: the database also contains lots of "anonymous" users, which this 
    // function does not return.
    //
    public IReadOnlyList<User> GetAllNamedUsers()
    {
      List<User> users = new List<User>();
      
            string sql = string.Format("SELECT * FROM Users ORDER BY UserName ASC;");

            DataSet userData = dataTier.ExecuteNonScalarQuery(sql);
            DataTable dt = userData.Tables["TABLE"];
            
            foreach (DataRow row in dt.Rows)
            {
                int userid = Convert.ToInt32(row["UserID"].ToString());
                string username = row["UserName"].ToString();
                string occupation = row["Occupation"].ToString();

                User s = new User(userid, username, occupation);

                users.Add(s);
            }

      return users;
    }

    public IReadOnlyList<Movie> GetAllMovies()
    {
            List<Movie> movies = new List<Movie>();

            string sql = string.Format("Select * From Movies Order By MovieName ASC");

            DataSet userData = dataTier.ExecuteNonScalarQuery(sql);
            DataTable dt = userData.Tables["TABLE"];

            foreach(DataRow row in dt.Rows)
            {
                int movieid = Convert.ToInt32(row["MovieID"].ToString());
                string moviename = row["MovieName"].ToString();

                Movie m = new Movie(movieid, moviename);

                movies.Add(m);
            }

            return movies;
    }


    //
    // GetMovie:
    //
    // Retrieves Movie object based on MOVIE ID; returns null if movie is not
    // found.
    //
    public Movie GetMovie(int MovieID)
    {
            string sql = string.Format("Select * From Movies Where MovieID = {0}", MovieID);

            DataSet movieData = dataTier.ExecuteNonScalarQuery(sql);
            DataTable dt = movieData.Tables["Table"];

            if(dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                foreach(DataRow row in dt.Rows)
                {
                    string moviename = row["MovieName"].ToString();

                    Movie m = new Movie(MovieID, moviename);

                    return m;
                }
            }

      return null;      
    }


    //
    // GetMovie:
    //
    // Retrieves Movie object based on MOVIE NAME; returns null if movie is not
    // found.
    //
    public Movie GetMovie(string MovieName)
    {
            MovieName = MovieName.Replace("'", "''");
            string sql = string.Format("Select * From Movies Where MovieName = '{0}'", MovieName);

            DataSet movieData = dataTier.ExecuteNonScalarQuery(sql);
            DataTable dt = movieData.Tables["Table"];

            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    int MovieID = Convert.ToInt32(row["MovieID"].ToString());

                    Movie m = new Movie(MovieID, MovieName);

                    return m;
                }
            }

            return null;
        }


    //
    // AddReview:
    //
    // Adds review based on MOVIE ID, returning a Review object containing
    // the review, review's id, etc.  If the add failed, null is returned.
    //
    public Review AddReview(int MovieID, int UserID, int Rating)
    {
            string sql = string.Format(@"Insert Into Reviews(MovieID, UserID, Rating) Values({0}, {1}, {2});
                Select ReviewID From Reviews Where ReviewID = SCOPE_IDENTITY();",
                MovieID, UserID, Rating);

                object result = dataTier.ExecuteScalarQuery(sql);

            if(result == null)
            {
                return null;
            }

            int ReviewID = Convert.ToInt32(result.ToString());

            Review r = new Review(ReviewID, MovieID, UserID, Rating);
                  
      return r;
    }


    //
    // GetMovieDetail:
    //
    // Given a MOVIE ID, returns detailed information about this movie --- all
    // the reviews, the total number of reviews, average rating, etc.  If the 
    // movie cannot be found, null is returned.
    //
    public MovieDetail GetMovieDetail(int MovieID)
    {
            string moviename ="";
            
            string sql = string.Format("Select MovieName From Movies Where MovieID = {0}", MovieID);

            DataSet movieData = dataTier.ExecuteNonScalarQuery(sql);
            DataTable dt = movieData.Tables["Table"];

            if(dt.Rows.Count == 0)  // not found
            {
                return null;
            }
            else
            {
                foreach(DataRow row in dt.Rows)
                {
                    moviename = row["MovieName"].ToString();
                }                
            }

            Movie m = new Movie(MovieID, moviename);

            string sql2 = string.Format(@"SELECT ROUND(AVG(CAST(Rating AS Float)), 4) AS AvgRating 
                        FROM Reviews Where MovieID = {0};", MovieID);
                        
            object result = dataTier.ExecuteScalarQuery(sql2);

            double avgRating;
            if(result == null)
            {
                avgRating = 0.0;
            }
            else
            {
                avgRating = Convert.ToDouble(result.ToString());
            }

            string sql3 = string.Format(@"Select Count(*) As Total From Reviews 
                                    Where MovieID = {0};", MovieID);

            object result2 = dataTier.ExecuteScalarQuery(sql3);

            int numReviews;
            if(result2 == null)
            {
                numReviews = 0;
            }
            else
            {
                numReviews = Convert.ToInt32(result2.ToString());
            }

            string sql4 = string.Format(@"Select * From Reviews Where MovieID = {0} Order By Rating DESC, UserID ASC", MovieID);

            DataSet reviewData = dataTier.ExecuteNonScalarQuery(sql4);
            DataTable dt2 = reviewData.Tables["Table"];

            List<Review> reviews = new List<Review>();

            if (dt2.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (DataRow row in dt2.Rows)
                {
                    int reviewid = Convert.ToInt32(row["ReviewID"].ToString());
                    int userid = Convert.ToInt32(row["UserID"].ToString());
                    int rating = Convert.ToInt32(row["Rating"].ToString());

                    Review r = new Review(reviewid, MovieID, userid, rating);

                    reviews.Add(r);
                }
            }

            MovieDetail md = new MovieDetail(m, avgRating, numReviews, reviews);

      return md;
    }


    //
    // GetUserDetail:
    //
    // Given a USER ID, returns detailed information about this user --- all
    // the reviews submitted by this user, the total number of reviews, average 
    // rating given, etc.  If the user cannot be found, null is returned.
    //
    public UserDetail GetUserDetail(int UserID)
    {
            User u = GetUser(UserID);

            if(u == null)
            {
                return null;
            }

            int numReviews;
            double avgRating;

            string sql = string.Format(@"SELECT ROUND(AVG(CAST(Rating AS Float)), 2) AS AvgRating 
                        FROM Reviews Where UserID = {0};", UserID);

            object result = dataTier.ExecuteScalarQuery(sql);

            if(result == null)
            {
                avgRating = 0.0;
            }
            else
            {
                avgRating = Convert.ToDouble(result.ToString());
            }

            string sql2 = string.Format(@"Select Count(*) As Total From Reviews 
                                    Where UserID = {0};", UserID);

            object result2 = dataTier.ExecuteScalarQuery(sql2);

            if(result2 == null)
            {
                numReviews = 0;
            }
            else
            {
                numReviews = Convert.ToInt32(result2.ToString());
            }


            string sql3 = string.Format(@"Select * From Reviews 
                                        Inner Join Movies On Reviews.MovieID = Movies.MovieID
                                        Where UserID = {0}
                                        Order By Movies.MovieName ASC, Rating ASC", UserID);

            DataSet reviewData = dataTier.ExecuteNonScalarQuery(sql3);
            DataTable dt2 = reviewData.Tables["Table"];

            List<Review> reviews = new List<Review>();

            if (dt2.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (DataRow row in dt2.Rows)
                {
                    int movieid = Convert.ToInt32(row["MovieID"].ToString());
                    int reviewid = Convert.ToInt32(row["ReviewID"].ToString());
                    int rating = Convert.ToInt32(row["Rating"].ToString());

                    Review r = new Review(reviewid, movieid, UserID, rating);

                    reviews.Add(r);
                }
            }

            UserDetail ud = new UserDetail(u, avgRating, numReviews, reviews);
            
            return ud;
    }

    //
    // GetTopMoviesByAvgRating:
    //
    // Returns the top N movies in descending order by average rating.  If two
    // movies have the same rating, the movies are presented in ascending order
    // by name.  If N < 1, an EMPTY LIST is returned.
    //
    public IReadOnlyList<Movie> GetTopMoviesByAvgRating(int N)
    {
      List<Movie> movies = new List<Movie>();

            if (N < 1) return null;
            
            string sql = string.Format(@"SELECT TOP {0} Movies.MovieName, g.AvgRating 
            FROM Movies
            INNER JOIN 
              (
                SELECT MovieID, ROUND(AVG(CAST(Rating AS Float)), 4) as AvgRating 
                FROM Reviews
                GROUP BY MovieID
              ) g
            ON g.MovieID = Movies.MovieID
            ORDER BY g.AvgRating DESC, Movies.MovieName Asc;",
        N);

            DataSet result = dataTier.ExecuteNonScalarQuery(sql);
            DataTable dt = result.Tables["Table"];

            foreach(DataRow row in dt.Rows)
            {
                string movieName = row["MovieName"].ToString();
                int movieid = GetMovie(movieName).MovieID;

                Movie m = new Movie(movieid, movieName);

                movies.Add(m);
            }

       return movies;
    }

    //
    // GetTopMoviesByNumReviews
    //
    // Returns the top N movies in descending order by number of reviews.  If
    // two movies have the same number of reviews, the movies are presented in
    // ascending order by name.  If N < 1, an EMPTY LIST is returned.
    //
    public IReadOnlyList<Movie> GetTopMoviesByNumReviews(int N)
    {
      List<Movie> movies = new List<Movie>();

            if (N < 1) return null;

            string sql = string.Format(@"Select Top {0} MovieName, Count(*) As Total 
                            From Reviews Inner Join Movies On Movies.MovieID = Reviews.MovieID 
                            Group By MovieName 
                            Order By Total DESC, MovieName ASC", N);

            DataSet result = dataTier.ExecuteNonScalarQuery(sql);
            DataTable dt = result.Tables["Table"];

            foreach (DataRow row in dt.Rows)
            {
                string moviename = row["MovieName"].ToString();
                int movieid = GetMovie(moviename).MovieID;

                Movie m = new Movie(movieid, moviename);

                movies.Add(m);
            }

       return movies;
    }


    //
    // GetTopUsersByNumReviews
    //
    // Returns the top N users in descending order by number of reviews.  If two
    // users have the same number of reviews, the users are presented in ascending
    // order by user id.  If N < 1, an EMPTY LIST is returned.
    //
    // NOTE: not all user ids map to users in the Users table.  User ids that don't
    // map are considered "anonymous" users, and returned with their name = to their
    // userid ("<UserID>") and no occupation ("").
    //
    public IReadOnlyList<User> GetTopUsersByNumReviews(int N)
    {
      List<User> users = new List<User>();

            if (N < 1) return null;

      //
      // execute query to rank users:
      //
      // NOTE: some reviews are anonymous, i.e. don't have an entry in the Users
      // table.  So we use a "RIGHT JOIN" to capture those as well.
      //
      string sql = string.Format(@"SELECT TOP {0} Temp.UserID, Users.UserName, Users.Occupation
            FROM Users
            RIGHT JOIN
            (
              SELECT UserID, COUNT(*) AS RatingCount
              FROM Reviews
              GROUP BY UserID
            ) AS Temp
            On Temp.UserID = Users.UserID
            ORDER BY Temp.RatingCount DESC, Users.UserName Asc;",
        N);

            //
            // Now execute this query...  In the resulting dataset, the anonymous users will
            // have a UserName of "" because the result of the join was NULL.  So when you
            // come across a user with "" as their name, create a new User based on their user
            // id, i.e. string.Format("<{0}>", userid);
            //


            DataSet result = dataTier.ExecuteNonScalarQuery(sql);

            DataTable dt = result.Tables["TABLE"];
                
            if(dt.Rows.Count == 0)
            {
                // error
                return null;
            }
            else
            {
                foreach(DataRow row in dt.Rows)
                {
                    string userid = row["UserID"].ToString();
                    string userName = row["UserName"].ToString();
                    string occupation = row["Occupation"].ToString();

                    if(userName == "")
                    {
                        userName = string.Format("<{0}>", userid.ToString());
                        occupation = "";
                    }

                    User s = new User(Convert.ToInt32(userid), userName, occupation);

                    users.Add(s);
                }
            }

      return users;
    }

  }//class
}//namespace
