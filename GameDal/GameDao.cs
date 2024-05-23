using System.Data.Common;
using System.Data;
using GameDal.DbModels;
using GameDal.Criterias;

namespace GameDal
{
    public class GameDao : IGameDao
    {
        private readonly Func<DbConnection> _connectionFactory;
        private readonly string _parameterPrefix;
        private readonly string _stringConcatOperator;

        //private readonly IGamesIDbConnectionFactory _gamesIDbConnectionFactory;


        public GameDao
        (
            Func<DbConnection> connectionFactory,
            string parameterPrefix,
            string stringConcatOperator
        )
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            _parameterPrefix = parameterPrefix;
            _stringConcatOperator = stringConcatOperator;
        }

        public Task<GameDbItem[]> GetAllGameDbItemsAsync() =>
            GetGameDbItemsAsyncImpl
            (
                "select game_id, game_title, json_data, main_game_id from games",
                null
            );

        private string Likelize(string paramName) =>
            $" like '%' {_stringConcatOperator} {_parameterPrefix}{paramName} {_stringConcatOperator} '%'";


        private static void AddParameterIfNecessary
        (
            DbCommand command,
            string paramName,
            object? value,
            DbType dbType = DbType.String
        )
        {
            if (value is not null)
            {
                var parameter = command.CreateParameter();
                parameter.ParameterName = paramName;
                parameter.Value = value;
                parameter.DbType = dbType;
                parameter.Direction = ParameterDirection.Input;
                command.Parameters.Add(parameter);
            }
        }

        private string AddConditionIfNecessary(object? value, string fieldName, string paramName) =>
            value is null ? string.Empty : $" and {fieldName} {Likelize(paramName)}";

        public async Task<GameDbItem[]> GetGameDbItemsByPartialTitleAsync
        (
            string? id,
            string? title,
            string? json,
            string? mainId
        )
        {
            string sql =
                @$"select game_id, game_title, json_data, main_game_id 
               from games where 1 = 1 ";

            sql += AddConditionIfNecessary(id, "game_id", "p1");
            sql += AddConditionIfNecessary(title, "game_title", "p2");
            sql += AddConditionIfNecessary(json, "json_data", "p3");
            sql += AddConditionIfNecessary(mainId, "main_game_id", "p4");

            Action<DbCommand>? parametersAction =
                command =>
                {
                    AddParameterIfNecessary(command, "p1", id);
                    AddParameterIfNecessary(command, "p2", title);
                    AddParameterIfNecessary(command, "p3", json);
                    AddParameterIfNecessary(command, "p4", mainId);
                };

            return await GetGameDbItemsAsyncImpl(sql, parametersAction);
        }

        public async Task<StoreDbItem[]> GetStoreDbItemsByCriteriaAsync (StoreCriteria? criteria = null)
        {
            string sql =
                @$"select store_id, store_name, store_url    
               from stores where 1 = 1 ";

            sql += AddConditionIfNecessary(criteria?.StoreId, "store_id", "p1");
            sql += AddConditionIfNecessary(criteria?.StoreName, "store_name", "p2");
            sql += AddConditionIfNecessary(criteria?.StoreUrl, "store_url", "p3");

            Action<DbCommand>? parametersAction =
                command =>
                {
                    AddParameterIfNecessary(command, "p1", criteria?.StoreId);
                    AddParameterIfNecessary(command, "p2", criteria?.StoreName);
                    AddParameterIfNecessary(command, "p3", criteria?.StoreUrl);
                };

            return await GetStoreDbItemsAsyncImpl(sql, parametersAction);
        }

        public async Task<PlatformDbItem[]> GetPlatformDbItemsByPartialTitleAsync
        (
            string? id,
            string? name
            
        )
        {
            string sql =
                @$"select platform_id, platform_name 
               from platforms where 1 = 1 ";

            //sql += AddConditionIfNecessary(id, "platform_id", "p5");
            sql += AddConditionIfNecessary(name, "platform_name", "p6");
  

            Action<DbCommand>? parametersAction =
                command =>
                {
                    //AddParameterIfNecessary(command, "p5", id);
                    AddParameterIfNecessary(command, "p6", name);
                };

            return await GetPlatformDbItemsAsyncImpl(sql, parametersAction);
        }

        public async Task<LauncherDbItem[]> GetLauncherDbItemsByPartialTitleAsync
     (
         string? id,
         string? name

     )
        {
            string sql =
                @$"select launcher_id, launcher_name 
               from launchers where 1 = 1 ";

            //sql += AddConditionIfNecessary(id, "launcher_id", "p7");
            sql += AddConditionIfNecessary(name, "launcher_name", "p8");


            Action<DbCommand>? parametersAction =
                command =>
                {
                    //AddParameterIfNecessary(command, "p7", id);
                    AddParameterIfNecessary(command, "p8", name);
                };

            return await GetLauncherDbItemsAsyncImpl(sql, parametersAction);
        }




        #region roba da evitare

