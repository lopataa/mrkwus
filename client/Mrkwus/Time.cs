using System;

namespace MrkView
{
    static class Time
    {
        private static DateTime _initialTime;
        private static DateTime _lastTime;
        public static float DeltaTime { get; private set; }
        public static float ElapsedTime { get; private set; }

        public static void Start(DateTime initialTime)
        {
            _initialTime = initialTime;
        }

        public static void Update(DateTime time)
        {
            DeltaTime = (float)(time - _lastTime).TotalSeconds;
            ElapsedTime = (float)(time - _initialTime).TotalSeconds;
            _lastTime = time;
        }
    }
}
