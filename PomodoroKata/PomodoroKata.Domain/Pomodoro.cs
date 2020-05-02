using System;

namespace PomodoroKata.Domain
{
    public class Pomodoro
    {
        public const int DEFAULT_MINUTES = 25;
        public Duration Duration { get; }
        public PomodoroState State { get; private set; }
        public Pomodoro(Duration durationInMinutes=null)
        {
            Duration = ProcessDuration(durationInMinutes);
        }

        private Duration ProcessDuration(Duration durationInMinutes)
        {
            if(durationInMinutes==null)
            {
                return (Duration)DEFAULT_MINUTES;
            }
            return durationInMinutes;
        }
    }
}
