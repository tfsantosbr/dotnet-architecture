namespace Project.Models.Core.Entities.Base
{
    /// <summary>
    ///     ROW VERSION INTERFACE
    /// </summary>
    public interface IRowVersion
    {
        /// <summary>
        ///     ROW VERSION FOR DBCONCURRENCY
        /// </summary>
        byte[] RowVersion { get; set; }
    }
}