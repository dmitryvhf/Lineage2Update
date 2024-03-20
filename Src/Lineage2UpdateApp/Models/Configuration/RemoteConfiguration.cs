using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Lineage2UpdateApp.Models.Configuration
{
    /// <summary>
    ///     Lineage II Updater client. Remote configuration.
    /// </summary>
    public class RemoteConfiguration
    {
        [JsonPropertyName("Settings")]
        public RemoteSettingsSection Settings { get; set; }

        [JsonPropertyName("Update")]
        public RemoteUpdateSection Update { get; set; }
    }

    public class RemoteUpdateSection
    {
        /// <summary>
        ///     Remote configuration created time
        /// </summary>
        [JsonPropertyName("Time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("Self")]
        public string Self { get; set; }

        /// <summary>
        ///     Critical file list
        /// </summary>
        [JsonPropertyName("Critical")]
        public IDictionary<string, string> Critical { get; set; } = new Dictionary<string, string>();

        /// <summary>
        ///     Full file list
        /// </summary>
        [JsonPropertyName("Full")]
        public IDictionary<string, string> Full { get; set; } = new Dictionary<string, string>();
    }

    public class RemoteSettingsSection
    {
        /// <summary>
        ///     Product application execution file
        /// </summary>
        public string? ProductExec { get; set; } = "System\\L2.exe";

        /// <summary>
        ///     Close updater after start product application
        /// </summary>
        public bool CloseAfterStart { get; set; }

        /// <summary>
        ///     Force checking all files
        /// </summary>
        public bool ForceChecking { get; set; }

        /// <summary>
        ///     Lineage II Authentication server IP address
        /// </summary>
        public string? AuthServer { get; set; }
    }
}