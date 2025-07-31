using System;
using System.Collections.Generic;
using System.Linq;

namespace Capstone_Redo
{
    public static class ScheduleManager
    {
        private static List<Movie> Movies = new List<Movie>();
        private static List<Screen> Screens = new List<Screen>();
        private static List<Schedule> TodaySchedule = new List<Schedule>();
        public static List<Schedule> DailySchedule = new List<Schedule>();

        public static List<Schedule> GetTodaySchedule() => TodaySchedule;




        public static void InitializeSchedule()
        {
            Movies = FileManager.LoadMovies("CRMovies.txt");
            Screens = FileManager.LoadScreens("Data/CRScreens.txt");



            if (Movies.Count == 0 || Screens.Count == 0)
            {
                Console.WriteLine("No Movies Or Screens Available To Generate A Schedule.");
                return;
            }

            Random rng = new Random();
            int dayOffset = rng.Next(0, 7); // Simulate a day in the week
            DateTime simulatedDay = DateTime.Today.AddDays(dayOffset);
            int scheduleId = 1;

            foreach (var screen in Screens)
            {
                var shuffledMovies = Movies.OrderBy(x => rng.Next()).ToList();
                DateTime currentTime = simulatedDay.AddHours(10);

                foreach (var movie in shuffledMovies)
                {
                    if (currentTime.Hour >= 23) break;


                    // Calculate turnaround time
                    int totalSeats = screen.TotalSeats;
                    int turnaround = totalSeats <= 50 ? 15 : totalSeats <= 100 ? 30 : 45;

                    string scheduleIdStr = "SC" + scheduleId.ToString("D2");
                    TodaySchedule.Add(new Schedule(scheduleIdStr, movie.ID, currentTime, screen.ID));

                    currentTime = currentTime.AddMinutes(movie.Length + 20 + turnaround);
                    scheduleId++;
                }
            }
        }

        public static void LoadSchedule()
        {
            string path = "CRSchedule.txt";

            if (!File.Exists(path))
                return;

            string[] lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                try
                {
                    string[] parts = line.Split('%');

                    string id = parts[0].Replace("[ID:", "").Replace("]", "").Trim();
                    string movieId = parts[1].Replace("[MovieID:", "").Replace("]", "").Trim();
                    DateTime startTime = DateTime.Parse(parts[2].Replace("[StartTime:", "").Replace("]", "").Trim());
                    string screenId = parts[3].Replace("[ScreenID:", "").Replace("]", "").Trim();

                    TodaySchedule.Add(new Schedule(id, movieId, startTime, screenId));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Parsing Schedule Line: {line}");
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

        public static void DisplayTodaySchedule()
        {
            if (TodaySchedule.Count == 0)
            {
                Console.WriteLine("No Scheduled Screenings Today.");
                return;
            }

            Console.WriteLine("--- Today's Schedule ---");
            foreach (var s in TodaySchedule)
            {
                var movie = Movies.Find(m => m.ID == s.MovieID);
                if (movie != null)
                    Console.WriteLine($"{s.StartTime:hh\\:mm tt} - {movie.Title} - {movie.Length} Mins - Rated: {movie.Rating}");
            }
        }


        public static void ShowScreeningSchedule()
        {
            var movies = FileManager.LoadMovies("Data/CRMovies.txt");
            var todaySchedule = GetTodaySchedule(); // If you already store it in memory

            Console.WriteLine("--- Today's Screening Schedule ---");

            foreach (var screening in todaySchedule)
            {
                var movie = movies.FirstOrDefault(m => m.ID == screening.MovieID);
                if (movie != null)
                {
                    Console.WriteLine($"{screening.StartTime:hh\\:mm tt} - {movie.Title} - {movie.Length} mins - Rated: {movie.Rating} | Screen: {screening.ScreenID}");
                }
            }
        }


        public static void ScheduleMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("--- Schedule Menu ---");
                Console.WriteLine("1. View Today's Schedule");
                Console.WriteLine("2. Add New Screening");
                Console.WriteLine("3. Save Schedule");
                Console.WriteLine("4. Exit Schedule Menu");
                Console.Write("Select An Option: ");
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        DisplayTodaySchedule(); // Fixed: Use the correct method name
                        break;
                    case "2":
                        AddNewScreening();
                        break;
                    case "3":
                        SaveSchedule();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Exiting Schedule Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid Option. Try Again.");
                        break;
                }
            }
        }

