using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DB.Migrations
{
    /// <inheritdoc />
    public partial class editeModleOrderss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBooks_Books_BookId",
                table: "UserBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBooks_Users_UserId",
                table: "UserBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBooks",
                table: "UserBooks");

            migrationBuilder.RenameTable(
                name: "UserBooks",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_UserBooks_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBooks_BookId",
                table: "Orders",
                newName: "IX_Orders_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Books_BookId",
                table: "Orders",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Books_BookId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "UserBooks");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "UserBooks",
                newName: "IX_UserBooks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BookId",
                table: "UserBooks",
                newName: "IX_UserBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBooks",
                table: "UserBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBooks_Books_BookId",
                table: "UserBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBooks_Users_UserId",
                table: "UserBooks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
