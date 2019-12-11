﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SEP3_TIER3.Model
{
    public class Timer
    {
        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Hour { get; set; }
        public Timer(int Seconds, int Minutes, int Hour)
        {
            this.Seconds = Seconds;
            this.Minutes = Minutes;
            this.Hour = Hour;
        }
        public override string ToString()
        {
            return $"Hour: {Hour}\nMinutes:{Minutes}\nSecods:{Seconds}";
        }
    }
}