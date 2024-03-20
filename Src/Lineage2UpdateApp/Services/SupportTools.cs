using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Lineage2UpdateApp.Models;

namespace Lineage2UpdateApp.Services
{
    /// <summary>
    ///     Any support methods
    /// </summary>
    internal static class SupportTools
    {
        /// <summary>
        ///     Read and deserialize JSON file
        /// </summary>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="content">JSON content</param>
        /// <returns>Deserialized object; null - error</returns>
        internal static T? Deserialize<T>(string content)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(content);
        }

        /// <summary>
        ///     Quick save message to log file
        /// </summary>
        /// <param name="message"></param>
        internal static void LogEntry(string message)
        {
            string logPath = System.IO.Path.GetDirectoryName(Environment.ProcessPath) + $"\\{AppConstants.LogFileName}";

            message = $"{DateTime.Now:O}\t{message}\n";

            System.IO.File.AppendAllText(logPath, message);
        }


        /// <summary>
        ///     Self update
        /// </summary>
        // todo: remove logging or refactoring with LogLevel configuration
        internal static void CheckSelfUpdate()
        {
            // Normal mode
            if (Path.GetFileName(Application.ExecutablePath) == AppConstants.MainExecName)
            {
                // Old executable file found
                // MessageBox.Show("start normal mode")
                SupportTools.LogEntry("start normal mode");

                if (File.Exists(AppConstants.SelfUpdateExecName) == true)
                {
                    Process? proc = Process.GetProcessesByName(AppConstants.SelfUpdateExecName).FirstOrDefault();
                    if (proc != null)
                    {
                        SupportTools.LogEntry($"try kill process id:{proc.Id} exited: {proc.HasExited}");
                        proc.Kill();

                        // LogEntry($"try kill process id:{proc.Id}; exited: {proc.HasExited}. Waiting...");
                        proc.WaitForExit(2000);

                        // Try stop process, if exists
                        int tryingCount = 5;
                        while (!proc.HasExited)
                        {
                            // Waiting while old process live
                            SupportTools.LogEntry($"try kill process id:{proc.Id}; exited: {proc.HasExited}. Waiting...");
                            proc.WaitForExit(1000);
                            tryingCount--;

                            if (tryingCount == 0)
                            {
                                SupportTools.LogEntry($"try kill process id:{proc.Id} failed. Max trying exceed. Application stop.");
                                Application.Exit();
                            }
                        }

                        SupportTools.LogEntry($"process id:{proc?.Id}; exited: {proc?.HasExited}. Waiting...");
                    }

                    // Try delete new executable file
                    SupportTools.LogEntry("Try delete new executable file");

                    try
                    {
                        File.Delete(AppConstants.SelfUpdateExecName);
                    }
                    catch (Exception e)
                    {
                        SupportTools.LogEntry($"Try deleting new executable file. Fail with {e.Message}");
                        throw;
                    }

                    SupportTools.LogEntry("Try delete new executable file. Complete.");
                }

                return;
            }

            if (Path.GetFileName(Application.ExecutablePath) != AppConstants.SelfUpdateExecName)
            {
                // Invalid updater tool name. Stop application.
                SupportTools.LogEntry("Invalid updater tool name. Stop application.");

                Application.Exit();
                return;
            }

            // Update mode. New executable found.
            SupportTools.LogEntry("Update mode. New executable found.");

            File.Copy(AppConstants.SelfUpdateExecName, AppConstants.MainExecName, overwrite: true);
            SupportTools.LogEntry("Update mode. New executable copied to common filename");

            ProcessStartInfo newExec = new ProcessStartInfo(AppConstants.MainExecName) { WindowStyle = ProcessWindowStyle.Normal };

            SupportTools.LogEntry("Update mode. Starting normal executable");
            Process.Start(newExec);
            SupportTools.LogEntry("Update mode. Starting normal executable. Complete.");

            Application.Exit();
        }
    }
}
