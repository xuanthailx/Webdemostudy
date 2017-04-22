namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnLinewebDbContext : DbContext
    {
        public OnLinewebDbContext()
            : base("name=OnLinewebDbContext")
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<CostDetail> CostDetails { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<MatchUp> MatchUps { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Time> Times { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Budget> Budgets { get; set; }
        public virtual DbSet<Participate> Participates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Course1)
                .HasForeignKey(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Email>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Email1)
                .HasForeignKey(e => e.Email);

            modelBuilder.Entity<Email>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Email1)
                .HasForeignKey(e => e.Email)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.Participates)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Major>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Major1)
                .HasForeignKey(e => e.Major)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatchUp>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<Student>()
                .Property(e => e.CheckIn)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Participates)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Time>()
                .Property(e => e.Time1)
                .HasPrecision(0);

            modelBuilder.Entity<Time>()
                .HasMany(e => e.MatchUps)
                .WithRequired(e => e.Time1)
                .HasForeignKey(e => e.Time)
                .WillCascadeOnDelete(false);
        }
    }
}
