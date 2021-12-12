using Microsoft.EntityFrameworkCore.Migrations;

namespace KafeAdisyon.Migrations
{
    public partial class SiparisUpdateColoumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GetSiparisId",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GetSiparisId",
                table: "Siparisler");
        }
    }
}
