namespace CRMTest.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelCRMTest : DbContext
    {
        public ModelCRMTest()
            : base("name=CRMTest")
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Address_line_1)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Address_line_2)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Siren)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.ISO2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Company)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.Country_ID);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
