﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudioReservationAPP.Core.EFContext;

#nullable disable

namespace StudioReservationAPP.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("ClassesId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnrollCount")
                        .HasColumnType("int");

                    b.Property<int>("EnrollQuota")
                        .HasColumnType("int");

                    b.Property<DateTime>("EstimatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LessonLevel")
                        .HasColumnType("int");

                    b.Property<int>("LessonType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.Property<int>("WaitingQueueCount")
                        .HasColumnType("int");

                    b.Property<int>("WaitingQueueQuota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("ClassesId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubscriptionsId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionsId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.MemberLesson", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsCheckin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsEnrolled")
                        .HasColumnType("bit");

                    b.HasKey("MemberId", "LessonId");

                    b.HasIndex("LessonId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubsType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.TrainerWorkPlace", b =>
                {
                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("BranchId", "TrainerId");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainerWorkPlaces");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.WaitingQueue", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("QueueEnrollTime")
                        .HasColumnType("datetime2");

                    b.HasKey("MemberId", "LessonId");

                    b.HasIndex("LessonId");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("WaitingQueues");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Class", b =>
                {
                    b.HasOne("StudioReservationAPP.Core.Entities.Branch", "Branch")
                        .WithMany("Classes")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Lesson", b =>
                {
                    b.HasOne("StudioReservationAPP.Core.Entities.Branch", null)
                        .WithMany("Lesson")
                        .HasForeignKey("BranchId");

                    b.HasOne("StudioReservationAPP.Core.Entities.Class", "Classes")
                        .WithMany("Lessons")
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudioReservationAPP.Core.Entities.Trainer", "Trainer")
                        .WithMany("Lesson")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classes");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Member", b =>
                {
                    b.HasOne("StudioReservationAPP.Core.Entities.Subscription", "Subscriptions")
                        .WithMany("Members")
                        .HasForeignKey("SubscriptionsId");

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.MemberLesson", b =>
                {
                    b.HasOne("StudioReservationAPP.Core.Entities.Lesson", "Lesson")
                        .WithMany("MemberLessons")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudioReservationAPP.Core.Entities.Member", "Member")
                        .WithMany("MemberLessons")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.TrainerWorkPlace", b =>
                {
                    b.HasOne("StudioReservationAPP.Core.Entities.Branch", "Branch")
                        .WithMany("TrainerWorkPlaces")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudioReservationAPP.Core.Entities.Trainer", "Trainer")
                        .WithMany("TrainerWorkPlaces")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.WaitingQueue", b =>
                {
                    b.HasOne("StudioReservationAPP.Core.Entities.Lesson", "Lesson")
                        .WithMany("WaitingQueues")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudioReservationAPP.Core.Entities.Member", "Member")
                        .WithOne("WaitingQueue")
                        .HasForeignKey("StudioReservationAPP.Core.Entities.WaitingQueue", "MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Branch", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Lesson");

                    b.Navigation("TrainerWorkPlaces");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Class", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Lesson", b =>
                {
                    b.Navigation("MemberLessons");

                    b.Navigation("WaitingQueues");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Member", b =>
                {
                    b.Navigation("MemberLessons");

                    b.Navigation("WaitingQueue");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Subscription", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("StudioReservationAPP.Core.Entities.Trainer", b =>
                {
                    b.Navigation("Lesson");

                    b.Navigation("TrainerWorkPlaces");
                });
#pragma warning restore 612, 618
        }
    }
}