        public static void AddNewScreening()
        {
            var movies = Movies; // Use already-loaded list
            var screens = Screens;
            var times = new List<string> { "10:00 AM", "12:00 PM", "2:00 PM", "4:00 PM", "6:00 PM", "8:00 PM" };

            Console.WriteLine($"Loaded {movies.Count} movies and {screens.Count} screens.");

            if (movies.Count == 0 || screens.Count == 0)
            {
                Console.WriteLine("No movies or screens available.");
                return;
            }

            // Prompt for user age
            int userAge;
            do
            {
                Console.Write("Enter your age: ");
            } while (!int.TryParse(Console.ReadLine(), out userAge) || userAge < 0);

            int movieIndex = -1;
            bool validMovieSelected = false;
            while (!validMovieSelected)
            {
                // Display movies with age ratings
                Console.WriteLine("Select a Movie:");
                for (int i = 0; i < movies.Count; i++)
                    Console.WriteLine($"{i + 1}. {movies[i].Title} (Rating: {movies[i].Rating})");

                if (!int.TryParse(Console.ReadLine(), out movieIndex) || movieIndex < 1 || movieIndex > movies.Count)
                {
                    Console.WriteLine("Invalid movie selection. Please try again.");
                    continue;
                }

                var selectedMovie = movies[movieIndex - 1];
                int requiredAge = GetRequiredAge(selectedMovie.Rating);

                if (userAge < requiredAge)
                {
                    Console.WriteLine($"You must be at least {requiredAge} to watch {selectedMovie.Title}. Please select another movie.");
                }
                else
                {
                    validMovieSelected = true;
                    // Continue with screen and time selection
                    Console.WriteLine("Select a Screen:");
                    for (int i = 0; i < screens.Count; i++)
                        Console.WriteLine($"{i + 1}. {screens[i].ID}");

                    int screenIndex;
                    if (!int.TryParse(Console.ReadLine(), out screenIndex) || screenIndex < 1 || screenIndex > screens.Count)
                    {
                        Console.WriteLine("Invalid screen selection.");
                        return;
                    }

                    Console.WriteLine("Select a Time:");
                    for (int i = 0; i < times.Count; i++)
                        Console.WriteLine($"{i + 1}. {times[i]}");

                    int timeIndex;
                    if (!int.TryParse(Console.ReadLine(), out timeIndex) || timeIndex < 1 || timeIndex > times.Count)
                    {
                        Console.WriteLine("Invalid time selection.");
                        return;
                    }

                    var selectedScreen = screens[screenIndex - 1];
                    var selectedTime = DateTime.Parse(times[timeIndex - 1]);
                    string scheduleId = "SC" + (DailySchedule.Count + 1).ToString("D2");

                    DailySchedule.Add(new Schedule(scheduleId, selectedMovie.ID, selectedTime, selectedScreen.ID));
                    Console.WriteLine($"Screening added: {selectedMovie.Title} at {selectedTime} on Screen {selectedScreen.ID}");
                }
            }
        }
        public static void SaveSchedule()
        {
            FileManager.SaveSchedule("CRSchedule.txt", DailySchedule);
            Console.WriteLine("Schedule saved.");
        }



        // Helper method to map rating to required age
        private static int GetRequiredAge(string rating)
        {
            return rating switch
            {
                "PG" => 0,
                "12" => 12,
                "13" => 13,
                "15" => 15,
                "18" => 18,
                _ => 0
            };
        }
    }
}