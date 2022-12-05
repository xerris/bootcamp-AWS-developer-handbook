using System;
using FluentAssertions;
using Moq;
using Xerris.DotNet.Core.Validations;
using Xunit;

namespace Mock.Intro.Tests.MockDemo
{
    public class TimeKeeperTests
    {
        private readonly MockRepository mocks;
        private readonly Mock<IAlarmClock> mockClock;
        private readonly TimeKeeper timeKeeper;

        public TimeKeeperTests()
        {
            mocks = new MockRepository(MockBehavior.Strict);

            mockClock = mocks.Create<IAlarmClock>();
            timeKeeper = new TimeKeeper(mockClock.Object);
        }

        ~TimeKeeperTests() => mocks.VerifyAll();

        [Fact]
        public void CurrentTime()
        {
            var now = new DateTime(2021, 01, 01, 15, 0, 0);
            mockClock.Setup(x => x.Now).Returns(now);
            var actual = timeKeeper.WhatTimeIsIt();

            actual.Should().Be(now);
            mockClock.VerifyGet(x => x.Now);
        }

        [Fact]
        public void SetAlarm()
        {
            var expected = new TimeSpan(6, 0, 0);
            mockClock.Setup(x => x.SetAlarm(It.Is<TimeSpan>(act => Matches(act, expected))));

            timeKeeper.WakeMeUpAtSixAm();
            
            //will verify ALL calls to this mock
            mockClock.VerifyAll();
        }

        private static bool Matches(TimeSpan actual, TimeSpan expected)
        {
            Validate.Begin()
                .IsEqual(actual.Hours, expected.Hours, "hour matches")
                .IsEqual(actual.Minutes, expected.Minutes, "minutes match")
                .IsEqual(actual.Seconds, expected.Seconds, "seconds match")
                .Check();
            return true;
        }
    }
}