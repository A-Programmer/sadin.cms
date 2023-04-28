﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sadin.Cms.Persistence;

#nullable disable

namespace Sadin.Cms.Persistence.Migrations
{
    [DbContext(typeof(CmsDbContext))]
    [Migration("20230428123652_ContactMessages_Add")]
    partial class ContactMessages_Add
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sadin.Cms.Domain.Aggregates.ContactUs.ContactMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("ContactMessages", (string)null);
                });

            modelBuilder.Entity("Sadin.Cms.Domain.Aggregates.ContactUs.ContactMessage", b =>
                {
                    b.OwnsOne("Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects.Content", "Content", b1 =>
                        {
                            b1.Property<Guid>("ContactMessageId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("ContactMessageId");

                            b1.ToTable("ContactMessages");

                            b1.WithOwner()
                                .HasForeignKey("ContactMessageId");
                        });

                    b.OwnsOne("Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ContactMessageId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("ContactMessageId");

                            b1.ToTable("ContactMessages");

                            b1.WithOwner()
                                .HasForeignKey("ContactMessageId");
                        });

                    b.OwnsOne("Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("ContactMessageId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("ContactMessageId");

                            b1.ToTable("ContactMessages");

                            b1.WithOwner()
                                .HasForeignKey("ContactMessageId");
                        });

                    b.OwnsOne("Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("ContactMessageId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("ContactMessageId");

                            b1.ToTable("ContactMessages");

                            b1.WithOwner()
                                .HasForeignKey("ContactMessageId");
                        });

                    b.OwnsOne("Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects.Subject", "Subject", b1 =>
                        {
                            b1.Property<Guid>("ContactMessageId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("ContactMessageId");

                            b1.ToTable("ContactMessages");

                            b1.WithOwner()
                                .HasForeignKey("ContactMessageId");
                        });

                    b.Navigation("Content")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("FullName")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();

                    b.Navigation("Subject")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}