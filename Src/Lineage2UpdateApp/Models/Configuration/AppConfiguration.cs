using System;

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
        public required int Version { get; init; }

        /// <summary>
        ///     Remote address of update storage
        /// </summary>
        public required Uri UpdateUrl { get; init; }

        public bool Validate()
        {
            if (Version <= 0)
            {
                return false;
            }

            if (UpdateUrl == null)
            {
                return false;
            }

            return true;
        }
    }
}