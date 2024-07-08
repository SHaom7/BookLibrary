using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class Book
    {
            public Guid BookId { get; set; } = Guid.NewGuid();
            public string Title { get; set; }
            public string Author { get; set; }
            public int Copies { get; set; }
            public List<MemberBook> MemberBooks { get; set; }
    }
}
