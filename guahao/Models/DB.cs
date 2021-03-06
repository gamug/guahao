namespace guahao.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB1")
        {
        }

        public virtual DbSet<administrator> administrator { get; set; }
        public virtual DbSet<appointment> appointment { get; set; }
        public virtual DbSet<city> city { get; set; }
        public virtual DbSet<department> department { get; set; }
        public virtual DbSet<doctor> doctor { get; set; }
        public virtual DbSet<hospital> hospital { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<visit> visit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<administrator>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<administrator>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .Property(e => e.abr_name)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .HasMany(e => e.hospital)
                .WithOptional(e => e.city1)
                .HasForeignKey(e => e.city);

            modelBuilder.Entity<department>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .HasMany(e => e.doctor)
                .WithOptional(e => e.department)
                .HasForeignKey(e => e.department_id);

            modelBuilder.Entity<doctor>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.rank)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.is_good)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.appointment)
                .WithOptional(e => e.doctor)
                .HasForeignKey(e => e.doctor_id);

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.visit)
                .WithRequired(e => e.doctor)
                .HasForeignKey(e => e.doctor_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hospital>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<hospital>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<hospital>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<hospital>()
                .HasMany(e => e.appointment)
                .WithOptional(e => e.hospital)
                .HasForeignKey(e => e.hospital_id);

            modelBuilder.Entity<hospital>()
                .HasMany(e => e.department)
                .WithRequired(e => e.hospital)
                .HasForeignKey(e => e.hospital_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.real_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.social_id)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.appointment)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);
        }
    }
}
