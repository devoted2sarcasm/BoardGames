namespace boardgames.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using boardgames.Models;

public class GameService
{
    private readonly List<BoardGame> _games = new List<BoardGame>
    {
        new BoardGame { Id = 1, Name = "Catan", MinPlayers = 3, MaxPlayers = 4, Description = "Collect resources and build settlements", Difficulty = 2, Rank = 4, IdealPlayerCount = 4, Playtime = 60 },
        new BoardGame { Id = 2, Name = "Ticket to Ride", MinPlayers = 2, MaxPlayers = 5, Description = "Collect train cards and build routes", Difficulty = 1, Rank = 3, IdealPlayerCount = 4, Playtime = 45 },
        new BoardGame { Id = 3, Name = "Machi Koro 2", MinPlayers = 2, MaxPlayers = 5, Description = "Build your city and earn coins", Difficulty = 1, Rank = 2, IdealPlayerCount = 3, Playtime = 30},
        new BoardGame { Id = 4, Name = "Quacks of Quedlinburg", MinPlayers = 2, MaxPlayers = 4, Description = "Push your luck and brew potions", Difficulty = 2, Rank = 1, IdealPlayerCount = 4, Playtime = 45},
        new BoardGame { Id = 5, Name = "Splendor", MinPlayers = 2, MaxPlayers = 4, Description = "Collect gems and build your empire", Difficulty = 1, Rank = 5, IdealPlayerCount = 3, Playtime = 30},
        new BoardGame { Id = 6, Name = "Word Slam", MinPlayers = 3, MaxPlayers = 99, Description = "Guess the word and win the round", Difficulty = 1, Rank = 6, IdealPlayerCount = 6, Playtime = 45},
        new BoardGame { Id = 7, Name = "The Resistance", MinPlayers = 5, MaxPlayers = 10, Description = "Find the spies and save the world", Difficulty = 1, Rank = 7, IdealPlayerCount = 7, Playtime = 30},
        new BoardGame { Id = 8, Name = "Tsuro", MinPlayers = 2, MaxPlayers = 8, Description = "Place tiles and stay on the board to be the last one standing", Difficulty = 1, Rank = 8, IdealPlayerCount = 5, Playtime = 15},
        new BoardGame { Id = 9, Name = "Forbidden Island", MinPlayers = 2, MaxPlayers = 4, Description = "Work together to collect treasures and escape the island", Difficulty = 1, Rank = 9, IdealPlayerCount = 4, Playtime = 30},
        new BoardGame { Id = 10, Name = "Loot", MinPlayers = 2, MaxPlayers = 8, Description = "Pirate your way to the most loot", Difficulty = 1, Rank = 10, IdealPlayerCount = 6, Playtime = 30},
        new BoardGame { Id = 11, Name = "That's So Clever", MinPlayers = 1, MaxPlayers = 4, Description = "Roll dice and fill in your sheet to earn the highest score", Difficulty = 1, Rank = 11, IdealPlayerCount = 3, Playtime = 30}
        
    };

    private readonly BehaviorSubject<List<BoardGame>> _gamesSubject = new BehaviorSubject<List<BoardGame>>([]);

    public GameService()
    {
        this._gamesSubject.OnNext(this._games);
    }

    public IObservable<BoardGame> GetGameById(int id)
    {
        return this._gamesSubject.Select(games => games.FirstOrDefault(game => game.Id == id));
    }

    public IObservable<List<BoardGame>> GetGames()
    {
        return this._gamesSubject.AsObservable();
    }

    public void AddGame(BoardGame gameToAdd)
    {
        gameToAdd.Id = this._games.Count + 1;
        this._games.Add(gameToAdd);
        this._gamesSubject.OnNext(this._games);
    }

    public void DeleteGame(BoardGame gameToDelete)
    {
        this._games.Remove(gameToDelete);
        this._gamesSubject.OnNext(this._games);
    }
}