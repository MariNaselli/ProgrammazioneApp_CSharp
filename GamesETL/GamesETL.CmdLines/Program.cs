// See https://aka.ms/new-console-template for more information

using GamesETL.Core;
using GamesETL.Files.Generic;
using GamesETL.Models;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

var logger =
    new NLogLoggerFactory()
    .CreateLogger<GenericGamesTxDataProvider>();

IGamesTxDataProvider gamesTxDataProvider =
    new GenericGamesTxDataProvider(@"./", logger);

//var gamesTxDataCollection = await
//    gamesTxDataProvider
//    //.GetGamesTxDataAsync()
//    .ConfigureAwait(false);

//foreach (var gameTx in gamesTxDataCollection)
//{
//    logger.LogDebug(gameTx.ToString());
//}


//Crea una interface de GameTxImportData
//public interface IGamesTxDataProvider
//{
//    ValueTask<GameTxImportData[]> GetGamesTxDataAsync();
//}
