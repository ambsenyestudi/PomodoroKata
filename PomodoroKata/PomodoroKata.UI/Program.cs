using PomodoroKata.Domain;
using System;
using System.Threading.Tasks;

namespace PomodoroKata.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var pomodoro = new Pomodoro(new Duration(1));
            pomodoro.Start();
            Console.WriteLine("Pomodoro Started");
            Console.WriteLine(pomodoro.CountDown.ToString());
            while (pomodoro.State!=PomodoroState.Ended)
            {
                Update(pomodoro).Wait();
                Console.WriteLine(pomodoro.CountDown.ToString());
            }
            Console.WriteLine("Pomodoro ended");
            var v = Console.ReadLine();
        }
        static async Task Update(Pomodoro pomodoro)
        {
            var currTime = DateTime.Now;
            await Task.Delay(800);
            var currDelta = (int)(DateTime.Now - currTime).TotalMilliseconds;
            var newDuration = Duration.FromMillis(currDelta);
            pomodoro.UpdateCountDown(newDuration);
            var remainingMillis = pomodoro.CountDown.TotalMilliseconds;
        }
    }
}
