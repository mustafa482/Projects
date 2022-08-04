using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFMVC.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    SubjectTeahersTeacherId = table.Column<int>(type: "int", nullable: false),
                    TeacherSubjectsSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => new { x.SubjectTeahersTeacherId, x.TeacherSubjectsSubjectId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subjects_TeacherSubjectsSubjectId",
                        column: x => x.TeacherSubjectsSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teachers_SubjectTeahersTeacherId",
                        column: x => x.SubjectTeahersTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeacherSubjectsSubjectId",
                table: "SubjectTeacher",
                column: "TeacherSubjectsSubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectTeacher");
        }
    }
}
