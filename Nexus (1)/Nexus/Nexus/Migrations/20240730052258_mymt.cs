using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexus.Migrations
{
    /// <inheritdoc />
    public partial class mymt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_adminsrecords",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    status_updates = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_adminsrecords", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_contact",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_msg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_contact", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_faq",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faq_sub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faq_ques = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faq_ans = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_faq", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_feedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    massage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_feedback", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Charges = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    status_update = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_retail_stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_retail_stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_schemes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    schemesname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    schemescount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    schemesDes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    percentage = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_schemes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Users",
                columns: table => new
                {
                    user_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_Status = table.Column<int>(type: "int", nullable: false),
                    status_updates = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Users", x => x.user_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_vendors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vendor_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vendor_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vendor_number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_vendors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    status_update = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_employees_tbl_positions_Position_id",
                        column: x => x.Position_id,
                        principalTable: "tbl_positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Vendor_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_products_tbl_vendors_Vendor_Id",
                        column: x => x.Vendor_Id,
                        principalTable: "tbl_vendors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bookedplans",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plan_Id = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    GetDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bookedplans", x => x.Order_Id);
                    table.ForeignKey(
                        name: "FK_tbl_bookedplans_tbl_plans_Plan_Id",
                        column: x => x.Plan_Id,
                        principalTable: "tbl_plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_bookedplans_tbl_products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "tbl_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bookedschemes",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scheme_Id = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    GetDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bookedschemes", x => x.Order_Id);
                    table.ForeignKey(
                        name: "FK_tbl_bookedschemes_tbl_products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "tbl_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_bookedschemes_tbl_schemes_Scheme_Id",
                        column: x => x.Scheme_Id,
                        principalTable: "tbl_schemes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_plansubcribed",
                columns: table => new
                {
                    addtocartid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plan_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentofmode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    charges = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    status_updates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenerateBillstatus = table.Column<int>(type: "int", nullable: false),
                    GenerateBillstatus_update = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeasibilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    account_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    ordered_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    products_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_plansubcribed", x => x.addtocartid);
                    table.ForeignKey(
                        name: "FK_tbl_plansubcribed_tbl_products_products_id",
                        column: x => x.products_id,
                        principalTable: "tbl_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_schemesubcribed",
                columns: table => new
                {
                    addtocartid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plan_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentofmode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    charges = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: false),
                    GetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    status_updates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenerateBillstatus = table.Column<int>(type: "int", nullable: false),
                    GenerateBillstatus_update = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeasibilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    account_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_schemesubcribed", x => x.addtocartid);
                    table.ForeignKey(
                        name: "FK_tbl_schemesubcribed_tbl_products_product_id",
                        column: x => x.product_id,
                        principalTable: "tbl_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bookedplans_Plan_Id",
                table: "tbl_bookedplans",
                column: "Plan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bookedplans_Product_ID",
                table: "tbl_bookedplans",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bookedschemes_Product_ID",
                table: "tbl_bookedschemes",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bookedschemes_Scheme_Id",
                table: "tbl_bookedschemes",
                column: "Scheme_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_employees_Position_id",
                table: "tbl_employees",
                column: "Position_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_plansubcribed_products_id",
                table: "tbl_plansubcribed",
                column: "products_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_products_Vendor_Id",
                table: "tbl_products",
                column: "Vendor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_schemesubcribed_product_id",
                table: "tbl_schemesubcribed",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_adminsrecords");

            migrationBuilder.DropTable(
                name: "tbl_bookedplans");

            migrationBuilder.DropTable(
                name: "tbl_bookedschemes");

            migrationBuilder.DropTable(
                name: "tbl_contact");

            migrationBuilder.DropTable(
                name: "tbl_employees");

            migrationBuilder.DropTable(
                name: "tbl_faq");

            migrationBuilder.DropTable(
                name: "tbl_feedback");

            migrationBuilder.DropTable(
                name: "tbl_plansubcribed");

            migrationBuilder.DropTable(
                name: "tbl_retail_stores");

            migrationBuilder.DropTable(
                name: "tbl_schemesubcribed");

            migrationBuilder.DropTable(
                name: "tbl_Users");

            migrationBuilder.DropTable(
                name: "tbl_plans");

            migrationBuilder.DropTable(
                name: "tbl_schemes");

            migrationBuilder.DropTable(
                name: "tbl_positions");

            migrationBuilder.DropTable(
                name: "tbl_products");

            migrationBuilder.DropTable(
                name: "tbl_vendors");
        }
    }
}
