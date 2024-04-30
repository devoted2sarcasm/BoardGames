using System.Collections.Generic;
using System.Threading.Tasks;
using boardgames.Models;


namespace boardgames.Services
{
    public interface IGameApiService
    {
        Task<List<BoardGame>> GetGames();

        Task<BoardGame> GetGame(int Id);

        Task<GamePlayed> GamePlayed(GamePlayed gamePlayed);

        Task<BoardGame> AddGame(BoardGame game);
    }
}