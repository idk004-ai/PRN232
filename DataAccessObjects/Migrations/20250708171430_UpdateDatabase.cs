using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessObjects.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblMajors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMajors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTopics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NeedReview = table.Column<bool>(type: "bit", nullable: false),
                    Panner = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblRoleClaims_tblRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tblRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMajorTopics",
                columns: table => new
                {
                    MajorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMajorTopics", x => new { x.MajorsId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_tblMajorTopics_tblMajors_MajorsId",
                        column: x => x.MajorsId,
                        principalTable: "tblMajors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblMajorTopics_tblTopics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "tblTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblFeeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreaterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblFeeds_tblUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "tblUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblModerators",
                columns: table => new
                {
                    ModeratedByUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModeratedTopicsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblModerators", x => new { x.ModeratedByUsersId, x.ModeratedTopicsId });
                    table.ForeignKey(
                        name: "FK_tblModerators_tblTopics_ModeratedTopicsId",
                        column: x => x.ModeratedTopicsId,
                        principalTable: "tblTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblModerators_tblUsers_ModeratedByUsersId",
                        column: x => x.ModeratedByUsersId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblNotifications_tblUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreaterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPosts_tblTopics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "tblTopics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblPosts_tblUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "tblUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Banner = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MajorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProfiles_tblMajors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "tblMajors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblProfiles_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    ResponseContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreaterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblReports_tblUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblTopicBans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BannedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTopicBans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTopicBans_tblTopics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "tblTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblTopicBans_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblUserClaims_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_tblUserLogins_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_tblUserRoles_tblRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tblRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblUserRoles_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_tblUserTokens_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblTopicFeeds",
                columns: table => new
                {
                    FeedsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTopicFeeds", x => new { x.FeedsId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_tblTopicFeeds_tblFeeds_FeedsId",
                        column: x => x.FeedsId,
                        principalTable: "tblFeeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblTopicFeeds_tblTopics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "tblTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAttachments_tblPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "tblPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblRecentPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecentPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblRecentPosts_tblPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "tblPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRecentPosts_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSavedPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSavedPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblSavedPosts_tblPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "tblPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSavedPosts_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreaterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReplyToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblComments_tblAttachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "tblAttachments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblComments_tblComments_ReplyToId",
                        column: x => x.ReplyToId,
                        principalTable: "tblComments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblComments_tblPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "tblPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblComments_tblUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "tblUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsUp = table.Column<bool>(type: "bit", nullable: false),
                    VoterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblVotes_tblComments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "tblComments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblVotes_tblPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "tblPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblVotes_tblUsers_VoterId",
                        column: x => x.VoterId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblMajors",
                columns: new[] { "Id", "CreatedAt", "DateDeleted", "Description", "IsDeleted", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("058006cb-ea6e-4b78-a9cc-f41aed7b971c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7645), "Software Engineering" },
                    { new Guid("1e0bbbd2-31cb-4f2d-973d-2e09a2224736"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7654), "Artificial Intelligence" },
                    { new Guid("2657b60b-0763-41af-bb26-ae6aa5113153"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7688), "Public Relations" },
                    { new Guid("503810ee-1850-4438-8e2b-3331fc1e7c36"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7664), "Hotel Management" },
                    { new Guid("55d25a7d-b8bc-4c90-99d8-2aa586d44055"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7680), "Korean Language" },
                    { new Guid("5c75f924-7188-42ea-919e-bba5aaa7c22d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7674), "English Language" },
                    { new Guid("6b226e1d-d2f0-425d-8127-b3cee5c20f4f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7662), "International Business" },
                    { new Guid("8dad246f-7f30-4455-8b39-e74186c5a1fd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7660), "Digital Marketing" },
                    { new Guid("946041da-5da2-4e29-ba3d-f348fbff4eca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7682), "Automotive Digital Technology" },
                    { new Guid("94642f28-dc5d-4e9f-a0e2-d92e19eae1a4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7656), "Information Security" },
                    { new Guid("a81aa840-0c66-4af2-91dc-0aee704af57e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7678), "Japanese Language" },
                    { new Guid("aeb339c9-3f83-495c-ac50-28af4913a990"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7676), "Chinese Language" },
                    { new Guid("c0a29af4-b397-4eee-8b0e-11979e7852f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7652), "Information Systems" },
                    { new Guid("ce5e76f1-b49f-4546-a977-aac6de447b68"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7666), "Multimedia Communication" },
                    { new Guid("d60261fb-ddaf-4917-bc71-2cc0d00c56de"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7670), "Finance" },
                    { new Guid("e75cb784-b305-4d1f-9209-b9e1e92e74ab"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7684), "Logistics" },
                    { new Guid("ead26ff9-4dc1-4089-8e0e-396a561061f9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7658), "Digital Art Design" },
                    { new Guid("ec1bc706-430e-4d6f-9105-0172451a1644"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A major of FPT University", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7672), "Tourism Services Management" }
                });

            migrationBuilder.InsertData(
                table: "tblRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10b3358d-e289-461d-976a-6efdc4968299", null, "Admin", "ADMIN" },
                    { "85307162-d0a5-4613-9d54-543085183ed9", null, "User", "USER" },
                    { "ca98ee5e-8158-442e-8ddd-89f7fd988b31", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "tblTopics",
                columns: new[] { "Id", "Avatar", "CreatedAt", "DateDeleted", "Description", "IsDeleted", "ModifiedAt", "Name", "NeedReview", "Panner" },
                values: new object[,]
                {
                    { new Guid("06ff2454-f4d7-4ad2-b28a-6496467f5ac9"), "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Programming Fundamentals", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7623), "PRF192", false, "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19" },
                    { new Guid("0baeb57a-ddba-4741-98e6-bec47f53abc0"), "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Object-Oriented Programming", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7533), "PRO192", false, "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19" },
                    { new Guid("508138da-3585-4e38-8b3d-184fba2e17d3"), "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Internet of Things", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7620), "IOT102", false, "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19" },
                    { new Guid("5fccffd1-1576-4aea-83c1-f2a4848d370d"), "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Software Testing", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7536), "SWT301", false, "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19" },
                    { new Guid("77f11fe6-6099-4a31-bbf4-afabe0e7edc2"), "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Introduction to Software Engineering", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7555), "SWE201c", false, "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19" },
                    { new Guid("86a20668-e557-45d2-ae3f-d7401a8c6fcc"), "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Software development project", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7530), "SWP391", false, "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19" },
                    { new Guid("90d4a66a-b10c-454f-a67f-f759e3c0b22b"), "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Statistics and Probability", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7559), "MAS291", false, "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19" },
                    { new Guid("a5e15215-85ba-4a56-b13c-4aec167c2d5b"), "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elementary Japanese 2", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7508), "JPD123", false, "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19" },
                    { new Guid("bb059ee6-0bb8-4626-9f11-1d8accd1ced1"), "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Java web Application", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7617), "PRJ301", false, "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19" },
                    { new Guid("d4e565a9-e789-4da2-97c2-e1c89d60a7a4"), "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elementary Japanese 1", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7562), "JPD113", false, "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19" },
                    { new Guid("d6d05578-aa0a-4056-96b5-c19e28526109"), "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Basis Cross-Platform Application Programming With .NET", false, new DateTime(2025, 7, 9, 0, 14, 29, 625, DateTimeKind.Local).AddTicks(7627), "PRN212", false, "https://firebasestorage.googleapis.com/v0/b/fir-6ea1c.appspot.com/o/images%2Fpost8242222e-2b8f-4a16-b281-e7f5ada75bc0?alt=media&token=2ebdbdf5-7cc1-4e60-a59e-9adbcd563f19" }
                });

            migrationBuilder.InsertData(
                table: "tblMajorTopics",
                columns: new[] { "MajorsId", "TopicsId" },
                values: new object[,]
                {
                    { new Guid("058006cb-ea6e-4b78-a9cc-f41aed7b971c"), new Guid("0baeb57a-ddba-4741-98e6-bec47f53abc0") },
                    { new Guid("058006cb-ea6e-4b78-a9cc-f41aed7b971c"), new Guid("5fccffd1-1576-4aea-83c1-f2a4848d370d") },
                    { new Guid("058006cb-ea6e-4b78-a9cc-f41aed7b971c"), new Guid("77f11fe6-6099-4a31-bbf4-afabe0e7edc2") },
                    { new Guid("058006cb-ea6e-4b78-a9cc-f41aed7b971c"), new Guid("bb059ee6-0bb8-4626-9f11-1d8accd1ced1") },
                    { new Guid("a81aa840-0c66-4af2-91dc-0aee704af57e"), new Guid("a5e15215-85ba-4a56-b13c-4aec167c2d5b") },
                    { new Guid("a81aa840-0c66-4af2-91dc-0aee704af57e"), new Guid("d4e565a9-e789-4da2-97c2-e1c89d60a7a4") },
                    { new Guid("c0a29af4-b397-4eee-8b0e-11979e7852f4"), new Guid("508138da-3585-4e38-8b3d-184fba2e17d3") },
                    { new Guid("d60261fb-ddaf-4917-bc71-2cc0d00c56de"), new Guid("90d4a66a-b10c-454f-a67f-f759e3c0b22b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAttachments_PostId",
                table: "tblAttachments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_tblComments_AttachmentId",
                table: "tblComments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblComments_CreaterId",
                table: "tblComments",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_tblComments_PostId",
                table: "tblComments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_tblComments_ReplyToId",
                table: "tblComments",
                column: "ReplyToId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFeeds_CreaterId",
                table: "tblFeeds",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMajorTopics_TopicsId",
                table: "tblMajorTopics",
                column: "TopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblModerators_ModeratedTopicsId",
                table: "tblModerators",
                column: "ModeratedTopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNotifications_ReceiverId",
                table: "tblNotifications",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPosts_CreaterId",
                table: "tblPosts",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPosts_TopicId",
                table: "tblPosts",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProfiles_MajorId",
                table: "tblProfiles",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProfiles_UserId",
                table: "tblProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblRecentPosts_PostId",
                table: "tblRecentPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecentPosts_UserId",
                table: "tblRecentPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReports_CreaterId",
                table: "tblReports",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRoleClaims_RoleId",
                table: "tblRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "tblRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblSavedPosts_PostId",
                table: "tblSavedPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSavedPosts_UserId",
                table: "tblSavedPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTopicBans_TopicId",
                table: "tblTopicBans",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTopicBans_UserId",
                table: "tblTopicBans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTopicFeeds_TopicsId",
                table: "tblTopicFeeds",
                column: "TopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTopics_Name",
                table: "tblTopics",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblUserClaims_UserId",
                table: "tblUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserLogins_UserId",
                table: "tblUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRoles_RoleId",
                table: "tblUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "tblUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_Email",
                table: "tblUsers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_PasswordHash",
                table: "tblUsers",
                column: "PasswordHash");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_RefreshToken",
                table: "tblUsers",
                column: "RefreshToken");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_UserName",
                table: "tblUsers",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "tblUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblVotes_CommentId",
                table: "tblVotes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVotes_PostId",
                table: "tblVotes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVotes_VoterId",
                table: "tblVotes",
                column: "VoterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblMajorTopics");

            migrationBuilder.DropTable(
                name: "tblModerators");

            migrationBuilder.DropTable(
                name: "tblNotifications");

            migrationBuilder.DropTable(
                name: "tblProfiles");

            migrationBuilder.DropTable(
                name: "tblRecentPosts");

            migrationBuilder.DropTable(
                name: "tblReports");

            migrationBuilder.DropTable(
                name: "tblRoleClaims");

            migrationBuilder.DropTable(
                name: "tblSavedPosts");

            migrationBuilder.DropTable(
                name: "tblTopicBans");

            migrationBuilder.DropTable(
                name: "tblTopicFeeds");

            migrationBuilder.DropTable(
                name: "tblUserClaims");

            migrationBuilder.DropTable(
                name: "tblUserLogins");

            migrationBuilder.DropTable(
                name: "tblUserRoles");

            migrationBuilder.DropTable(
                name: "tblUserTokens");

            migrationBuilder.DropTable(
                name: "tblVotes");

            migrationBuilder.DropTable(
                name: "tblMajors");

            migrationBuilder.DropTable(
                name: "tblFeeds");

            migrationBuilder.DropTable(
                name: "tblRoles");

            migrationBuilder.DropTable(
                name: "tblComments");

            migrationBuilder.DropTable(
                name: "tblAttachments");

            migrationBuilder.DropTable(
                name: "tblPosts");

            migrationBuilder.DropTable(
                name: "tblTopics");

            migrationBuilder.DropTable(
                name: "tblUsers");
        }
    }
}
