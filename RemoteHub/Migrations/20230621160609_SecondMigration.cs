using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemoteHub.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResumeSkill_Resumes_resumesResumeId",
                table: "ResumeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_ResumeSkill_Skills_skillsSkillId",
                table: "ResumeSkill");

            migrationBuilder.RenameColumn(
                name: "skillsSkillId",
                table: "ResumeSkill",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "resumesResumeId",
                table: "ResumeSkill",
                newName: "ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_ResumeSkill_skillsSkillId",
                table: "ResumeSkill",
                newName: "IX_ResumeSkill_SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeSkill_Resumes_ResumeId",
                table: "ResumeSkill",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "ResumeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeSkill_Skills_SkillId",
                table: "ResumeSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResumeSkill_Resumes_ResumeId",
                table: "ResumeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_ResumeSkill_Skills_SkillId",
                table: "ResumeSkill");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "ResumeSkill",
                newName: "skillsSkillId");

            migrationBuilder.RenameColumn(
                name: "ResumeId",
                table: "ResumeSkill",
                newName: "resumesResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_ResumeSkill_SkillId",
                table: "ResumeSkill",
                newName: "IX_ResumeSkill_skillsSkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeSkill_Resumes_resumesResumeId",
                table: "ResumeSkill",
                column: "resumesResumeId",
                principalTable: "Resumes",
                principalColumn: "ResumeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeSkill_Skills_skillsSkillId",
                table: "ResumeSkill",
                column: "skillsSkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
