using System;

namespace NginxProxyManager.SDK.Models
{
    public class User
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Whether the user is an administrator
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Date and time of creation
        /// </summary>
        public string CreatedOn { get; set; }

        /// <summary>
        /// Date and time of last update
        /// </summary>
        public string ModifiedOn { get; set; }
    }
} 