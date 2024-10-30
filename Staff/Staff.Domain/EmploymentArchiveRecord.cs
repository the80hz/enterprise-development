using System;

namespace Staff.Models
{
    public class EmploymentArchiveRecord
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // null if currently employed
        public Position Position { get; set; }
    }
}
