using MonitoringTask;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class App
{
    /// <summary>
    /// Создаю объект, инкапсулирующий методы системного мониторинга
    /// </summary>
    static readonly SystemInfo _systemInfo = new ();

    // Переменные, куда буду сохранять полученные показания
    private static string _cpuLoad = String.Empty;
    private static string _memoryLoad = String.Empty;
    public static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;

        // Создаю и стартую поток для мониторинга процессора
        new Thread(() =>
        {
            while (true)
            {
                _cpuLoad = _systemInfo.GetCpu(); // Сохраняю показания
                Thread.Sleep(1000); // Задаю периодичность в 1 сек
            }
        }).Start(); // Стартую поток

        // Создаю и стратую поток для мониторинга памяти
        new Thread(() =>
        {
            while (true)
            {
                _memoryLoad = _systemInfo.GetRam(); // Сохраняю показания
                Thread.Sleep(500); // Задаю периодичность в 0,5 сек
            }
        }).Start(); // Стартую поток

        // Вывожу показания в цикле основного потока
        while (true)
        {
            Console.Clear(); // Очищаю консоль
            Console.WriteLine($"Загрузка процессора: {_cpuLoad}{Environment.NewLine}Доступно памяти: {_memoryLoad}"); // Вывожу показания
            Thread.Sleep(800); // Задаю периодичность обновления 0,8 сек
        }
    }
}