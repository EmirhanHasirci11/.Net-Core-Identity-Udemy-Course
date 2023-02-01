using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityUdemyCourse.Migrations
{
    public partial class _User_TwoFactorColumn_Added_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "TwoFactor",
                table: "AspNetUsers",
                type: "smallint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwoFactor",
                table: "AspNetUsers");
        }
    }
}
