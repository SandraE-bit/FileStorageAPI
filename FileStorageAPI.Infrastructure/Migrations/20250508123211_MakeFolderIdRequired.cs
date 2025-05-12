using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileStorageAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeFolderIdRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "FolderId",
                table: "Files",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
