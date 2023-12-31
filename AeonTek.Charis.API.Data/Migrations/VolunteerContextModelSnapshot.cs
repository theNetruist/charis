﻿// <auto-generated />
using System;
using AeonTek.Charis.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AeonTek.Charis.API.Migrations
{
    [DbContext(typeof(OrganizationContext))]
    partial class VolunteerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("AeonTek.Charis.API.Data.ValueObjects.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("AllowText")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("VolunteerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VolunteerId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("AeonTek.Charis.API.Data.ValueObjects.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("AeonTek.Charis.API.Data.ValueObjects.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("AeonTek.Charis.API.Data.ValueObjects.Waiver", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("SignedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Version")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("VolunteerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VolunteerId");

                    b.ToTable("Waiver");
                });

            modelBuilder.Entity("AeonTek.Charis.API.Data.ValueObjects.WaiverTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("MarkDown")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Version")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("WaiverTemplate");
                });

            modelBuilder.Entity("AeonTek.Charis.API.Data.ValueObjects.Contact", b =>
                {
                    b.HasOne("AeonTek.Charis.API.Data.ValueObjects.Volunteer", null)
                        .WithMany("Contacts")
                        .HasForeignKey("VolunteerId");
                });

            modelBuilder.Entity("AeonTek.Charis.API.Data.ValueObjects.Volunteer", b =>
                {
                    b.HasOne("AeonTek.Charis.API.Data.ValueObjects.Organization", null)
                        .WithMany("Volunteers")
                        .HasForeignKey("OrganizationId");
                });

            modelBuilder.Entity("AeonTek.Charis.API.Data.ValueObjects.Waiver", b =>
                {
                    b.HasOne("AeonTek.Charis.API.Data.ValueObjects.Volunteer", null)
                        .WithMany("Waivers")
                        .HasForeignKey("VolunteerId");
                });

            modelBuilder.Entity("AeonTek.Charis.API.Data.ValueObjects.WaiverTemplate", b =>
                {
                    b.HasOne("AeonTek.Charis.API.Data.ValueObjects.Organization", null)
                        .WithMany("WaiverTemplates")
                        .HasForeignKey("OrganizationId");
                });

            modelBuilder.Entity("AeonTek.Charis.API.Data.ValueObjects.Organization", b =>
                {
                    b.Navigation("Volunteers");

                    b.Navigation("WaiverTemplates");
                });

            modelBuilder.Entity("AeonTek.Charis.API.Data.ValueObjects.Volunteer", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Waivers");
                });
#pragma warning restore 612, 618
        }
    }
}
