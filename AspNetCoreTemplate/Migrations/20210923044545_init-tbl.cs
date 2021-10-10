using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AspNetCoreTemplate.Migrations
{
    public partial class inittbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "d_songs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    author = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    kind_of_music = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    rating = table.Column<decimal>(type: "numeric", nullable: false),
                    view = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_d_songs", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "d_songs",
                columns: new[] { "id", "author", "kind_of_music", "name", "rating", "view" },
                values: new object[,]
                {
                    { 1, "Sơn Tùng MTP", "Pop", "Lạc trôi", 4.6m, 120000 },
                    { 2, "Lê Bảo Bình", "Nhạc Trẻ", "Sai cách yêu", 4.2m, 45000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_d_songs_id",
                table: "d_songs",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "d_songs");
        }
    }
}