        //// PROBLEMA: n + 1 select
        //public async Task<List<Game>> GetAllGamesAsync_TO_AVOID()
        //{
        //    using SQLiteConnection connection = new SQLiteConnection(_connectionString);
        //    await connection.OpenAsync();
        //    using SQLiteCommand mainCommand = new SQLiteCommand(connection);

        //    mainCommand.CommandText = "select game_id, game_title, json_data from games where main_game_id is null";
        //    mainCommand.CommandType = System.Data.CommandType.Text;

        //    using var mainDataReader = await mainCommand.ExecuteReaderAsync();

        //    List<Game> mainGames = new List<Game>();

        //    while (mainDataReader.Read())
        //    {
        //        string gameId = mainDataReader.GetString(0);
        //        var gameTitle = (mainDataReader[mainDataReader.GetOrdinal("game_title")] as string)!;
        //        var jsonData = mainDataReader[2] as string;
        //        Game game = new Game(gameId, gameTitle, jsonData);
        //        mainGames.Add(game);
        //    }


        //    foreach (var mainGame in mainGames)
        //    {
        //        using SQLiteCommand command = new SQLiteCommand(connection);

        //        command.CommandText =
        //            @$"select game_id, game_title, json_data from games 
        //               where main_game_id = '{mainGame.GameId}'";

        //        command.CommandType = System.Data.CommandType.Text;

        //        using var dataReader = await command.ExecuteReaderAsync();

        //        while (dataReader.Read())
        //        {
        //            string gameId = dataReader.GetString(0);
        //            var gameTitle = (dataReader[dataReader.GetOrdinal("game_title")] as string)!;
        //            var jsonData = dataReader[2] as string;
        //            mainGame.AddNewDlc(gameId, gameTitle, jsonData);
        //        }
        //    }

        //    return mainGames;
        //}

        //public async Task<List<Game>> GetAllGamesAsync_Better_but_TO_AVOID()
        //{
        //    using SQLiteConnection connection = new SQLiteConnection(_connectionString);
        //    await connection.OpenAsync();

        //    using SQLiteCommand mainCommand = new SQLiteCommand(connection);

        //    mainCommand.CommandText = "select game_id, game_title, json_data from games where main_game_id is null";
        //    mainCommand.CommandType = System.Data.CommandType.Text;

        //    using var mainDataReader = await mainCommand.ExecuteReaderAsync();

        //    List<Game> mainGames = new List<Game>();

        //    while (mainDataReader.Read())
        //    {
        //        string gameId = mainDataReader.GetString(0);
        //        var gameTitle = (mainDataReader[mainDataReader.GetOrdinal("game_title")] as string)!;
        //        var jsonData = mainDataReader[2] as string;
        //        Game game = new Game(gameId, gameTitle, jsonData);
        //        mainGames.Add(game);
        //    }




        //    using SQLiteCommand dlcCmd = new SQLiteCommand(connection);

        //    dlcCmd.CommandText = "select game_id, game_title, json_data, main_game_id from games where main_game_id is not null";
        //    dlcCmd.CommandType = System.Data.CommandType.Text;

        //    using var dlcDataReader = await dlcCmd.ExecuteReaderAsync();

        //    Dictionary<string, List<Game>> dlcGames = new Dictionary<string, List<Game>>();

        //    while (dlcDataReader.Read())
        //    {
        //        string gameId = dlcDataReader.GetString(0);
        //        var gameTitle = (dlcDataReader[dlcDataReader.GetOrdinal("game_title")] as string)!;
        //        var jsonData = dlcDataReader[2] as string;
        //        var mainGameId = dlcDataReader.GetString(3);
        //        Game game = new Game(gameId, gameTitle, jsonData);
        //        if (dlcGames.TryGetValue(mainGameId, out var list))
        //        {
        //            list.Add(game);
        //        }
        //        else
        //        {
        //            list = new List<Game>() { game };
        //            dlcGames.Add(mainGameId, list);
        //        }
        //    }


        //    foreach (var mainGame in mainGames)
        //    {
        //        if (dlcGames.TryGetValue(mainGame.GameId, out var dlcList))
        //        {
        //            foreach (var dlcGame in dlcList)
        //                mainGame.AddNewDlc(dlcGame.GameId, dlcGame.Title, dlcGame.JsonData);
        //        }
        //    }

        //    return mainGames;
        //}

        #endregion

        private async Task<GameDbItem[]> GetGameDbItemsAsyncImpl(string sql, Action<DbCommand>? parametersAction)
        {
            Func<DbDataReader, GameDbItem> mapping =
                dataReader =>
                {
                    string gameId = dataReader.GetString(0);
                    var gameTitle = (dataReader[dataReader.GetOrdinal("game_title")] as string)!;
                    var jsonData = dataReader[2] as string;
                    var mainGameId = dataReader[3] as string;

                    return
                        new GameDbItem
                        {
                            GameId = gameId,
                            Title = gameTitle,
                            JsonData = jsonData,
                            MainGameId = mainGameId
                        };
                };

            return await GetGenericDbItemsAsyncImpl(sql, parametersAction, mapping);
        }

