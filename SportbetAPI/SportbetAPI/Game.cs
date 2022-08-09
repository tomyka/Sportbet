using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportbetAPI
{
    public class Game
    {
        public int gameId {get; set;}
        public string gameDate { get; set; }
        public string homeTeam { get; set; }
        public string awayTeam { get; set; }
        public int homeScore { get; set; }
        public int awayScore { get; set; }
    }
}
