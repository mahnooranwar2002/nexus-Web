﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nexus.Models;

#nullable disable

namespace Nexus.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240730052258_mymt")]
    partial class mymt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nexus.Models.Admin", b =>
                {
                    b.Property<int>("admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("admin_id"));

                    b.Property<string>("admin_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("status_updates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("admin_id");

                    b.ToTable("tbl_adminsrecords");
                });

            modelBuilder.Entity("Nexus.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Vendor_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Vendor_Id");

                    b.ToTable("tbl_products");
                });

            modelBuilder.Entity("Nexus.Models.contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("user_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_msg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tbl_contact");
                });

            modelBuilder.Entity("Nexus.Models.employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("Position_id")
                        .HasColumnType("int");

                    b.Property<string>("User_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("status_update")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Position_id");

                    b.ToTable("tbl_employees");
                });

            modelBuilder.Entity("Nexus.Models.faq", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("faq_ans")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("faq_ques")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("faq_sub")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tbl_faq");
                });

            modelBuilder.Entity("Nexus.Models.feedback", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("massage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tbl_feedback");
                });

            modelBuilder.Entity("Nexus.Models.plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Charges")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("status_update")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_plans");
                });

            modelBuilder.Entity("Nexus.Models.planOutlet", b =>
                {
                    b.Property<int>("Order_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("Plan_Id")
                        .HasColumnType("int");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.HasKey("Order_Id");

                    b.HasIndex("Plan_Id");

                    b.HasIndex("Product_ID");

                    b.ToTable("tbl_bookedplans");
                });

            modelBuilder.Entity("Nexus.Models.plansubcribed", b =>
                {
                    b.Property<int>("addtocartid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("addtocartid"));

                    b.Property<string>("FeasibilityStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenerateBillstatus")
                        .HasColumnType("int");

                    b.Property<string>("GenerateBillstatus_update")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("account_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("charges")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("order_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ordered_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("payment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentofmode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pincode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("plan_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("products_id")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("status_updates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("addtocartid");

                    b.HasIndex("products_id");

                    b.ToTable("tbl_plansubcribed");
                });

            modelBuilder.Entity("Nexus.Models.positions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_positions");
                });

            modelBuilder.Entity("Nexus.Models.retailshop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Contact")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_retail_stores");
                });

            modelBuilder.Entity("Nexus.Models.scheme", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("discount")
                        .HasColumnType("int");

                    b.Property<int>("percentage")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("schemesDes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("schemescount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("schemesname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tbl_schemes");
                });

            modelBuilder.Entity("Nexus.Models.schemesOutlet", b =>
                {
                    b.Property<int>("Order_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.Property<int>("Scheme_Id")
                        .HasColumnType("int");

                    b.HasKey("Order_Id");

                    b.HasIndex("Product_ID");

                    b.HasIndex("Scheme_Id");

                    b.ToTable("tbl_bookedschemes");
                });

            modelBuilder.Entity("Nexus.Models.schemesubcribed", b =>
                {
                    b.Property<int>("addtocartid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("addtocartid"));

                    b.Property<string>("FeasibilityStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenerateBillstatus")
                        .HasColumnType("int");

                    b.Property<string>("GenerateBillstatus_update")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("account_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("charges")
                        .HasColumnType("int");

                    b.Property<string>("contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("discount")
                        .HasColumnType("int");

                    b.Property<string>("order_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("payment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentofmode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pincode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("plan_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("status_updates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("addtocartid");

                    b.HasIndex("product_id");

                    b.ToTable("tbl_schemesubcribed");
                });

            modelBuilder.Entity("Nexus.Models.user", b =>
                {
                    b.Property<int>("user_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_Id"));

                    b.Property<string>("status_updates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_Status")
                        .HasColumnType("int");

                    b.HasKey("user_Id");

                    b.ToTable("tbl_Users");
                });

            modelBuilder.Entity("Nexus.Models.vendor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("vendor_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vendor_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vendor_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tbl_vendors");
                });

            modelBuilder.Entity("Nexus.Models.Products", b =>
                {
                    b.HasOne("Nexus.Models.vendor", "vendors")
                        .WithMany("products")
                        .HasForeignKey("Vendor_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("vendors");
                });

            modelBuilder.Entity("Nexus.Models.employee", b =>
                {
                    b.HasOne("Nexus.Models.positions", "positions")
                        .WithMany("employees")
                        .HasForeignKey("Position_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("positions");
                });

            modelBuilder.Entity("Nexus.Models.planOutlet", b =>
                {
                    b.HasOne("Nexus.Models.plan", "plans")
                        .WithMany("plandetails")
                        .HasForeignKey("Plan_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nexus.Models.Products", "product")
                        .WithMany("productDetail")
                        .HasForeignKey("Product_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plans");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Nexus.Models.plansubcribed", b =>
                {
                    b.HasOne("Nexus.Models.Products", "productdetails")
                        .WithMany("planSubdetails")
                        .HasForeignKey("products_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productdetails");
                });

            modelBuilder.Entity("Nexus.Models.schemesOutlet", b =>
                {
                    b.HasOne("Nexus.Models.Products", "product")
                        .WithMany("SchemesOutlets")
                        .HasForeignKey("Product_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nexus.Models.scheme", "schemes")
                        .WithMany("schmesdata")
                        .HasForeignKey("Scheme_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("schemes");
                });

            modelBuilder.Entity("Nexus.Models.schemesubcribed", b =>
                {
                    b.HasOne("Nexus.Models.Products", "product")
                        .WithMany("schemesDetails")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("Nexus.Models.Products", b =>
                {
                    b.Navigation("SchemesOutlets");

                    b.Navigation("planSubdetails");

                    b.Navigation("productDetail");

                    b.Navigation("schemesDetails");
                });

            modelBuilder.Entity("Nexus.Models.plan", b =>
                {
                    b.Navigation("plandetails");
                });

            modelBuilder.Entity("Nexus.Models.positions", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("Nexus.Models.scheme", b =>
                {
                    b.Navigation("schmesdata");
                });

            modelBuilder.Entity("Nexus.Models.vendor", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
