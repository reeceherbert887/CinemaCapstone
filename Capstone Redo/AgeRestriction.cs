using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Redo
{
    public static class AgeRestriction
    {
        /// <summary>
        /// Within This Class, Holds The Methods To Handle Age Restrictions For Movie Ratings.
        /// </summary>

        public static bool VerifyAge(string rating, int age)
        {
            return rating switch
            {
                "U" => true, // Universal - Suitable For All Ages
                "PG" => age >= 0, // Parental Guidance - No Specific Age Restriction
                "12A" => age >= 12, // 12A - Suitable For Ages 12 And Above, But Children Under 12 Must Be Accompanied By An Adult
                "15" => age >= 15, // 15 - Suitable For Ages 15 And Above
                "18" => age >= 18, // 18 - Suitable For Adults Only
                _ => false // Unknown Rating
            };
        }
    }
}