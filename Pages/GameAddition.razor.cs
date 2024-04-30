using boardgames.Models;
using Microsoft.AspNetCore.Components;
using System;
using boardgames.Services;

namespace boardgames.Pages;

public partial class GameAddition: ComponentBase
{
    [Inject]
    public NavigationManager pageNavigationManager { get; set; }

    [Inject]
    private GameService pageGameService { get; set; }

    private BoardGame newGame { get; set; } = new BoardGame();

    private void AddGame()
    {
        this.pageGameService.AddGame(this.newGame);
        this.pageNavigationManager.NavigateTo($"/games/?addedGame={this.newGame.Name}");
    }
}