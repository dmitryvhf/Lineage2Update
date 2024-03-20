using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lineage2UpdateApp.Models
{
    /// <summary>
    ///     Business logic exceptions
    /// </summary>
    /// <remarks>Result: application stop working</remarks>
    internal class ExecuteException : Exception
    {
        public ExecuteException(string message) : base(message)
        {
        }

        public ExecuteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
