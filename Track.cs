public class Track
{
    private string title;
    private string artist;
    private string album;
    private int year;
    private int durationInSeconds;
    private int rollingStoneChartPosition;
    private string link;
    private string image;
    // Constructor
    public Track(string title, string artist, string album, int year, int durationInSeconds, int rollingStoneChartPosition,string link, string image)
    {
        Title = title;
        Artist = artist;
        Album = album;
        Year = year;
        DurationInSeconds = durationInSeconds;
        RollingStoneChartPosition = rollingStoneChartPosition;
        Link = link;
        Image = image;
        
    }

    // ToString method
    public override string ToString()
    {
        return $"{Title}, Artist: {Artist}, Album: {Album}, Year: {Year}, Duration: {DurationInSeconds}s, RS Chart Position: {RollingStoneChartPosition}";
    }
    public string Title { get => title; set=> title = value; }
    public string Artist { get => artist; set=> artist = value; }
    public string Album { get => album; set=> album = value; }
    public int Year { get => year; set=> year = value; }
    public int DurationInSeconds { get => durationInSeconds; set=> durationInSeconds = value; }
    public int RollingStoneChartPosition { get => rollingStoneChartPosition; set=> rollingStoneChartPosition = value; }
    public string Link { get => link; set=> link = value; }
    public string Image { get => image; set=> image = value; }
}
