using boardgames.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using boardgames.Services;
using Microsoft.AspNetCore.Components;
using boardgames.Models.Responses;

namespace boardgames.Components;

public partial class GameCardApi : ComponentBase 
{
    [Inject]
    public NavigationManager _navigationManager { get; set; }

    [Inject]
    private IGameApiService _gameApiService { get; set; }

    [Parameter]
    public BoardGameResponse Game { get; set; }

    private bool DisplayFeedbackMessage { get; set; }

    private string? FeedbackMessage { get; set; }

    private async Task PlayGameById() 
    {
        //navigate to gameplayid page, utilizing the game id
        _navigationManager.NavigateTo($"/play-game/{Game.Id}");
    }
    
}