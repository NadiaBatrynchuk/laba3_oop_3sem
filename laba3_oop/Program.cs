using Lab2.Accounts;
using Lab2.Games;
using Lab3.DB;
using Lab3.DB.Service.Accounts;
using Lab3.DB.Service.Stats;
using Lab3.Printer;

class Program
{
    static void Main(string[] args)
    {
        DbContext context = new();

        GameStatsService gameStatsService = new(context);
        AccountService accountService = new(context);

        accountService.CreateAccount(new GameAccount("Marta", 400, 5)); // Створення нового гравця
        var players = accountService.ReadAccounts();

        Console.WriteLine("*** All Players List ***");
        Printer.ShowAllPlayers(players); // Виведення списку усіх створенних гравців

        GameFactory factory = new();
        var std_game_for_playing = factory.CreateGame(GameType.Standard);
        std_game_for_playing.PlayGame(players[0], players[1], gameStatsService, 100);
        std_game_for_playing.PlayGame(players[0], players[1], gameStatsService, 100);
        std_game_for_playing.PlayGame(players[2], players[0], gameStatsService, 100);

        var all_games = gameStatsService.ReadGames();

        Console.WriteLine("\n*** All Games List ***");
        Printer.ShowAllGames(all_games);

        var all_player_games = gameStatsService.ReadGamesByPlayerName(players[2].UserName);

        Console.WriteLine($"\n*** All {players[2].UserName} Games ***");
        // Printer.ShowOnePlayerGames(players[2].UserName, all_games); // Виведення списку усіх ігор, в яких брав участь конкретний гравець

        Printer.ShowAllGames(all_player_games);

    }
}
    