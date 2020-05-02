using System;

namespace PomodoroKata.Domain
{
    public class Pomodoro
    {
        public const int DEFAULT_MINUTES = 25;
        public Duration Duration { get; }
        public Duration CountDown { get; set; }
        public PomodoroState State { get; private set; }
        public Pomodoro(Duration durationInMinutes=null)
        {
            Duration = ProcessDuration(durationInMinutes);
            State = PomodoroState.Stopped;
        }

        private Duration ProcessDuration(Duration durationInMinutes)
        {
            CountDown = new Duration(0);
            if (durationInMinutes==null)
            {
                return (Duration)DEFAULT_MINUTES;
            }
            return durationInMinutes;
        }
        public void Start() 
        {
            State = PomodoroState.Started;
            CountDown = new Duration(Duration);
        }
        public void UpdateCountDown(Duration delatDuration)
        {
            if(State!=PomodoroState.Started)
            {
                throw new InvalidOperationException("Pomodor can not be updated if not started previously");
            }
            
            CountDown = Duration.FromMillis(CountDown.TotalMilliseconds - delatDuration.TotalMilliseconds);
            if(CountDown.TotalMilliseconds<=0)
            {
                State = PomodoroState.Ended;
            }
        }
    }
}
