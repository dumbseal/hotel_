using System;
using System.Collections.Generic;

namespace Domian.Models
{
    public class Admin
    {
        public Admin()
        {
            Logs = new HashSet<Log>();
        }

        public int AdminId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public virtual Booking AdminNavigation { get; set; } = null!;
        public virtual ICollection<Log> Logs { get; set; }
    }
}
