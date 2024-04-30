using System.Text.Encodings.Web;
using System.Web;
using boardgames.Models;
using boardgames.Services;
using Microsoft.AspNetCore.Components;

namespace boardgames.Components;

public partial class GameListApi : ComponentBase
{
    [Inject]
    public NavigationManager _navigationManager { get; set; }

    [Inject]
    private IGameApiService _gameApiService { get; set; }

    private List<BoardGame> Games { get; set; } = [];

    private bool DisplayFeedbackMessage { get; set; }

    private string? FeedbackMessage { get; set; }

    protected override async void OnInitialized()
    {
        var newGames = await _gameApiService.GetGames();
        this.Games = newGames;

        DetermineFeedbackMessages();
        StateHasChanged();
    }

    private void DetermineFeedbackMessages()
    {
        var uri =  new Uri(_navigationManager.Uri);

        var queryParams = HttpUtility.ParseQueryString(uri.Query);

        var deletedGameName = queryParams["deletedGame"];

        if (!string.IsNullOrEmpty(deletedGameName))
        {
            this.DisplayFeedbackMessage = true;
            this.FeedbackMessage = $"Game {deletedGameName} was deleted successfully.";
        }
    }
}