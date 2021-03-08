using Microsoft.EntityFrameworkCore.Migrations;

namespace Arfitect.Training.PilotPeer.Migrations
{
    public partial class nameadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PeerName",
                table: "SupportRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeerName",
                table: "SupportRequests");
        }
    }
}
