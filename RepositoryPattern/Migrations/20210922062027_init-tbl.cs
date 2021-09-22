using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RepositoryPattern.Migrations
{
    public partial class inittbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_song",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", nullable: false),
                    author = table.Column<string>(type: "character varying(50)", nullable: false),
                    kindOfMusic = table.Column<string>(type: "character varying(50)", nullable: true),
                    rating = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    view = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_song", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "m_song",
                columns: new[] { "id", "author", "kindOfMusic", "name", "rating", "view" },
                values: new object[,]
                {
                    { 1, "Sơn Tùng MTP", "Pop", "Lạc trôi", 4.6m, 120000 },
                    { 2, "Lê Bảo Bình", "Nhạc Trẻ", "Sai cách yêu", 4.2m, 45000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_song_id",
                table: "m_song",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_song");
        }
    }
}
