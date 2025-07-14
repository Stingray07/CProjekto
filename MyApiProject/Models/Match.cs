public class Match
{
    public required string MatchId { get; set; }
    public DateTime GameCreation { get; set; }
    public int ChampionId { get; set; }
    public bool Win { get; set; }
    public int Kills {get; set;}
    public int Deaths {get; set;}
    public int Assists {get; set;}

    public int PlayerId {get; set;}
    public required Player Player {get; set;}
}