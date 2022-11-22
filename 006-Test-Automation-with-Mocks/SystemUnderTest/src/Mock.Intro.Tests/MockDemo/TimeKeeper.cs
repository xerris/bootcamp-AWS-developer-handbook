using System;

namespace Mock.Intro.Tests.MockDemo
{
    public class TimeKeeper
    {
        private readonly IAlarmClock clock;

        public TimeKeeper(IAlarmClock clock)
        {
            this.clock = clock;
        }

        public DateTime WhatTimeIsIt() => clock.Now;

        public void WakeMeUpAtSixAm() => clock.SetAlarm(new TimeSpan(6, 0, 0));
    }
}