using boardgames.Models;
using Microsoft.AspNetCore.Components;
using System;
using boardgames.Services;

namespace boardgames.Pages;

public partial class GameAddApi : ComponentBase
{
    [Inject]
    public NavigationManager pageNavigationManager { get; set; }

    [Inject]
    private IGameApiService pageGameService { get; set; }

    private BoardGame newGame { get; set; } = new BoardGame();

    private async Task AddGame()
    {
        await this.pageGameService.AddGame(this.newGame);
        this.pageNavigationManager.NavigateTo($"/games/?addedGame={this.newGame.Name}");
    }
}