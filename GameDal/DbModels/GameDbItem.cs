using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDal.DbModels
{
    public class GameDbItem
    {
        public string GameId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? JsonData { get; set; }
        public string? MainGameId { get; set; }
    }
}
