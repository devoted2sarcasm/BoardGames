using boardgames.Models;
using boardgames.Services;
using Microsoft.AspNetCore.Components;

namespace boardgames.Components;

public partial class GameCard : ComponentBase
{
    [Inject]
    public GameService _gameService { get; set; }

    [Parameter]
    public BoardGame Game { get; set; }

    private void DeleteGame() 
    {
        this._gameService.DeleteGame(this.Game);
    }
}
