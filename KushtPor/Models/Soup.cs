using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KushtPor
{
    public class Soup
    {
        /// <summary>
        /// Soup Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Soup Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Soup Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Soup Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Restaurants Name
        /// </summary>
        public string Restaurant { get; set; }
    }
}
