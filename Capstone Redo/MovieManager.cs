using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Redo
{
    public static  class MovieManager
    {
        private static List<Movie> AllMovies = new List<Movie>();


    public static void InitializeMovies() 
        {
            AllMovies  = FileManager.LoadMovies("CRMovies.txt");
        }

        public static void DisplayMovies()
        {
            Console.WriteLine("--- Movies ---");
            foreach (var m in AllMovies)
            {
                Console.WriteLine($"{m.ID} - {m.Title}");
            }
        }

        public static Movie GetMovieByID(string id)
        {
            return AllMovies.FirstOrDefault(m => m.ID.Equals(id, StringComparison.OrdinalIgnoreCase));
        }
    }
}
