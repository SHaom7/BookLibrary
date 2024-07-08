using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class Member
    {
        public Guid MemberId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<MemberBook> MemberBooks { get; set; }

    }
}
