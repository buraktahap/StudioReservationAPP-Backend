using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.Entities;

namespace StudioReservationAPP.Core.EFContext
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        /// <summary>
        /// initializes a new instance of DbContext class.
        /// </summary>
        /// <param name="options"></param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<MemberLesson> MemberLessons { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainerWorkPlace> TrainerWorkPlaces { get; set; }
        public DbSet<WaitingQueue> WaitingQueues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<TrainerWorkPlace>()
                .HasKey(tw => new { tw.BranchId, tw.TrainerId });
            modelBuilder.Entity<TrainerWorkPlace>()
                .HasOne(tw => tw.Trainer)
                .WithMany(t => t.TrainerWorkPlaces)
                .HasForeignKey(tw => tw.TrainerId);
            modelBuilder.Entity<TrainerWorkPlace>()
                .HasOne(tw => tw.Branch)
                .WithMany(w => w.TrainerWorkPlaces)
                .HasForeignKey(tw => tw.BranchId);

            modelBuilder.Entity<MemberLesson>()
               .HasKey(ml => new { ml.MemberId, ml.LessonId});
            modelBuilder.Entity<MemberLesson>()
                .HasOne(ml => ml.Member)
                .WithMany(m => m.MemberLessons)
                .HasForeignKey(ml => ml.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MemberLesson>()
                .HasOne(ml => ml.Lesson)
                .WithMany(l => l.MemberLessons)
                .HasForeignKey(ml => ml.LessonId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<WaitingQueue>()
            //    .HasKey(wq=> new { wq.MemberId, wq.LessonId });
            //modelBuilder.Entity<WaitingQueue>()
            //    .HasOne(wq => wq.Member)
            //    .WithOne(m => m.WaitingQueue)
            //    .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<WaitingQueue>()
            //    .HasOne(l => l.Lesson)
            //    .WithMany(wq=> wq.WaitingQueues)
            //    .HasForeignKey(wq=>wq.LessonId)
            //    .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
