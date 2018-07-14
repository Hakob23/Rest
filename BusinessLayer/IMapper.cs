namespace BusinessLayer
{
    /// <summary>
    /// Mapper interface.
    /// </summary>
    /// <typeparam name="TS">Type of source.</typeparam>
    /// <typeparam name="TD">Ttpe of destination.</typeparam>
    interface IMapper<TS, TD>
    {
        /// <summary>
        /// Maps source to destination.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>Returns destination.</returns>
        TD Map(TS source);

        /// <summary>
        /// Maps destination to source.
        /// </summary>
        /// <param name="destination">The destination.</param>
        /// <returns>Returns source.</returns>
        TS MapBack(TD destination);
    }
}
