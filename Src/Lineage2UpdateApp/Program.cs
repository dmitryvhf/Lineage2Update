using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Lineage2UpdateApp.Services;

namespace Lineage2UpdateApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);

            SupportTools.CheckSelfUpdate();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        #region Private methods

        private static void UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception exc = (Exception)args.ExceptionObject;
            string appLastWord = $"[UnhandledException]\t{exc.Message}";

            SupportTools.LogEntry(appLastWord);
        }

        #endregion
    }
}