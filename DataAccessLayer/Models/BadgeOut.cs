using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class BadgeOut
    {
        

        public string PhotoUrl { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string TempBadge { get; set; } = null!;

        public string SignOut { get; set; } 

        public int AssignTime { get; set; }

        public string Status { get; set; } 
    }
}
