using System.Text.Encodings.Web;
using System.Web;
using boardgames.Models;
using boardgames.Services;
using Microsoft.AspNetCore.Components;

namespace boardgames.Components;

public partial class GameList: ComponentBase
{
    [Inject]
    public NavigationManager _navigationManager { get; set; }

    [Inject]
    private GameService BGameService { get; set; }

    private List<BoardGame> Games { get; set; } = [];

    private bool DisplayFeedbackMessage { get; set; }

    private string? FeedbackMessage { get; set; }

    protected override void OnInitialized()
    {
        this.BGameService.GetGames().Subscribe(newGames =>
        {
            this.Games = newGames;

            StateHasChanged();
        });

        this.DetermineFeedbackMessages();
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