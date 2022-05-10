using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagementApp.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Texas" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "California" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "PostalCode", "StateId", "SupplierName" },
                values: new object[] { 1, "Dhaka 1", "Dhaka 2", "Dhaka", "1230", 1, "Beximco" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "PostalCode", "StateId", "SupplierName" },
                values: new object[] { 2, "Chaitagong 1", "Chaitagong 2", "Chaitagong", "1250", 2, "Square" });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_StateId",
                table: "Suppliers",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
