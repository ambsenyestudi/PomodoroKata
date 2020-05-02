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
        [Fact]
        public void BeStoppedWhenCreated()
        {
            var sut = new Pomodoro();
            var expectedState = PomodoroState.Stopped;
            Assert.Equal(expectedState, sut.State);
        }
        [Fact]
        public void BeStartCountDownWhenStarted()
        {
            var sut = new Pomodoro();
            sut.Start();
            Assert.True(sut.CountDown>0);
        }
        [Fact]
        public void Have0CountDownWhenCreated()
        {
            var exptectedMinutes = 0;
            var sut = new Pomodoro();
            
            Assert.Equal(exptectedMinutes, sut.CountDown);
        }
    }
}
