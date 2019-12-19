using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaceDetector.Domain.Migrations
{
    public partial class AddFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageFolderId",
                table: "Faces",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FaceDetecteds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedId = table.Column<Guid>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    UpdatedId = table.Column<Guid>(nullable: true),
                    ImageId = table.Column<Guid>(nullable: false),
                    DetectedOptions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceDetecteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaceDetecteds_BaseUser_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceDetecteds_Faces_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Faces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaceDetecteds_BaseUser_UpdatedId",
                        column: x => x.UpdatedId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gallerys",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedId = table.Column<Guid>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    UpdatedId = table.Column<Guid>(nullable: true),
                    GalleryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallerys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gallerys_BaseUser_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gallerys_BaseUser_UpdatedId",
                        column: x => x.UpdatedId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedId = table.Column<Guid>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    UpdatedId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_BaseUser_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_BaseUser_UpdatedId",
                        column: x => x.UpdatedId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_BaseUser_UserId",
                        column: x => x.UserId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageFolders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedId = table.Column<Guid>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    UpdatedId = table.Column<Guid>(nullable: true),
                    FolderName = table.Column<string>(nullable: true),
                    GalleryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFolders_BaseUser_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageFolders_Gallerys_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Gallerys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageFolders_BaseUser_UpdatedId",
                        column: x => x.UpdatedId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FolderUserProfile",
                columns: table => new
                {
                    FolderId = table.Column<Guid>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderUserProfile", x => new { x.FolderId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_FolderUserProfile_UserProfiles_FolderId",
                        column: x => x.FolderId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FolderUserProfile_ImageFolders_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ImageFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faces_ImageFolderId",
                table: "Faces",
                column: "ImageFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceDetecteds_CreatedId",
                table: "FaceDetecteds",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceDetecteds_ImageId",
                table: "FaceDetecteds",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceDetecteds_UpdatedId",
                table: "FaceDetecteds",
                column: "UpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderUserProfile_ProfileId",
                table: "FolderUserProfile",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Gallerys_CreatedId",
                table: "Gallerys",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Gallerys_UpdatedId",
                table: "Gallerys",
                column: "UpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFolders_CreatedId",
                table: "ImageFolders",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFolders_GalleryId",
                table: "ImageFolders",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFolders_UpdatedId",
                table: "ImageFolders",
                column: "UpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CreatedId",
                table: "UserProfiles",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UpdatedId",
                table: "UserProfiles",
                column: "UpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faces_ImageFolders_ImageFolderId",
                table: "Faces",
                column: "ImageFolderId",
                principalTable: "ImageFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faces_ImageFolders_ImageFolderId",
                table: "Faces");

            migrationBuilder.DropTable(
                name: "FaceDetecteds");

            migrationBuilder.DropTable(
                name: "FolderUserProfile");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "ImageFolders");

            migrationBuilder.DropTable(
                name: "Gallerys");

            migrationBuilder.DropIndex(
                name: "IX_Faces_ImageFolderId",
                table: "Faces");

            migrationBuilder.DropColumn(
                name: "ImageFolderId",
                table: "Faces");
        }
    }
}
