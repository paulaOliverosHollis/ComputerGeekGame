﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGeekGame
{
    public class Score
    {
        private string _name;
        private int _points;
        private TimeSpan _time;

        public string Name { get; set; }

        public int Points { get; set; }

        public TimeSpan Time { get; set; }

        public Score(string name, int points, TimeSpan time)
        {
            this.Name = name;
            this.Points = points;
            this.Time = time;
        }
    }
}
