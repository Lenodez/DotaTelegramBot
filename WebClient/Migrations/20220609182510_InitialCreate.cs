using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebClient.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    NickName = table.Column<string>(type: "TEXT", nullable: true),
                    MamaName = table.Column<string>(type: "TEXT", nullable: true),
                    PTSiki = table.Column<int>(type: "INTEGER", nullable: true),
                    GamePosition = table.Column<string>(type: "TEXT", nullable: true),
                    DotaBufURL = table.Column<string>(type: "TEXT", nullable: true),
                    InGameID = table.Column<int>(type: "INTEGER", nullable: true),
                    Tyanochka = table.Column<bool>(type: "INTEGER", nullable: true),
                    LovelyHero = table.Column<string>(type: "TEXT", nullable: true),
                    AnalyticsResult = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
