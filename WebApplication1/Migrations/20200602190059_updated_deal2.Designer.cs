﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(WebApplication1Context))]
    [Migration("20200602190059_updated_deal2")]
    partial class updated_deal2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("WebApplication1.Models.Company", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Addressid")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Addressid");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("WebApplication1.Models.Day", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CloseTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpenTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResturauntPageid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ResturauntPageid");

                    b.ToTable("Day");
                });

            modelBuilder.Entity("WebApplication1.Models.Deal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Dayid")
                        .HasColumnType("int");

                    b.Property<string>("Desription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Dayid");

                    b.ToTable("Deal");
                });

            modelBuilder.Entity("WebApplication1.Models.Image", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageVal")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("WebApplication1.Models.Location", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Lang")
                        .HasColumnType("float");

                    b.Property<double>("Long")
                        .HasColumnType("float");

                    b.Property<int>("ResturauntId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ResturauntId")
                        .IsUnique();

                    b.ToTable("Location");
                });

            modelBuilder.Entity("WebApplication1.Models.Resturaunt", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Addressid")
                        .HasColumnType("int");

                    b.Property<int?>("Companyid")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResturauntPageid")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Addressid");

                    b.HasIndex("Companyid");

                    b.HasIndex("ResturauntPageid");

                    b.ToTable("Resturaunt");
                });

            modelBuilder.Entity("WebApplication1.Models.ResturauntPage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Imageid")
                        .HasColumnType("int");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yelp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Youtube")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Imageid");

                    b.ToTable("ResturauntPage");
                });

            modelBuilder.Entity("WebApplication1.Models.Tags", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Catagory")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("WebApplication1.Models.TagsInter", b =>
                {
                    b.Property<int>("DealID")
                        .HasColumnType("int");

                    b.Property<int>("TagID")
                        .HasColumnType("int");

                    b.HasKey("DealID", "TagID");

                    b.HasIndex("TagID");

                    b.ToTable("TagsInter");
                });

            modelBuilder.Entity("WebApplication1.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Companyid")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Companyid");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApplication1.Models.Company", b =>
                {
                    b.HasOne("WebApplication1.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("Addressid");
                });

            modelBuilder.Entity("WebApplication1.Models.Day", b =>
                {
                    b.HasOne("WebApplication1.Models.ResturauntPage", null)
                        .WithMany("Days")
                        .HasForeignKey("ResturauntPageid");
                });

            modelBuilder.Entity("WebApplication1.Models.Deal", b =>
                {
                    b.HasOne("WebApplication1.Models.Day", null)
                        .WithMany("Deals")
                        .HasForeignKey("Dayid");
                });

            modelBuilder.Entity("WebApplication1.Models.Location", b =>
                {
                    b.HasOne("WebApplication1.Models.Resturaunt", null)
                        .WithOne("Location")
                        .HasForeignKey("WebApplication1.Models.Location", "ResturauntId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Resturaunt", b =>
                {
                    b.HasOne("WebApplication1.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("Addressid");

                    b.HasOne("WebApplication1.Models.Company", null)
                        .WithMany("Resturaunts")
                        .HasForeignKey("Companyid");

                    b.HasOne("WebApplication1.Models.ResturauntPage", "ResturauntPage")
                        .WithMany()
                        .HasForeignKey("ResturauntPageid");
                });

            modelBuilder.Entity("WebApplication1.Models.ResturauntPage", b =>
                {
                    b.HasOne("WebApplication1.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("Imageid");
                });

            modelBuilder.Entity("WebApplication1.Models.TagsInter", b =>
                {
                    b.HasOne("WebApplication1.Models.Deal", "Deal")
                        .WithMany("TagsInter")
                        .HasForeignKey("DealID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Tags", "Tag")
                        .WithMany("TagsInter")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.User", b =>
                {
                    b.HasOne("WebApplication1.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("Companyid");
                });
#pragma warning restore 612, 618
        }
    }
}
