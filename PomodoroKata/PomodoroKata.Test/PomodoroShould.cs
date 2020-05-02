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
            var sut = new Pomodoro();
            var exptectedDuration = 25;
            Assert.Equal(exptectedDuration, sut.DurationInMinutes);
        }
        [Fact]
        public void BeOfAnyDuration()
        {
            var exptectedDuration = 45;
            var sut = new Pomodoro();
            Assert.Equal(exptectedDuration, sut.DurationInMinutes);
        }
    }
}
