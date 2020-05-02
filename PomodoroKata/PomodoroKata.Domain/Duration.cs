namespace PomodoroKata.Domain
{
    public class Duration
    {
        public const int SECONDS_IN_A_MINUTE = 60;
        public const int MILLIS_IN_A_SECOND = 1000;
        public int TotalMilliseconds { get; protected set;}
        public int TotalMinutes { get => TotalMilliseconds / SECONDS_IN_A_MINUTE / MILLIS_IN_A_SECOND; }
        protected Duration()
        {

        }
        public Duration(int minutes)
        {
            TotalMilliseconds = Convert(minutes, SECONDS_IN_A_MINUTE, MILLIS_IN_A_SECOND);
        }
        private int Convert(int minutes, params int[] conversionFactors)
        {
            var result = minutes;
            foreach (var factor in conversionFactors)
            {
                result *= factor;
            }
            return result;
        }

        public static Duration FromMillis(int millis) =>
            new Duration() { TotalMilliseconds = millis };

        public static implicit operator int(Duration d)=>d.TotalMinutes;
        public static explicit operator Duration(int i)=> new Duration(i);
    }
}
