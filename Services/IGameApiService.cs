using System.Collections.Generic;
using System.Threading.Tasks;
using boardgames.Models;
using boardgames.Models.Responses;


namespace boardgames.Services
{
    public interface IGameApiService
    {
        Task<List<BoardGameResponse>> GetGames();

        Task<BoardGameResponse> GetGame(int Id);

        Task<GamePlayed> GamePlayed(GamePlayed gamePlayed);

        Task<BoardGameResponse> AddGame(BoardGame game);
    }
}