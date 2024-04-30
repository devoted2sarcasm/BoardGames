using System.Web;
using boardgames.Models;
using Microsoft.AspNetCore.Components;
using boardgames.Services;
using System.Runtime.CompilerServices;

namespace boardgames.Pages;

public partial class GameDetails: ComponentBase
{
    [Inject]
    public NavigationManager detailsNavigationManager { get; set; }

    [Parameter]
    public int Id { get; set; }

    [Inject]
    public GameService detailsGameService { get; set; } 

    private BoardGame? game { get; set; }

    private bool IsLoading { get; set; }

    private bool ErrorOccurred = false;

    private string? ErrorMessage = "";

    private bool DisplayFeedbackMessage { get; set; }

    private string FeedbackMessage { get; set; }

    protected override void OnInitialized()
    {
        RetrieveGame();
        this.DetermineFeedbackMessages();
    }

    private void RetrieveGame()
    {
        this.IsLoading = true;
        this.ErrorMessage = "";
        this.ErrorOccurred = false;

        this.detailsGameService.GetGameById(Id).Subscribe(
            detailGame => 
            {
                if (detailGame != null)
                {
                    this.game = detailGame;
                }
                else
                {
                    this.ErrorOccurred = true;
                    this.ErrorMessage = $"Game with ID {Id} not found.";
                }
                this.IsLoading = false;
            }
        );
    }

    private void DeleteGame()
    {
        this.detailsGameService.DeleteGame(this.game!);
        this.detailsNavigationManager.NavigateTo($"?deletedGame={this.game.Name}");
    }

    private void DetermineFeedbackMessages()
    {
        var uri = new Uri(detailsNavigationManager.Uri);

        var queryParams = HttpUtility.ParseQueryString(uri.Query);

        var addedGameName = queryParams["addedGame"];

        if (!string.IsNullOrEmpty(addedGameName))
        {
            this.DisplayFeedbackMessage = true;
            this.FeedbackMessage = $"Game {addedGameName} was added successfully.";
        }
    }


}