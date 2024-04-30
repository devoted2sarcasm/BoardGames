using System.ComponentModel.DataAnnotations;

namespace boardgames.Models;

public class GamePlayed
{
    public int Players { get; set; }

    public int Game_Id { get; set; }

    public string Winner { get; set; }

    public TimestampAttribute Date { get; set; }

    public List<Score> Scores { get; set; }

    public string? Comments { get; set; }
}