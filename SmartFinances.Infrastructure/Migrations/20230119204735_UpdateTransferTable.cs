using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class UpdateTransferTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Transfers");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverAccountNumber",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverAccountNumber",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "Transfers");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
