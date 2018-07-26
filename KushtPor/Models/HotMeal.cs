using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KushtPor
{
    public class HotMeal
    {

        /// <summary>
        /// Hot Meal Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Hot Meal Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Hot Meal Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Hot Meal Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Restaurants Name
        /// </summary>
        public string Restaurant { get; set; }
    }
}
