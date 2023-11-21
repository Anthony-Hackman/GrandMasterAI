using System;
using System.Threading;
using System.Threading.Tasks;
using GrandMasterAI; // Ensure this using directive is correct 

public class GrandMasterAIService(ChessDotComClient chessClient, StockfishEngine stockfishEngine)
{
    private readonly ChessDotComClient _chessClient = chessClient;
    private readonly StockfishEngine _stockfishEngine = stockfishEngine;
    private readonly Timer _timer;

    public async Task StartAsync()
    {
        // Your service start logic here.
    }

    // Other methods and logic...


    public GrandMasterAIService()
    {
        _chessClient = new ChessDotComClient();
        // Schedule the timer to run every hour, for example
        _timer = new Timer(ExecuteTask, null, TimeSpan.Zero, TimeSpan.FromHours(1));
    }

    private void ExecuteTask(object? state) // Allow for a nullable object if your project uses nullable reference types
    {
        // Logic to decide which game ID to process next
        string gameId = GetNextGameIdToProcess();

        // Asynchronously call the method to process the game
        Task.Run(async () => await RetrieveGameAndProcessAsync(gameId));
    }

    private async Task RetrieveGameAndProcessAsync(string gameId)
    {
        // Retrieve the PGN for the game using ChessDotComClient
        var pgn = await _chessClient.GetGamePgnAsync(gameId);
        if (!string.IsNullOrEmpty(pgn))
        {
            // Process the PGN data
            Console.WriteLine($"PGN for game {gameId}: {pgn}");
        }
        else
        {
            Console.WriteLine($"Game {gameId} not found.");
        }
        // Add further processing logic here
    }

    private string GetNextGameIdToProcess()
    {
        // Implement logic to get the next game ID
        //
        // This could be from a database, file, or any other source where you keep track of what to process next
        //
        //
        return "next_game_id";
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    static void Main(string[] args)
    {
        // Start the service
        using var service = new GrandMasterAIService();

        Console.WriteLine("Service started. Press Enter to exit...");
        Console.ReadLine();
    }
}
