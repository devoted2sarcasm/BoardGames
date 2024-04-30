namespace boardgames.Models;

public class BoardGame
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int MinPlayers { get; set; }

    public int MaxPlayers { get; set; }

    public string? Description { get; set; }

    public int? Difficulty { get; set; }

    public int? Rank { get; set; }

    public int? IdealPlayerCount { get; set; }

    public int? Playtime { get; set; }
    
}