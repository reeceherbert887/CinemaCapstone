public class Movie
{
    public string ID { get; set; }
    public string Title { get; set; }
    public int Length { get; set; } // in minutes
    public string Rating { get; set; }

    public Movie(string id, string title, int length, string rating)
    {
        ID = id;
        Title = title;
        Length = length;
        Rating = rating;
    }

    public override string ToString()
    {
        return $"{Title} - {Length} - Mins - Rated: {Rating}";
    }
}
