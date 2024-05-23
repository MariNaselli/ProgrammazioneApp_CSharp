using GamesETL.Files.Generic;

namespace GamesETL.Tests;

public class GenericGamesTxDataProviderTests
{
    [Fact]
    public void FilePath_IsValid()
    {

        string filePath = @"C:\Users\Daskalos\source\repos\ProgrammazioneApp_CSharp\GenericGames.txt";
        Assert.True(File.Exists(filePath));
    }
}
    
