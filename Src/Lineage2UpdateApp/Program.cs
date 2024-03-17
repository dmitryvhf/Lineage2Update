using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lineage2UpdateApp
{
    internal static class Program
    {
        private const string MainExecName = "Lineage2Update.exe";
        private const string SelfUpdateExecName = MainExecName + ".new";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CheckSelfUpdate();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static void LogEntry(string message)
        {
            string logPath = System.IO.Path.GetDirectoryName(Environment.ProcessPath) + "\\_proc.log";

            string currentTime = DateTime.Now.ToString("O");
            message = $"{currentTime}\t{message}\n";

            System.IO.File.AppendAllText(logPath, message);
        }

        private static void CheckSelfUpdate()
        {
            // Normal mode
            if (Path.GetFileName(Application.ExecutablePath) == MainExecName)
            {
                // Old executable file found
                // MessageBox.Show("start normal mode")
                LogEntry("start normal mode");

                if (File.Exists(SelfUpdateExecName) == true)
                {
                    Process? proc = Process.GetProcessesByName(SelfUpdateExecName).FirstOrDefault();
                    if (proc != null)
                    {
                        LogEntry($"try kill process id:{proc.Id} exited: {proc.HasExited}");
                        proc.Kill();

                        // LogEntry($"try kill process id:{proc.Id}; exited: {proc.HasExited}. Waiting...");
                        proc.WaitForExit(2000);

                        // Try stop process, if exists
                        int tryingCount = 5;
                        while (!proc.HasExited)
                        {
                            // Waiting while old process live
                            LogEntry($"try kill process id:{proc.Id}; exited: {proc.HasExited}. Waiting...");
                            proc.WaitForExit(1000);
                            tryingCount--;

                            if (tryingCount == 0)
                            {
                                LogEntry($"try kill process id:{proc.Id} failed. Max trying exceed. Application stop.");
                                Application.Exit();
                            }
                        }

                        LogEntry($"process id:{proc?.Id}; exited: {proc?.HasExited}. Waiting...");
                    }

                    // Try delete new executable file
                    LogEntry("Try delete new executable file");

                    try
                    {
                        File.Delete(SelfUpdateExecName);
                    }
                    catch (Exception e)
                    {
                        LogEntry($"Try delete new executable file. Fail with {e.Message}");
                        Console.WriteLine(e);
                        throw;
                    }

                    LogEntry("Try delete new executable file. Complete.");
                }

                return;
            }

            if (Path.GetFileName(Application.ExecutablePath) != SelfUpdateExecName)
            {
                // Invalid updater tool name. Stop application.
                LogEntry("Invalid updater tool name. Stop application.");

                Application.Exit();
                return;
            }

            // Update mode. New executable found.
            LogEntry("Update mode. New executable found.");

            File.Copy(SelfUpdateExecName, MainExecName, overwrite: true);
            LogEntry("Update mode. New executable copied to common filename");

            ProcessStartInfo newExec = new ProcessStartInfo(MainExecName)
            {
                WindowStyle = ProcessWindowStyle.Normal
            };

            LogEntry("Update mode. Starting normal executable");
            Process.Start(newExec);
            LogEntry("Update mode. Starting normal executable. Complete.");

            Application.Exit();
        }
    }
}