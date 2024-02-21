using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_cpmment_appuser_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "CommentS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CommentS_AppUserID",
                table: "CommentS",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentS_AspNetUsers_AppUserID",
                table: "CommentS",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentS_AspNetUsers_AppUserID",
                table: "CommentS");

            migrationBuilder.DropIndex(
                name: "IX_CommentS_AppUserID",
                table: "CommentS");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "CommentS");
        }
    }
}
