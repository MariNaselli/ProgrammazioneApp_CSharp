using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Support;

namespace GameLibrary.Models
{
    public class GameCollection
    {
        private readonly List<GameTransaction> _gamesTransactions;

        public string Name { get; }
        public string Owner { get; }

        public GameCollection(string name, string owner)
        {
            Name = name;
            Owner = owner;
            _gamesTransactions = new List<GameTransaction>();
        }

        public GameTransaction AddNewGameTransaction
        (
            Game game,
            Store store,
            Platform platform,
            Launcher launcher,
            MediaFormat mediaFormat = MediaFormat.Digital,
            DateOnly? acquireDate = null,
            decimal purchasePrice = 0m
        )
        {
            GameTransaction gameTransaction =
                new
                (
                    Guid.NewGuid().ToString(),
                    game,
                    store,
                    platform,
                    launcher,
                    mediaFormat,
                    acquireDate ?? DateTime.Today.ToDateOnly(),
                    purchasePrice
                );

            _gamesTransactions.Add(gameTransaction);
            return gameTransaction;
        }
    }
}
