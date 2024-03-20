using System;
using System.Text.Json.Serialization;

namespace Lineage2UpdateApp.Models.Configuration
{
    /// <summary>
    ///     Lineage II Updater client. Local configuration.
    /// </summary>
    public class AppConfiguration
    {
        /// <summary>
        ///     Config version
        /// </summary>
        [JsonRequired]
        public required int Version { get; init; }

        /// <summary>
        ///     Remote address of update storage base path
        /// </summary>
        [JsonRequired]
        public required Uri UpdateBasePath { get; init; }
    }
}