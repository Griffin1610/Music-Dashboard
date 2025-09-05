public class Podcast
{
    private string title;
    private string host;
    private int year;
    private int durationInMinutes;
    private double rating;
    private string link;

    // Constructor
    public Podcast(string title, string host, int year, int durationInMinutes, double rating, string link)
    {
        Title = title;
        Host = host;
        Year = year;
        DurationInMinutes = durationInMinutes;
        Rating = rating;
        Link = link;
    }

    // ToString method
    public override string ToString()
    {
        return $"{Title}, Host: {Host}, Year: {Year}, Duration: {DurationInMinutes}min, Rating: {Rating}/10";
    }

    public string Title { get => title; set=> title = value; }
    public string Host { get => host; set => host = value; }
    public int Year { get => year; set=> year = value; }
    public int DurationInMinutes { get => durationInMinutes; set=> durationInMinutes = value; }
    public double Rating { get => rating; set=> rating = value; }
    public string Link { get => link; set=> link = value; }
}
