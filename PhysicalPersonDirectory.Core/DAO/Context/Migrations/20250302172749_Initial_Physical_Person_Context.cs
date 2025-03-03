using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhysicalPersonDirectory.Core.DAO.Context.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Physical_Person_Context : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeOfPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImageSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateOfPBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Person_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RelatedPersons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    RelatedPersonId = table.Column<int>(type: "int", nullable: false),
                    RelationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPersons", x => new { x.PersonId, x.RelatedPersonId });
                    table.ForeignKey(
                        name: "FK_RelatedPersons_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelatedPersons_Person_RelatedPersonId",
                        column: x => x.RelatedPersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "თბილისი" },
                    { 2, "ქუთაისი" },
                    { 3, "ბათუმი" },
                    { 4, "რუსთავი" },
                    { 5, "გორი" },
                    { 6, "ზუგდიდი" },
                    { 7, "ფოთი" },
                    { 8, "თელავი" },
                    { 9, "ოზურგეთი" },
                    { 10, "ამბროლაური" },
                    { 11, "ახალციხე" },
                    { 12, "ახალქალაქი" },
                    { 13, "მარნეული" },
                    { 14, "გარდაბანი" },
                    { 15, "ბოლნისი" },
                    { 16, "დუშეთი" },
                    { 17, "საგარეჯო" },
                    { 18, "ლაგოდეხი" },
                    { 19, "ბორჯომი" },
                    { 20, "ცხინვალი" },
                    { 21, "ცაგერი" },
                    { 22, "ლენტეხი" },
                    { 23, "მესტია" },
                    { 24, "წალენჯიხა" },
                    { 25, "ჩხოროწყუ" },
                    { 26, "ხობი" },
                    { 27, "სენაკი" },
                    { 28, "მარტვილი" },
                    { 29, "ვანი" },
                    { 30, "ტყიბული" },
                    { 31, "ბაღდათი" },
                    { 32, "ხარაგაული" },
                    { 33, "საჩხერე" },
                    { 34, "ხონი" },
                    { 35, "ნინოწმინდა" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "CityId", "DateOfPBirth", "Gender", "ImageSource", "Name", "PhoneNumber", "Pid", "Surname", "TypeOfPhone" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(1985, 11, 25), "Male", null, "გიორგი", "599123456", "01001000001", "აბაშიძე", "Mobile" },
                    { 2, 2, new DateOnly(1995, 5, 3), "Female", null, "მარიამ", "577654321", "01001000002", "ბერიძე", "Mobile" },
                    { 3, 3, new DateOnly(2005, 8, 11), "Male", null, "ნიკოლოზ", "2123456", "01001000003", "გიგაური", "HousePhone" },
                    { 4, 4, new DateOnly(1999, 3, 14), "Female", null, "ანა", "322456789", "01001000004", "დავითაშვილი", "OfficePhone" },
                    { 5, 5, new DateOnly(1985, 8, 25), "Male", null, "დათო", "555987654", "01001000005", "ელიზბარაშვილი", "Mobile" },
                    { 6, 6, new DateOnly(1998, 2, 24), "Female", null, "თეკლა", "2323232", "01001000006", "ვანიშვილი", "HousePhone" },
                    { 7, 7, new DateOnly(1985, 8, 25), "Male", null, "ლუკა", "344556677", "01001000007", "ზარანდია", "OfficePhone" },
                    { 8, 8, new DateOnly(1985, 8, 25), "Female", null, "ელენე", "591112233", "01001000008", "თორდია", "Mobile" },
                    { 9, 9, new DateOnly(1985, 8, 25), "Male", null, "გიორგი", "2667788", "01001000009", "კახიძე", "HousePhone" },
                    { 10, 10, new DateOnly(1985, 8, 25), "Female", null, "ნინო", "355667788", "01001000010", "ლომიძე", "OfficePhone" }
                });

            migrationBuilder.InsertData(
                table: "RelatedPersons",
                columns: new[] { "PersonId", "RelatedPersonId", "Id", "RelationType" },
                values: new object[,]
                {
                    { 1, 2, 1, "Colleague" },
                    { 3, 4, 2, "Familiar" },
                    { 5, 6, 3, "Other" },
                    { 7, 8, 4, "Other" },
                    { 9, 10, 5, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_CityId",
                table: "Person",
                column: "CityId",
                unique: true,
                filter: "[CityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Pid",
                table: "Person",
                column: "Pid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersons_RelatedPersonId",
                table: "RelatedPersons",
                column: "RelatedPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatedPersons");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
