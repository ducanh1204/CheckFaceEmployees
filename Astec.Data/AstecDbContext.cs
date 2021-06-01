using Astec.Model.Models;
using System.Data.Entity;

namespace Astec.Data
{
    public class AstecDbContext : DbContext
    {
        public AstecDbContext() : base("AstecConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public static AstecDbContext Create()
        {
            return new AstecDbContext();
        }

        public virtual DbSet<EMPLOYEE> EMPLOYEES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EMPLOYEE>()
                 .Property(e => e.NameEn);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.NameVn);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.Gender);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.Bod);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.Country);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.Address);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PaperType);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PassportNumber)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.IssueDate);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.ExpireDate)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.Cccd)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.Cmtc)
                .IsUnicode(false);

        }

    }
}