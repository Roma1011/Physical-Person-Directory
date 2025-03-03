﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhysicalPersonDirectory.Core.DAO.Context;

#nullable disable

namespace PhysicalPersonDirectory.Core.DAO.Context.Migrations
{
    [DbContext(typeof(PhysicalPersonDbContext))]
    partial class PhysicalPersonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PhysicalPersonDirectory.Core.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "თბილისი"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ქუთაისი"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ბათუმი"
                        },
                        new
                        {
                            Id = 4,
                            Name = "რუსთავი"
                        },
                        new
                        {
                            Id = 5,
                            Name = "გორი"
                        },
                        new
                        {
                            Id = 6,
                            Name = "ზუგდიდი"
                        },
                        new
                        {
                            Id = 7,
                            Name = "ფოთი"
                        },
                        new
                        {
                            Id = 8,
                            Name = "თელავი"
                        },
                        new
                        {
                            Id = 9,
                            Name = "ოზურგეთი"
                        },
                        new
                        {
                            Id = 10,
                            Name = "ამბროლაური"
                        },
                        new
                        {
                            Id = 11,
                            Name = "ახალციხე"
                        },
                        new
                        {
                            Id = 12,
                            Name = "ახალქალაქი"
                        },
                        new
                        {
                            Id = 13,
                            Name = "მარნეული"
                        },
                        new
                        {
                            Id = 14,
                            Name = "გარდაბანი"
                        },
                        new
                        {
                            Id = 15,
                            Name = "ბოლნისი"
                        },
                        new
                        {
                            Id = 16,
                            Name = "დუშეთი"
                        },
                        new
                        {
                            Id = 17,
                            Name = "საგარეჯო"
                        },
                        new
                        {
                            Id = 18,
                            Name = "ლაგოდეხი"
                        },
                        new
                        {
                            Id = 19,
                            Name = "ბორჯომი"
                        },
                        new
                        {
                            Id = 20,
                            Name = "ცხინვალი"
                        },
                        new
                        {
                            Id = 21,
                            Name = "ცაგერი"
                        },
                        new
                        {
                            Id = 22,
                            Name = "ლენტეხი"
                        },
                        new
                        {
                            Id = 23,
                            Name = "მესტია"
                        },
                        new
                        {
                            Id = 24,
                            Name = "წალენჯიხა"
                        },
                        new
                        {
                            Id = 25,
                            Name = "ჩხოროწყუ"
                        },
                        new
                        {
                            Id = 26,
                            Name = "ხობი"
                        },
                        new
                        {
                            Id = 27,
                            Name = "სენაკი"
                        },
                        new
                        {
                            Id = 28,
                            Name = "მარტვილი"
                        },
                        new
                        {
                            Id = 29,
                            Name = "ვანი"
                        },
                        new
                        {
                            Id = 30,
                            Name = "ტყიბული"
                        },
                        new
                        {
                            Id = 31,
                            Name = "ბაღდათი"
                        },
                        new
                        {
                            Id = 32,
                            Name = "ხარაგაული"
                        },
                        new
                        {
                            Id = 33,
                            Name = "საჩხერე"
                        },
                        new
                        {
                            Id = 34,
                            Name = "ხონი"
                        },
                        new
                        {
                            Id = 35,
                            Name = "ნინოწმინდა"
                        });
                });

            modelBuilder.Entity("PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateOfPBirth")
                        .HasColumnType("date");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ImageSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TypeOfPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("CityId")
                        .IsUnique()
                        .HasFilter("[CityId] IS NOT NULL");

                    b.HasIndex("Pid")
                        .IsUnique();

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            DateOfPBirth = new DateOnly(1985, 11, 25),
                            Gender = "Male",
                            Name = "გიორგი",
                            PhoneNumber = "599123456",
                            Pid = "01001000001",
                            Surname = "აბაშიძე",
                            TypeOfPhone = "Mobile"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 2,
                            DateOfPBirth = new DateOnly(1995, 5, 3),
                            Gender = "Female",
                            Name = "მარიამ",
                            PhoneNumber = "577654321",
                            Pid = "01001000002",
                            Surname = "ბერიძე",
                            TypeOfPhone = "Mobile"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 3,
                            DateOfPBirth = new DateOnly(2005, 8, 11),
                            Gender = "Male",
                            Name = "ნიკოლოზ",
                            PhoneNumber = "2123456",
                            Pid = "01001000003",
                            Surname = "გიგაური",
                            TypeOfPhone = "HousePhone"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 4,
                            DateOfPBirth = new DateOnly(1999, 3, 14),
                            Gender = "Female",
                            Name = "ანა",
                            PhoneNumber = "322456789",
                            Pid = "01001000004",
                            Surname = "დავითაშვილი",
                            TypeOfPhone = "OfficePhone"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 5,
                            DateOfPBirth = new DateOnly(1985, 8, 25),
                            Gender = "Male",
                            Name = "დათო",
                            PhoneNumber = "555987654",
                            Pid = "01001000005",
                            Surname = "ელიზბარაშვილი",
                            TypeOfPhone = "Mobile"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 6,
                            DateOfPBirth = new DateOnly(1998, 2, 24),
                            Gender = "Female",
                            Name = "თეკლა",
                            PhoneNumber = "2323232",
                            Pid = "01001000006",
                            Surname = "ვანიშვილი",
                            TypeOfPhone = "HousePhone"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 7,
                            DateOfPBirth = new DateOnly(1985, 8, 25),
                            Gender = "Male",
                            Name = "ლუკა",
                            PhoneNumber = "344556677",
                            Pid = "01001000007",
                            Surname = "ზარანდია",
                            TypeOfPhone = "OfficePhone"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 8,
                            DateOfPBirth = new DateOnly(1985, 8, 25),
                            Gender = "Female",
                            Name = "ელენე",
                            PhoneNumber = "591112233",
                            Pid = "01001000008",
                            Surname = "თორდია",
                            TypeOfPhone = "Mobile"
                        },
                        new
                        {
                            Id = 9,
                            CityId = 9,
                            DateOfPBirth = new DateOnly(1985, 8, 25),
                            Gender = "Male",
                            Name = "გიორგი",
                            PhoneNumber = "2667788",
                            Pid = "01001000009",
                            Surname = "კახიძე",
                            TypeOfPhone = "HousePhone"
                        },
                        new
                        {
                            Id = 10,
                            CityId = 10,
                            DateOfPBirth = new DateOnly(1985, 8, 25),
                            Gender = "Female",
                            Name = "ნინო",
                            PhoneNumber = "355667788",
                            Pid = "01001000010",
                            Surname = "ლომიძე",
                            TypeOfPhone = "OfficePhone"
                        });
                });

            modelBuilder.Entity("PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity.RelatedPerson", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedPersonId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("RelationType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PersonId", "RelatedPersonId");

                    b.HasIndex("RelatedPersonId");

                    b.ToTable("RelatedPersons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            RelatedPersonId = 2,
                            Id = 1,
                            RelationType = "Colleague"
                        },
                        new
                        {
                            PersonId = 3,
                            RelatedPersonId = 4,
                            Id = 2,
                            RelationType = "Familiar"
                        },
                        new
                        {
                            PersonId = 5,
                            RelatedPersonId = 6,
                            Id = 3,
                            RelationType = "Other"
                        },
                        new
                        {
                            PersonId = 7,
                            RelatedPersonId = 8,
                            Id = 4,
                            RelationType = "Other"
                        },
                        new
                        {
                            PersonId = 9,
                            RelatedPersonId = 10,
                            Id = 5,
                            RelationType = "Other"
                        });
                });

            modelBuilder.Entity("PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity.Person", b =>
                {
                    b.HasOne("PhysicalPersonDirectory.Core.Domain.Entities.City", "City")
                        .WithOne("Person")
                        .HasForeignKey("PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity.Person", "CityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("City");
                });

            modelBuilder.Entity("PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity.RelatedPerson", b =>
                {
                    b.HasOne("PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity.Person", "Person")
                        .WithMany("RelatedPersons")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity.Person", "Related")
                        .WithMany("RelatedToPersons")
                        .HasForeignKey("RelatedPersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Related");
                });

            modelBuilder.Entity("PhysicalPersonDirectory.Core.Domain.Entities.City", b =>
                {
                    b.Navigation("Person")
                        .IsRequired();
                });

            modelBuilder.Entity("PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity.Person", b =>
                {
                    b.Navigation("RelatedPersons");

                    b.Navigation("RelatedToPersons");
                });
#pragma warning restore 612, 618
        }
    }
}
