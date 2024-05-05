using boardgames.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using boardgames.Services;
using Microsoft.AspNetCore.Components;
using boardgames.Models.Responses;

namespace boardgames.Pages;

public partial class GamePlayId : ComponentBase
{
    [Inject]
    public NavigationManager _navigationManager { get; set; }

    [Inject]
    private IGameApiService _gameApiService { get; set; }

    [Parameter]
    public int Id { get; set; }

    private BoardGameResponse Game { get; set; }

    private GamePlayed GamePlayed { get; set; } = new GamePlayed();

    // method to fetch the name of the game being played for display in the title
    private string GameName()
    {
        return this.Game.Name;
    }

    protected override async Task OnInitializedAsync()
    {
        this.Game = await this._gameApiService.GetGame(this.Id);
    }

    private async Task SendPlayedGame()
    {
        await this._gameApiService.GamePlayed(this.GamePlayed);
    }
}