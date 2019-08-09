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
        
        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
            }
        }

        public int Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }

        public TimeSpan Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }

        public Score(string playerName, int points, TimeSpan time)
        {
            this.PlayerName = playerName;
            this.Points = points;
            this.Time = time;
        }
   }
}
