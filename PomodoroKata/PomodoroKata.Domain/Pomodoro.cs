using System;

namespace PomodoroKata.Domain
{
    public class Pomodoro
    {
        public int DurationInMinutes { get; set; }
        public Pomodoro(int minutes=25)
        {
            DurationInMinutes = minutes;
        }
    }
}
