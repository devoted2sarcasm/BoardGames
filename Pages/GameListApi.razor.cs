using System.Web;
using boardgames.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using boardgames.Services;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using boardgames.Models.Responses;

namespace boardgames.Pages;

public partial class GameListApi : ComponentBase
{
    [Inject]
    public NavigationManager _navigationManager { get; set; }

    [Inject]
    private IGameApiService BGameService { get; set; }

    private List<BoardGameResponse> Games { get; set; } = new List<BoardGameResponse>();

    private bool DisplayFeedbackMessage { get; set; }

    private string? FeedbackMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        this.Games = await this.BGameService.GetGames();

        this.DetermineFeedbackMessages();
    }

    private void DetermineFeedbackMessages()
    {
        var uri = new Uri(_navigationManager.Uri);

        var queryParams = HttpUtility.ParseQueryString(uri.Query);

        var deletedGameName = queryParams["deletedGame"];

        if (!string.IsNullOrEmpty(deletedGameName))
        {
            this.DisplayFeedbackMessage = true;
            this.FeedbackMessage = $"Game {deletedGameName} was deleted successfully.";
        }
    }
}