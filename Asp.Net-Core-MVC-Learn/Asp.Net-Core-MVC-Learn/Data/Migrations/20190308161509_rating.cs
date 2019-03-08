using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Net_Core_MVC_Learn.Data.Migrations
{
    public partial class rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptmentId",
                table: "Account",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Deptment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deptment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_DeptmentId",
                table: "Account",
                column: "DeptmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Deptment_DeptmentId",
                table: "Account",
                column: "DeptmentId",
                principalTable: "Deptment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Deptment_DeptmentId",
                table: "Account");

            migrationBuilder.DropTable(
                name: "Deptment");

            migrationBuilder.DropIndex(
                name: "IX_Account_DeptmentId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "DeptmentId",
                table: "Account");
        }
    }
}
