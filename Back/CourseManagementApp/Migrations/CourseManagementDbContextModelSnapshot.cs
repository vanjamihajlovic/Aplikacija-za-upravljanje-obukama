﻿// <auto-generated />
using System;
using CourseManagementApp.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseManagementApp.Migrations
{
    [DbContext(typeof(CourseManagementDbContext))]
    partial class CourseManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseManagementApp.Model.CandidateCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeedBack")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("ModulesFinished")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("CourseId");

                    b.ToTable("CandidateCourses");
                });

            modelBuilder.Entity("CourseManagementApp.Model.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("MentorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumOfModules")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.HasIndex("TrainingId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseManagementApp.Model.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c92b63e6-3077-492a-b15c-34acb4485a19",
                            ConcurrencyStamp = "01d87a38-1c91-48b2-bc0c-7e411c83ee0b",
                            Name = "ADMINISTRATOR",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "654440b3-e250-4c17-9d7c-27d5e316e482",
                            ConcurrencyStamp = "6ad4d017-17ee-4bd1-bb49-2e9e3d567152",
                            Name = "CANDIDATE",
                            NormalizedName = "CANDIDATE"
                        },
                        new
                        {
                            Id = "98206124-235d-42d4-9c86-818398c7e48a",
                            ConcurrencyStamp = "01ba1221-2660-418c-bf07-7f20f105ce14",
                            Name = "MENTOR",
                            NormalizedName = "MENTOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "7d298323-0284-4ff6-b83b-31272dd7602e",
                            RoleId = "c92b63e6-3077-492a-b15c-34acb4485a19"
                        },
                        new
                        {
                            UserId = "9c097bdc-d941-41f5-aa1d-293276d3dc2c",
                            RoleId = "654440b3-e250-4c17-9d7c-27d5e316e482"
                        },
                        new
                        {
                            UserId = "4cd115e0-2630-43fd-bda4-3a6d8ef79be6",
                            RoleId = "98206124-235d-42d4-9c86-818398c7e48a"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CourseManagementApp.Model.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "7d298323-0284-4ff6-b83b-31272dd7602e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cd1d03c4-c096-4bba-af73-25d1b5b7d8be",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEXFg5ruenEa0Y+RCZiUqAcckYMRnbx8+kg3PKkms3QPkRUfXdqZLPGWpFTu6fYmog==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6011e0b3-e00d-4581-b1d5-f0dc740c13be",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com",
                            FirstName = "ADMINISTRATOR",
                            LastName = "ADMINISTRATOR",
                            Role = 1
                        },
                        new
                        {
                            Id = "9c097bdc-d941-41f5-aa1d-293276d3dc2c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d57a4151-484d-4967-8098-abc6cceaa8bd",
                            Email = "candidate@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "CANDIDATE@MAIL.COM",
                            NormalizedUserName = "CANDIDATE@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEXFg5ruenEa0Y+RCZiUqAcckYMRnbx8+kg3PKkms3QPkRUfXdqZLPGWpFTu6fYmog==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "654c0b4a-0e1c-4218-bd3a-41361bb3072c",
                            TwoFactorEnabled = false,
                            UserName = "candidate@mail.com",
                            FirstName = "CANDIDATE",
                            LastName = "CANDIDATE",
                            Role = 3
                        },
                        new
                        {
                            Id = "4cd115e0-2630-43fd-bda4-3a6d8ef79be6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ddd3b557-5664-4e5b-a8eb-9defc0934acf",
                            Email = "mentor@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MENTOR@MAIL.COM",
                            NormalizedUserName = "MENTOR@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEXFg5ruenEa0Y+RCZiUqAcckYMRnbx8+kg3PKkms3QPkRUfXdqZLPGWpFTu6fYmog==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f3ff1e66-469a-4bc8-8885-6265cf7eda2a",
                            TwoFactorEnabled = false,
                            UserName = "mentor@mail.com",
                            FirstName = "MENTOR",
                            LastName = "MENTOR",
                            Role = 2
                        });
                });

            modelBuilder.Entity("CourseManagementApp.Model.CandidateCourse", b =>
                {
                    b.HasOne("CourseManagementApp.Model.User", "Candidate")
                        .WithMany("Courses")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseManagementApp.Model.Course", "Course")
                        .WithMany("CandidatesEnrolled")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CourseManagementApp.Model.Course", b =>
                {
                    b.HasOne("CourseManagementApp.Model.User", "Mentor")
                        .WithMany("MentorCourses")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseManagementApp.Model.Training", "Training")
                        .WithMany("Courses")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mentor");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseManagementApp.Model.Course", b =>
                {
                    b.Navigation("CandidatesEnrolled");
                });

            modelBuilder.Entity("CourseManagementApp.Model.Training", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("CourseManagementApp.Model.User", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("MentorCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
