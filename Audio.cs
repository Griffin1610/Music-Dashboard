public class Audio
{
    private string title;
    private string author;
    private int year;
    private int durationInMinutes;
    private double rating;
    private string link;
    
    public Audio(string title, string author, int year, int durationInMinutes, double rating,string link)
    {
        Title = title;
        Author = author;
        Year = year;
        DurationInMinutes = durationInMinutes;
        Rating = rating;
        Link = link;
    }
    public override string ToString()
    {
        return $"{Title}, Author: {Author}, Year: {Year}, Duration: {DurationInMinutes}min, Rating: {Rating}/5";
    }
    public string Title { get => title; set => title = value; }
    public string Author { get=> author; set => author = value; }
    public int Year { get=> year; set => year = value; }
    public int DurationInMinutes { get=> durationInMinutes; set => durationInMinutes = value; }
    public double Rating { get => rating; set => rating = value; }
    public string Link { get; set; }

}
