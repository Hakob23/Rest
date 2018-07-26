using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KushtPor
{
   public  class Salad
    {
        /// <summary>
        /// Salad Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Salad Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Salad Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Salad Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Restaurants Name
        /// </summary>
        public string Restaurant { get; set; }
    }
}
