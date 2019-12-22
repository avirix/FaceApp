using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceDetector.Domain.Migrations
{
    public partial class ImageStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faces_BaseUser_CreatedId",
                table: "Faces");

            migrationBuilder.DropForeignKey(
                name: "FK_Faces_BaseUser_UpdatedId",
                table: "Faces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faces",
                table: "Faces");

            migrationBuilder.RenameTable(
                name: "Faces",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_Faces_UpdatedId",
                table: "Images",
                newName: "IX_Images_UpdatedId");

            migrationBuilder.RenameIndex(
                name: "IX_Faces_CreatedId",
                table: "Images",
                newName: "IX_Images_CreatedId");

            migrationBuilder.AddColumn<Guid>(
                name: "FolderId",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "KeepPublic",
                table: "Images",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Images",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedId = table.Column<Guid>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    UpdatedId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    FolderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_BaseUser_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Folders_BaseUser_UpdatedId",
                        column: x => x.UpdatedId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Folders_BaseUser_UserId",
                        column: x => x.UserId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_FolderId",
                table: "Images",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_CreatedId",
                table: "Folders",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_UpdatedId",
                table: "Folders",
                column: "UpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_UserId",
                table: "Folders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_BaseUser_CreatedId",
                table: "Images",
                column: "CreatedId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Folders_FolderId",
                table: "Images",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_BaseUser_UpdatedId",
                table: "Images",
                column: "UpdatedId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_BaseUser_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_BaseUser_CreatedId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Folders_FolderId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_BaseUser_UpdatedId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_BaseUser_UserId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_FolderId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_UserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "KeepPublic",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Faces");

            migrationBuilder.RenameIndex(
                name: "IX_Images_UpdatedId",
                table: "Faces",
                newName: "IX_Faces_UpdatedId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_CreatedId",
                table: "Faces",
                newName: "IX_Faces_CreatedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faces",
                table: "Faces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faces_BaseUser_CreatedId",
                table: "Faces",
                column: "CreatedId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faces_BaseUser_UpdatedId",
                table: "Faces",
                column: "UpdatedId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
