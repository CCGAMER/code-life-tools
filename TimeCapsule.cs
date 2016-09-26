namespace code_life_tools
{
    /// <summary>
    /// TimeCapsule class can be used to measure the time taken for the developer to execute a certain task. Note that this is not pre-decisions.
    /// </summary>
    public static class TimeCapsule
    {
        private static bool _started = false;
        private static int _startedTime;

        /// <summary>
        /// Starts the time counting
        /// </summary>
        public static void Start()
        {
            _started = true;
            _startedTime = System.Environment.TickCount;
        }

        /// <summary>
        /// Ends the time counting
        /// </summary>
        /// <returns>Returns the time took to execute the task as milliseconds in integer format</returns>
        public static int End()
        {
            if (_started == true)
            {
                int time_difference = System.Environment.TickCount - _startedTime;
                _started = false;

                return time_difference;
            }
            else
            {
                return -1;
            }
        }
    }
}
