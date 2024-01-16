using System.Diagnostics;

namespace MonitoringTask
{
    /// <summary>
    /// Позволяет получать информацию о свободной памяти RAM и загрузке процессора
    /// </summary>
    public class SystemInfo
    {
        private PerformanceCounter _cpuCounter = new("Processor", "% Processor Time", "_Total");
        private PerformanceCounter _ramCouner = new("Memory", "Available MBytes");

        /// <summary>
        /// Задаю показания процессора в процентах
        /// </summary>
        /// <returns></returns>
        public string GetCpu()
        {
            return _cpuCounter.NextValue() + " %";
        }

        /// <summary>
        /// Задаю показания помяти в мегабайтах
        /// </summary>
        /// <returns></returns>
        public string GetRam()
        {
            return _ramCouner.NextValue() + " MB";
        }
    }
}