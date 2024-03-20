using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lineage2UpdateApp.Models
{
    /// <summary>
    ///     Application constant values
    /// </summary>
    internal static class AppConstants
    {
        /// <summary>
        ///     Application name
        /// </summary>
        internal const string ApplicationName = "Lineage2Update";

        /// <summary>
        ///     Application executable file name
        /// </summary>
        internal const string MainExecName = $"{ApplicationName}.exe";

        /// <summary>
        ///     New executable file name
        /// </summary>
        internal const string SelfUpdateExecName = $"{MainExecName}.new";

        /// <summary>
        ///     Log file name
        /// </summary>
        internal const string LogFileName = $"{ApplicationName}.log";
    }
}
