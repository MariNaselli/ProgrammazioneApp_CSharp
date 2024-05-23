

using GameDal;
using System.Data.Common;
using System.Data.SQLite;
using GameLibrary;
using DBConsoleApp;

//string connStr = @"Data Source=C:\Users\Daskalos\source\repos\academy_appmobile_2024\databases\SQLite\academy_mobile_2024.db;Version=3;FailIfMissing=false;Foreign Keys=True";
string connStr = @"Data Source=C:\Users\Daskalos\source\repos\VideoGames.db;Version=3;FailIfMissing=false;Foreign Keys=True";

//IGamesDao dao = new GamesDao(new SqliteGameConnectionFctory(connStr));
IGameDao dao = new SQLiteGameDao(connStr);

IGameService gamesService = new GameService(dao);

var games = await gamesService.GetAllGamesAsync();

Console.WriteLine($"gameId | gameTitle");
games
    .ForEach
    (
        g =>
        {
            Console.WriteLine($"{g.GameId} | {g.Title}");
            foreach (var dlc in g.DlcGames)
            {
                Console.WriteLine($"   {g.GameId} | {g.Title}");
            }
        }
    );

var zeldaGames = await dao.GetGameDbItemsByPartialTitleAsync(id: "fallout", mainId: "fallout");


var allStores = await dao.GetStoreDbItemsByCriteriaAsync();

Console.ReadLine();

//var games2 =  await dao.GetAllGamesAsync_TO_AVOID();

//var games3 = await dao.GetAllGamesAsync_Better_but_TO_AVOID();

class SqliteGameConnectionFctory : IGameIDbConnectionFactory
{
    private readonly string _connectionString;

    public SqliteGameConnectionFctory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbConnection CreateConnection() =>
        new SQLiteConnection(_connectionString);
}
