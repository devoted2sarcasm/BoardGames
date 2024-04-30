using boardgames.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using boardgames.Services;
using Microsoft.AspNetCore.Components;

namespace boardgames.Pages;

public partial class GamePlayId : ComponentBase
{
    [Inject]
    public NavigationManager _navigationManager { get; set; }

    [Inject]
    private IGameApiService _gameApiService { get; set; }

    [Parameter]
    public int Id { get; set; }

    private BoardGame Game { get; set; }

    private GamePlayed GamePlayed { get; set; } = new GamePlayed();

    protected override async Task OnInitializedAsync()
    {
        this.Game = await this._gameApiService.GetGame(this.Id);
    }

    private async Task SendPlayedGame()
    {
        await this._gameApiService.GamePlayed(this.GamePlayed);
    }
}