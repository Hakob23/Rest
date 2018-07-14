using System;

namespace UsersRepository
{
    /// <summary>
    /// Database UsersDB user
    /// </summary>
    public class User
    {
        public int Id { get; set; }

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
