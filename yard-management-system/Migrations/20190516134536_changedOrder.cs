using Microsoft.EntityFrameworkCore.Migrations;

namespace yard_management_system.Migrations
{
    public partial class changedOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "ObjectChanges");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "ObjectChanges",
                nullable: true);
        }
    }
}
