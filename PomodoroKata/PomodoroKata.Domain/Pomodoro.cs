using PomodoroKata.Domain.CountDowns;
using System;

namespace PomodoroKata.Domain
{
    public class Pomodoro
    {
        public const int DEFAULT_MINUTES = 25;
        public Duration Duration { get; }
        public CountDown CountDown { get; set; }
        public PomodoroState State { get; private set; }
        public CountDownState CountDownState { get => CountDown.State; }
        public int Interruptions { get; private set; }

        public Pomodoro(Duration durationInMinutes=null)
        {
            Duration = ProcessDuration(durationInMinutes);
            State = PomodoroState.Standing;
        }

        private Duration ProcessDuration(Duration durationInMinutes)
        {
            CountDown = new CountDown(0);
            if (durationInMinutes==null)
            {
                return (Duration)DEFAULT_MINUTES;
            }
            return durationInMinutes;
        }
        public void Start() 
        {
            CountDown = new CountDown(Duration);
            CountDown.Start();
            UpdateStateFromCountDownState(CountDown.State);
            Interruptions = 0;
        }
        public void UpdateCountDown(Duration deltaDuration)
        {
            if(State!=PomodoroState.Started)
            {
                throw new InvalidOperationException("Pomodor can not be updated if not started previously");
            }

            CountDown = CountDown.Update(CountDown, deltaDuration);
            UpdateStateFromCountDownState(CountDown.State);
            
        }

        private void UpdateStateFromCountDownState(CountDownState countDownState)
        {
            
            if (countDownState == CountDownState.Ended)
            {
                State = PomodoroState.Ended;
            }
            else if(countDownState == CountDownState.Running ||
                    countDownState == CountDownState.OnHold)
            {
                State = PomodoroState.Started;
            }
        }

        public void Hold()
        {
            CountDown.Hold();
            Interruptions += 1;
        }

        public void Resume()=>
            CountDown.Resume();

        public void Restart()
        {
            Start();
            
        }
    }
}
