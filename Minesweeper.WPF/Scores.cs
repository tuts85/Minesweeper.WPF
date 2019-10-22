using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.WPF
{
    public class Scores
    {
        public String playerName;
        public int score;

        public Scores (string playerName, int score)
        {
            this.playerName = playerName;
            this.score = score;
        }
    }
}
