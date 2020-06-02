namespace RESTEventVisitor.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProfileModel : DbContext
    {
        public ProfileModel()
            : base("name=ProfileModel")
        {
        }

        public virtual DbSet<Profile> Profile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .Property(e => e.Profile_Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Profile_Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Profile_Role)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Profile_PhoneNr)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Profile_Email)
                .IsUnicode(false);
        }
    }
}
