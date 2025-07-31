using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Redo
{
    public class Schedule
    {
        public string ScreenID { get; set; } // ID Of The Screen IE: S01
        public string ID { get; set; } // Unique Identifier For The Schedule IE: S01
        public string MovieID { get; set; } // ID Of The Movie Scheduled IE: M01

        public System.DateTime StartTime { get; set; } // Start Time Of The Movie IE: 2023-10-01 14:00:00

        public Schedule(string id, string movieId, System.DateTime startTime, string screenID)
        {
            ID = id;
            MovieID = movieId;
            StartTime = startTime;
            ScreenID = screenID;
        }

        public override string ToString()
        {
            return $"[{ID}] {MovieID} at {StartTime:hh:mm tt} On Screen {ScreenID}";
        }
    }
}