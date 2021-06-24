using System;
using System.Collections.Generic;
using System.Timers;

namespace ZsGUtils.Timers
{
    public static class TimerHandler
    {
        /// <summary>
        /// Restarts the given timer to the given time
        /// </summary>
        public static void RestartTimer(ref Timer timer, double milliSecondTime)
        {
            timer.Stop();
            if (milliSecondTime > 0)
            {
                timer.Interval = milliSecondTime;
                timer.Start();
            }
        }

        /// <summary>
        /// Restarts the given timer to the given time
        /// </summary>
        public static void RestartTimer(ref Timer timer, TimeSpan time)
        {
            RestartTimer(ref timer, time.TotalMilliseconds);
        }

        /// <summary>
        /// Stops the given timers
        /// </summary>
        public static void StopTimers(ref List<Timer> timers)
        {
            foreach (Timer timer in timers)
            {
                timer.Stop();
            }
        }

        /// <summary>
        /// Increments the given counter by the given amount
        /// </summary>
        /// <param name="counter"></param>
        /// <param name="amount"></param>
        public static void IncrementCounterTime(ref TimeSpan counter, double amount)
        {
            counter += TimeSpan.FromMilliseconds(amount);
        }

        /// <summary>
        /// Sets the given counter to Zero
        /// </summary>
        /// <param name="counter"></param>
        public static void ResetCounterTime(ref TimeSpan counter)
        {
            counter = TimeSpan.Zero;
        }
    }
}
