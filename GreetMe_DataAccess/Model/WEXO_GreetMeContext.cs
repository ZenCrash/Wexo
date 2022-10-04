using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GreetMe_DataAccess.Model
{
    public partial class WEXO_GreetMeContext : DbContext
    {
        public WEXO_GreetMeContext()
        {
        }

        public WEXO_GreetMeContext(DbContextOptions<WEXO_GreetMeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompanyAddress> CompanyAddresses { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Meeting> Meetings { get; set; } = null!;
        public virtual DbSet<MeetingRoom> MeetingRooms { get; set; } = null!;
        public virtual DbSet<MeetingsPerson> MeetingsPeople { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=WEXO_GreetMe;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyAddress>(entity =>
            {
                entity.ToTable("company_addresses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApartmentNumber)
                    .HasMaxLength(10)
                    .HasColumnName("apartment_number");

                entity.Property(e => e.City)
                    .HasMaxLength(1)
                    .HasColumnName("city");

                entity.Property(e => e.StreetName)
                    .HasMaxLength(50)
                    .HasColumnName("street_name");

                entity.Property(e => e.StreetNumber).HasColumnName("street_number");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__customer__543848DF99012FDC");

                entity.ToTable("customers");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("person_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .HasColumnName("company_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.PersonId)
                    .HasConstraintName("FK_customers_people_id");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__employee__543848DFAA43F186");

                entity.ToTable("employees");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("person_id");

                entity.Property(e => e.CompanyAddressId).HasColumnName("company_address_id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.HiringDate)
                    .HasColumnType("datetime")
                    .HasColumnName("hiring_date");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .HasColumnName("nickname");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role");

                entity.HasOne(d => d.CompanyAddress)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CompanyAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employees_company_addresses_id");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.PersonId)
                    .HasConstraintName("FK_employees_people_id");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__logins__543848DF2206A133");

                entity.ToTable("logins");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("person_id");

                entity.Property(e => e.HashedPassword)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("hashed_password");

                entity.Property(e => e.Salt)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("salt");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Login)
                    .HasForeignKey<Login>(d => d.PersonId)
                    .HasConstraintName("FK_logins_people_id");
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.ToTable("meetings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Decription)
                    .HasMaxLength(560)
                    .HasColumnName("decription");

                entity.Property(e => e.EndDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date_time");

                entity.Property(e => e.MeetingCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("meeting_code");

                entity.Property(e => e.MeetingRoomId).HasColumnName("meeting_room_id");

                entity.Property(e => e.MeetingTitle)
                    .HasMaxLength(50)
                    .HasColumnName("meeting_title");

                entity.Property(e => e.PreparationDecription)
                    .HasMaxLength(560)
                    .HasColumnName("preparation_decription");

                entity.Property(e => e.StartDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date_time");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.HasOne(d => d.MeetingRoom)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.MeetingRoomId)
                    .HasConstraintName("FK_meetings_meeting_rooms_id");
            });

            modelBuilder.Entity<MeetingRoom>(entity =>
            {
                entity.ToTable("meeting_rooms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.CompanyAddressId).HasColumnName("company_address_id");

                entity.Property(e => e.Decription)
                    .HasMaxLength(560)
                    .HasColumnName("decription");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(50)
                    .HasColumnName("room_name");

                entity.HasOne(d => d.CompanyAddress)
                    .WithMany(p => p.MeetingRooms)
                    .HasForeignKey(d => d.CompanyAddressId)
                    .HasConstraintName("FK_meeting_rooms_company_addresses_id");
            });

            modelBuilder.Entity<MeetingsPerson>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meetings_people");

                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Meeting)
                    .WithMany()
                    .HasForeignKey(d => d.MeetingId)
                    .HasConstraintName("FK_meetings_people_meetings_id");

                entity.HasOne(d => d.Person)
                    .WithMany()
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_meetings_people_people_id");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("people");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .HasColumnName("job_title");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.WorkPhoneNumber).HasColumnName("work_phone_number");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__services__543848DF81BEE552");

                entity.ToTable("services");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("person_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Service1)
                    .HasMaxLength(50)
                    .HasColumnName("service");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Service)
                    .HasForeignKey<Service>(d => d.PersonId)
                    .HasConstraintName("FK_services_people_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
