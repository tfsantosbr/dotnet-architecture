using System;

namespace Project.Models.Core.Exceptions
{
    /// <summary>
    ///     INCATIVE RECORD EXCEPTION
    /// </summary>
    [Serializable]
    public class InactiveRecordException : Exception
    {
        public InactiveRecordException()
        {
        }

        public InactiveRecordException(string ex)
            : base(ex)
        {
        }
    }
}