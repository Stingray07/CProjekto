public class Player
{
    public int Id {get; set;}
    public required string SummonerId {get; set;}
    public required string SummonerName {get; set;}
    public required string Region {get; set;}
    public int ProfileIconId {get; set;}
    public int Level {get; set;}
    public DateTime LastUpdated {get; set;}


    public required ICollection<Match> Matches {get; set;}
}