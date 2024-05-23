namespace GamesETL.Models;

public record GameTxImportData
    (
    string Title,
    DateOnly AcquireDate,
    decimal Price,
    string Store,
    string Launcher,
    string Platform, 
    string Media, 
    string GameId,
    string? MasterGameId
);
    

