using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API1.Migrations
{
    public partial class fkmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoresStoreId",
                table: "clothess",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.StoreId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clothess_StoresStoreId",
                table: "clothess",
                column: "StoresStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_clothess_stores_StoresStoreId",
                table: "clothess",
                column: "StoresStoreId",
                principalTable: "stores",
                principalColumn: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clothess_stores_StoresStoreId",
                table: "clothess");

            migrationBuilder.DropTable(
                name: "stores");

            migrationBuilder.DropIndex(
                name: "IX_clothess_StoresStoreId",
                table: "clothess");

            migrationBuilder.DropColumn(
                name: "StoresStoreId",
                table: "clothess");
        }
    }
}
