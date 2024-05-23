using GamesETL.Models;

namespace GamesETL.Core;

public interface IGamesTxDataProvider
{
    public ValueTask<GameTxImportData[]> GetGamesTxAsync();
   

}