        private async Task<StoreDbItem[]> GetStoreDbItemsAsyncImpl(string sql, Action<DbCommand>? parametersAction)
        {
            Func<DbDataReader, StoreDbItem> mapping =
                dataReader =>
                {
                    string storeId = dataReader.GetString(0);
                    var storeName = (dataReader[dataReader.GetOrdinal("store_name")] as string)!;
                    var storeUrl = dataReader[2] as string;

                    return
                        new StoreDbItem
                        {
                            StoreId = storeId,
                            StoreName = storeName,
                            StoreUrl = storeUrl
                        };
                };

            return await GetGenericDbItemsAsyncImpl(sql, parametersAction, mapping);
        }



        private async Task<PlatformDbItem[]> GetPlatformDbItemsAsyncImpl(string sql, Action<DbCommand>? parametersAction)
        {
            Func<DbDataReader, PlatformDbItem> mapping =
                dataReader =>
                {
                    string platformId = dataReader.GetString(0);
                    var platformName = (dataReader[dataReader.GetOrdinal("platform_name")] as string)!;

                    return new PlatformDbItem
                    {
                        PlatformId = platformId,
                        PlatformName = platformName
                    };
                };

            return await GetGenericDbItemsAsyncImpl(sql, parametersAction, mapping);
        }

        private async Task<LauncherDbItem[]> GetLauncherDbItemsAsyncImpl(string sql, Action<DbCommand>? parametersAction)
        {
            Func<DbDataReader, LauncherDbItem> mapping =
                dataReader =>
                {
                    string launcherId = dataReader.GetString(0);
                    var launcherName = (dataReader[dataReader.GetOrdinal("launcher_name")] as string)!;

                    return new LauncherDbItem
                    {
                        LauncherId = launcherId,
                        LauncherName = launcherName
                    };
                };

            return await GetGenericDbItemsAsyncImpl(sql, parametersAction, mapping);
        }


        //public async Task<GameTransactionDbItem[]> GetTransactionsByCriteriaAsync(GameTransactionCriteria? criteria = null)
        //{
        //    string sql =
        //        @$"SELECT gt.game_tx_id, g.game_title, s.store_name, gt.acquire_date, gt.purchase_price    
        //   FROM game_transactions gt
        //   JOIN games g ON gt.game_id = g.game_id
        //   JOIN stores s ON gt.store_id = s.store_id
        //   WHERE 1 = 1";

        //    sql += AddConditionIfNecessary(criteria?.GameTxId, "gt.game_tx_id", "p1");
        //    sql += AddConditionIfNecessary(criteria?.GameId, "gt.game_id", "p2");
        //    sql += AddConditionIfNecessary(criteria?.StoreId, "gt.store_id", "p3");
        //    sql += AddConditionIfNecessary(criteria?.PlatformId, "gt.platform_id", "p4");
        //    sql += AddConditionIfNecessary(criteria?.LauncherId, "gt.launcher_id", "p5");
        //    sql += AddConditionIfNecessary(criteria?.MediaFormatId, "gt.media_format_id", "p6");
        //    sql += AddConditionIfNecessary(criteria?.AcquireDate, "gt.acquire_date", "p7");
        //    sql += AddConditionIfNecessary(criteria?.PurchasePrice, "gt.purchase_price", "p8");

        //    Action<DbCommand>? parametersAction =
        //        command =>
        //        {
        //            AddParameterIfNecessary(command, "p1", criteria?.GameTxId);
        //            AddParameterIfNecessary(command, "p2", criteria?.GameId);
        //            AddParameterIfNecessary(command, "p3", criteria?.StoreId);
        //            AddParameterIfNecessary(command, "p4", criteria?.PlatformId);
        //            AddParameterIfNecessary(command, "p5", criteria?.LauncherId);
        //            AddParameterIfNecessary(command, "p6", criteria?.MediaFormatId);
        //            AddParameterIfNecessary(command, "p7", criteria?.AcquireDate);
        //            AddParameterIfNecessary(command, "p8", criteria?.PurchasePrice);
        //        };

        //    return await GetGameTransactionDbItemsAsyncImpl(sql, parametersAction);
        //}





        private async Task<T[]> GetGenericDbItemsAsyncImpl<T>
        (
            string sql,
            Action<DbCommand>? parametersAction,
            Func<DbDataReader, T> mapping
        )
        {
            using DbConnection connection = _connectionFactory();
            await connection.OpenAsync();

            using DbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            parametersAction?.Invoke(command);

            using DbDataReader dataReader = await command.ExecuteReaderAsync();

            List<T> dbItems = new List<T>();

            while (dataReader.Read())
            {
                T dbItem = mapping(dataReader);
                dbItems.Add(dbItem);
            }

            return dbItems.ToArray();
        }
    }



}
