using System;

namespace PomodoroKata.Domain.CountDowns
{
    public class CountDown : Duration
    {
        public CountDownState State { get; private set; }
        public CountDown(Duration duration)
        {
            TotalMilliseconds = duration.TotalMilliseconds;
        }
        public CountDown(int minutes) : base(minutes)
        {
            State = CountDownState.None;
        }
        public void Start()
        {
            State = CountDownState.Running;
        }
        public void Hold()
        {
            State = CountDownState.OnHold;
        }
        public void Resume()
        {
            State = CountDownState.Running;
        }
        public static CountDown Update(CountDown countDown, Duration deltaDuration)
        {
            if(countDown.State == CountDownState.Ended || countDown.State == CountDownState.OnHold)
            {
                return countDown;
            }
            var newDuration = Duration.FromMillis(countDown.TotalMilliseconds - deltaDuration.TotalMilliseconds);
            var state = newDuration.TotalMilliseconds <= 0 ? CountDownState.Ended : countDown.State;
            return new CountDown(newDuration) { State = state };
        }
        public override string ToString()
        {
            var totalSeconds = TotalMilliseconds / MILLIS_IN_A_SECOND;
            return $"{totalSeconds / Duration.SECONDS_IN_A_MINUTE}:{totalSeconds % SECONDS_IN_A_MINUTE}";
        }


    }
}
