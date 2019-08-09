using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGeekGame
{
    public class Score
    {
        private string _playerName;
        private int _points;
        private TimeSpan _time;

        public string PlayerName { get; set; }

        public int Points { get; set; }

        public TimeSpan Time { get; set; }

        public Score(string playerName, int points, TimeSpan time)
        {
            this.PlayerName = playerName;
            this.Points = points;
            this.Time = time;
        }
    }
}
