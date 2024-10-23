using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task1.Migrations
{
    /// <inheritdoc />
    public partial class addedleavesmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalHoursWorked = table.Column<int>(type: "int", nullable: true),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllowedLeaves = table.Column<int>(type: "int", nullable: true),
                    LeaveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salarys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NetSalary = table.Column<int>(type: "int", nullable: false),
                    Allowances = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salarys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Roles" },
                values: new object[,]
                {
                    { new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537"), "ali@gmail.com", "ali", "1234567890", "employee" },
                    { new Guid("89b876cc-a901-4467-bb50-1a23389805af"), "nomi@gmail.com", "nomi", "1234567890", "employee" },
                    { new Guid("c1415027-e627-4956-bf7b-d43e23feec06"), "gcch@gmail.com", "Ghufran", "1234567890", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "Id", "AttendanceDate", "AttendanceStatus", "CheckInTime", "CheckOutTime", "TotalHoursWorked", "UserId" },
                values: new object[,]
                {
                    { new Guid("29f73ba9-a5d3-4280-9580-0f3e4f9aac06"), new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Present", new DateTime(2023, 6, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 17, 16, 0, 0, 0, DateTimeKind.Unspecified), 7, new Guid("89b876cc-a901-4467-bb50-1a23389805af") },
                    { new Guid("2f2763d3-a4d4-4d8b-b199-800882a1c601"), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Late", new DateTime(2023, 6, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), 6, new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537") },
                    { new Guid("39fcf329-d915-4c75-ab57-1cd4c1270788"), new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Late", new DateTime(2023, 6, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), 7, new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537") },
                    { new Guid("d41cd31c-3fef-4c3c-9ebb-020a6c2dc256"), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Present", new DateTime(2023, 6, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), 8, new Guid("89b876cc-a901-4467-bb50-1a23389805af") }
                });

            migrationBuilder.InsertData(
                table: "Leaves",
                columns: new[] { "Id", "AllowedLeaves", "LeaveStatus", "Reason", "UserId" },
                values: new object[,]
                {
                    { new Guid("2ca6bfc2-4fa5-4e59-81d9-e52acaca096a"), 5, "Pending", "fever", new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537") },
                    { new Guid("36127359-6b07-4a62-a3a0-2d96581321e1"), 5, "Approved", "fever", new Guid("89b876cc-a901-4467-bb50-1a23389805af") },
                    { new Guid("9c3f9bf9-3680-4c5a-a3d4-bd1969dec093"), 5, "disApproved", "fever", new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537") }
                });

            migrationBuilder.InsertData(
                table: "Salarys",
                columns: new[] { "Id", "Allowances", "NetSalary", "PayMethod", "UserId" },
                values: new object[,]
                {
                    { new Guid("2ca6bfc2-4fa5-4e59-81d9-e52acaca096a"), "Bonus incentives", 50000, "cash by Hand", new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537") },
                    { new Guid("36127359-6b07-4a62-a3a0-2d96581321e1"), "Petrol incentives", 20000, "cash by Hand", new Guid("89b876cc-a901-4467-bb50-1a23389805af") },
                    { new Guid("9c3f9bf9-3680-4c5a-a3d4-bd1969dec093"), "Petrol incentives", 30000, "credit card", new Guid("3f470b47-eab2-4eca-a78c-44f1b62c1537") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_UserId",
                table: "Attendances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_UserId",
                table: "Leaves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Salarys_UserId",
                table: "Salarys",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "Salarys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
