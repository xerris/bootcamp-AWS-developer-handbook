using System;

namespace Mock.Intro.Tests.MockDemo
{
    public interface IAlarmClock
    {
        DateTime Now { get; }
        void SetAlarm(TimeSpan alarmTime);
    }
}