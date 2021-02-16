using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightSearch.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrives = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "49f73cd8-2767-4dfb-bb4c-4604bff1b83b", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAENE3qyyE1DNg0S/H9gHBhgCRGjKBBlh7VxO6VK9p6P4ZloMi+vHPUoLI6BMAeLcntA==", null, false, "92ca7992-9e82-4860-8c7a-1ead52c59740", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "ID", "Arrives", "Departs", "Destination", "Origin", "Price" },
                values: new object[,]
                {
                    { 21, new DateTime(2014, 6, 19, 12, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 19, 6, 30, 0, 0, DateTimeKind.Unspecified), "BOS", "LHR", 1243.00m },
                    { 20, new DateTime(2014, 6, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 15, 7, 0, 0, 0, DateTimeKind.Unspecified), "YVR", "YYZ", 647.00m },
                    { 19, new DateTime(2014, 6, 21, 15, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 21, 8, 55, 0, 0, DateTimeKind.Unspecified), "YYC", "LAX", 577.00m },
                    { 18, new DateTime(2014, 6, 16, 19, 28, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 16, 8, 11, 0, 0, DateTimeKind.Unspecified), "YYZ", "LAS", 703.00m },
                    { 17, new DateTime(2014, 6, 24, 2, 22, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 23, 22, 10, 0, 0, DateTimeKind.Unspecified), "YYZ", "YVR", 1151.00m },
                    { 16, new DateTime(2014, 6, 23, 21, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 23, 19, 40, 0, 0, DateTimeKind.Unspecified), "ORD", "MIA", 532.00m },
                    { 15, new DateTime(2014, 6, 23, 14, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 23, 12, 40, 0, 0, DateTimeKind.Unspecified), "YYZ", "YYC", 541.00m },
                    { 14, new DateTime(2014, 6, 19, 17, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 19, 11, 0, 0, 0, DateTimeKind.Unspecified), "YYC", "LAX", 543.00m },
                    { 13, new DateTime(2014, 6, 26, 14, 9, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), "YYC", "YYZ", 630.00m },
                    { 12, new DateTime(2014, 6, 19, 10, 58, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 19, 5, 55, 0, 0, DateTimeKind.Unspecified), "YUL", "MSY", 480.00m },
                    { 10, new DateTime(2014, 6, 22, 21, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 22, 9, 45, 0, 0, DateTimeKind.Unspecified), "YYZ", "LAS", 549.00m },
                    { 9, new DateTime(2014, 6, 21, 23, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 21, 17, 55, 0, 0, DateTimeKind.Unspecified), "YEG", "JFK", 589.00m },
                    { 8, new DateTime(2014, 6, 20, 12, 36, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 20, 7, 45, 0, 0, DateTimeKind.Unspecified), "ORD", "MIA", 422.00m },
                    { 7, new DateTime(2014, 6, 19, 12, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 19, 8, 45, 0, 0, DateTimeKind.Unspecified), "YYC", "LAX", 356.00m },
                    { 6, new DateTime(2014, 6, 18, 19, 47, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 18, 9, 10, 0, 0, DateTimeKind.Unspecified), "YYZ", "YVR", 1093.00m },
                    { 5, new DateTime(2014, 6, 21, 17, 6, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 21, 11, 5, 0, 0, DateTimeKind.Unspecified), "BOS", "LHR", 975.00m },
                    { 4, new DateTime(2014, 6, 12, 11, 24, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), "YVR", "YYC", 379.00m },
                    { 3, new DateTime(2014, 6, 23, 21, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 23, 19, 40, 0, 0, DateTimeKind.Unspecified), "ORD", "MIA", 532.00m },
                    { 2, new DateTime(2014, 6, 15, 8, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 15, 6, 45, 0, 0, DateTimeKind.Unspecified), "YYC", "YYZ", 578.00m },
                    { 11, new DateTime(2014, 6, 23, 15, 22, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 23, 9, 20, 0, 0, DateTimeKind.Unspecified), "YYZ", "YVR", 1122.00m },
                    { 1, new DateTime(2014, 6, 23, 14, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 23, 13, 30, 0, 0, DateTimeKind.Unspecified), "LAX", "LAS", 151.00m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
