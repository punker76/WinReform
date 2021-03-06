﻿using System;
using System.Timers;

namespace WinReform.Tests.Process.Fixture
{
    /// <summary>
    /// Defines a class that represents a fixture of a process without a window
    /// NOTE: The application automaticly closes after x seconds, this to make sure that if the test failed and the dispose isnt't triggered the app wont linger in the background forever
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// <see cref="Timer"/> that triggers an automatic close of the application
        /// </summary>
        private static Timer s_autoCloseTimer;

        /// <summary>
        /// Entry point of the application
        /// </summary>
        /// <param name="args">Arguments passed on startup</param>
        private static void Main()
        {
            s_autoCloseTimer = new Timer(20000); // 20 seconds
            s_autoCloseTimer.Elapsed += OnAutoCloseTimer;
            s_autoCloseTimer.Start();

            Console.ReadKey();
        }

        /// <summary>
        /// Raised when the <see cref="s_autoCloseTimer"/> elapsed and automaticly closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnAutoCloseTimer(object sender, ElapsedEventArgs e)
        {
            s_autoCloseTimer.Close();
            s_autoCloseTimer.Dispose();
            Environment.Exit(0);
        }
    }
}
