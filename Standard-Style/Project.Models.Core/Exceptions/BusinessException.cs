using System;

namespace Project.Models.Core.Exceptions
{
    /// <summary>
    ///     BUSINESS EXCEPTION
    /// </summary>
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException(string ex)
            : base(ex)
        {
        }
    }
}