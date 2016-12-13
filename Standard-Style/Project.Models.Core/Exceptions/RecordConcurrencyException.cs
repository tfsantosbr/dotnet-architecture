using System;

namespace Project.Models.Core.Exceptions
{
    /// <summary>
    ///     RECORD CONCURRENCY EXCEPTION
    /// </summary>
    [Serializable]
    public class RecordConcurrencyException : Exception
    {
        public RecordConcurrencyException(string ex)
            : base(ex)
        {
        }
    }
}