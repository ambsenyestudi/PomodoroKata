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
        [Fact]
        public void NotEndWhenNotStarted()
        {
            var duration = new Duration(1);
            var sut = new Pomodoro(duration);
            Assert.Throws<InvalidOperationException>(() => sut.UpdateCountDown(duration));
        }
        [Fact]
        public void EndWhenRunsOut()
        {
            var expectedState = PomodoroState.Ended;
            var duration = new Duration(1);
            var sut = new Pomodoro(duration);
            sut.Start();
            sut.UpdateCountDown(duration);
            Assert.Equal(expectedState, sut.State);
        }
        [Fact]
        public void NotEndWhenTimeLeft()
        {
            var expectedState = PomodoroState.Running;
            var duration = new Duration(2);
            var sut = new Pomodoro(duration);
            sut.Start();
            sut.UpdateCountDown(new Duration(1));
            Assert.Equal(expectedState, sut.State);
        }
    }
}
