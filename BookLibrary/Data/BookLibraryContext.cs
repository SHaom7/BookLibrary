using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data
{
    public class BookLibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members  { get; set; }
        public DbSet<MemberBook> MemberBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(("Server=SHDN7\\SQLEXPRESS;Database=BookLibraryDB; Integrated Security=true; TrustServerCertificate=true;"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberBook>()
                .HasKey(mb => new { mb.MemberId, mb.BookId });

            modelBuilder.Entity<MemberBook>()
                .HasOne(mb => mb.Member)
                .WithMany(m => m.MemberBooks)
                .HasForeignKey(mb => mb.MemberId);

            modelBuilder.Entity<MemberBook>()
                .HasOne(mb => mb.Book)
                .WithMany(b => b.MemberBooks)
                .HasForeignKey(mb => mb.BookId);
        }
    }
}
