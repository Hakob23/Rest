using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KushtPor
{
    public class User
    {
        /// <summary>
        /// Gets or sets username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// gets ro sets email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Get or sets Is email verifyed
        /// </summary>
        public bool IsEmailVerifyed { get; set; }

        /// <summary>
        /// Gets or sets Activation Code
        /// </summary>
        public Guid ActivationCode { get; set; }

        /// <summary>
        /// Gets or sets Role
        /// </summary>
        public string Role { get; set; }
    }
}
