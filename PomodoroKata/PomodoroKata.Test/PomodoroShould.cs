using PomodoroKata.Domain;
using System;
using Xunit;

namespace PomodoroKata.Test
{
    public class PomodoroShould
    {
        [Fact]
        public void Last25MinutesByDefault()
        {
            var exptectedMinutes = 25;
            var sut = new Pomodoro();
            
            Assert.Equal(exptectedMinutes, sut.Duration);
        }
        [Fact]
        public void BeOfAnyDuration()
        {
            var exptectedMinutes = 45;
            var duration = new Duration(exptectedMinutes);
            var sut = new Pomodoro(duration);
            Assert.Equal(exptectedMinutes, sut.Duration);
        }
    }
}
