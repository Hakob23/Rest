using System;

namespace BusinessLayer
{
    /// <summary>
    /// Mapper class based on reflection.
    /// </summary>
    /// <typeparam name="TS">Type of source.</typeparam>
    /// <typeparam name="TD">Type of destination.</typeparam>
    class ReflectionBasedMapper<TS, TD> : IMapper<TS, TD>
    {
        /// <summary>
        /// Maps source object to destination object
        /// </summary>
        /// <param name="source">Source object</param>
        /// <returns>Destination object</returns>
        public TD Map(TS source)
        {
            return this.MapImpl<TD, TS>(source);
        }

        /// <summary>
        /// Maps Destination object to Source object
        /// </summary>
        /// <param name="Source">Destination object</param>
        /// <returns>Source object</returns>
        public TS MapBack(TD destination)
        {
            return this.MapImpl<TS, TD>(destination);
        }

        /// <summary>
        /// Maps T1 to T2
        /// </summary>
        /// <typeparam name="T1">Type Destination</typeparam>
        /// <typeparam name="T2">Type Source</typeparam>
        /// <param name="source"> Source</param>
        /// <returns>Destination object</returns>
        private T1 MapImpl<T1, T2>(T2 source)
        {
            var td = Activator.CreateInstance<T1>();

            foreach (var sourceProp in typeof(T2).GetProperties())
            {
                var destProp = typeof(T1).GetProperty(sourceProp.Name);

                destProp.SetValue(td, sourceProp.GetValue(source));
            }
            return td;
        }
    }
}
