using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryRegionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpMonth = table.Column<int>(type: "int", nullable: false),
                    ExpYear = table.Column<int>(type: "int", nullable: false),
                    BussinessEntityCreditCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BussinessEntitityCreditCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BussinessEntitityCreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BussinessEntitityCreditCards_CreditCards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BussinessEntitityCreditCards_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddressPromotion = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAddresses_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passwords_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessEntityAdresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntityAdresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessEntityAdresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BusinessEntityAdresses_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CountryRegionCode", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("04cc8734-e3ab-4173-b12f-5e5c6cff813f"), "ES", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8844), "Spain", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8845) },
                    { new Guid("04d47a62-7327-45f3-ad44-ae90a928f8e8"), "CH", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8882), "Switzerland", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8882) },
                    { new Guid("0a726818-2e31-4157-808c-3c3832d95377"), "TR", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8913), "Turkey", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8913) },
                    { new Guid("0f9860ad-9b48-4cad-9854-140e50de31f5"), "FR", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8840), "France", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8841) },
                    { new Guid("18710bb0-3b9c-4dfd-8b11-574d19753f43"), "LT", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8917), "Lithuania", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8918) },
                    { new Guid("1d9fecdb-88b9-427d-b97e-b4ceea7459ad"), "LV", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8920), "Latvia", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8920) },
                    { new Guid("22a544d4-cebb-4b9a-9497-082648c42e7e"), "IS", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8929), "Iceland", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8930) },
                    { new Guid("39194297-31cc-4744-99f1-2d50800df0b0"), "PT", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8846), "Portugal", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8847) },
                    { new Guid("3efa7242-69e6-40d1-accb-f4bc166e0de5"), "CZ", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8885), "Czech Republic", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8885) },
                    { new Guid("44584613-5be4-4db9-9a03-a9ebbb419022"), "BY", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8916), "Belarus", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8916) },
                    { new Guid("45c697e5-4568-4b40-b4e6-57ee251f9099"), "IT", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8843), "Italy", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8843) },
                    { new Guid("47c171f8-5c21-4377-b769-397581ca2fc4"), "EE", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8922), "Estonia", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8922) },
                    { new Guid("4850bc58-66b1-40a2-a3a2-07e6b891ef01"), "ME", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8899), "Montenegro", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8899) },
                    { new Guid("6c1665f0-8e87-441f-ad2a-286f412b7146"), "BG", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8909), "Bulgaria", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8909) },
                    { new Guid("6d12a961-ceeb-46f8-8f9d-c132acbd4801"), "UA", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8914), "Ukraine", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8914) },
                    { new Guid("6d77a303-239a-4f88-b3c8-640a69e42c14"), "NL", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8874), "Netherlands", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8874) },
                    { new Guid("6f1a32f5-3c42-4293-96d6-2f0289dfc934"), "RO", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8911), "Romania", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8911) },
                    { new Guid("78bf4940-2202-4c90-a37d-2de407a5875c"), "SI", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8892), "Slovenia", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8892) },
                    { new Guid("7c5f704f-1114-4461-9e25-9c3dc790ff5a"), "PL", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8883), "Poland", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8884) },
                    { new Guid("92b4c6b4-e6d4-41db-8a1c-ece9c8d40f04"), "XK", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8900), "Kosovo", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8902) },
                    { new Guid("a1314315-49f2-4a25-83af-a94dc5f4a723"), "HR", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8894), "Croatia", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8894) },
                    { new Guid("ab0ab621-9a1d-4f14-b5cb-4594ff4819f9"), "HU", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8887), "Hungary", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8887) },
                    { new Guid("ab881a21-90cf-412b-9ee4-4b078b80a996"), "GB", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8931), "United Kingdom", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8931) },
                    { new Guid("b01b6889-e854-46a3-b593-971611327064"), "RS", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8895), "Serbia", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8896) },
                    { new Guid("b2d06a08-ce47-40fb-b682-9c6bb34c45f5"), "GR", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8907), "Greece", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8908) },
                    { new Guid("b7f06a2e-fe5a-4653-9637-e7d7283f3287"), "AL", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8906), "Albania", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8906) },
                    { new Guid("b850f3cf-3b7c-494a-9c07-47c7c319bf1c"), "LU", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8878), "Luxembourg", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8878) },
                    { new Guid("ba5204bf-df43-4a84-8505-399608942e0e"), "BA", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8897), "Bosnia and Herzegovina", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8897) },
                    { new Guid("be48c089-dcd7-4c51-b2bb-bea34626b5a8"), "SK", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8890), "Slovakia", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8891) },
                    { new Guid("c8b5cf85-91db-4840-90b9-6d877bd5c91c"), "NO", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8926), "Norway", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8927) },
                    { new Guid("cefe4d2c-1af3-4db0-b75b-3aab4d010a7e"), "AT", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8880), "Austria", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8880) },
                    { new Guid("dbe31039-01f8-4d35-b056-a1c2ac7c7956"), "SE", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8925), "Sweden", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8925) },
                    { new Guid("df09cece-1a3b-4338-a663-41aaf3398520"), "FI", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8923), "Finland", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8924) },
                    { new Guid("ef40424f-c240-4cdc-a348-1717cb73d1a5"), "DE", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8836), "Germany", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8838) },
                    { new Guid("f77dfcb0-2e7e-4df5-a71f-057b5e2b1826"), "DK", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8928), "Denmark", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8928) },
                    { new Guid("fa887a2e-0426-4074-834d-571b9f24de62"), "IE", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8934), "Ireland", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8934) },
                    { new Guid("fb715975-1b1c-4f0f-95cf-fd02a7f473ee"), "BE", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8876), "Belgium", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8877) },
                    { new Guid("fe364e7f-8849-4735-9b29-a55edb2c4417"), "MK", "EU", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8903), "North Macedonia", new DateTime(2024, 8, 14, 7, 35, 54, 343, DateTimeKind.Utc).AddTicks(8903) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityAdresses_AddressId",
                table: "BusinessEntityAdresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityAdresses_PersonId",
                table: "BusinessEntityAdresses",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BussinessEntitityCreditCards_CreditCardId",
                table: "BussinessEntitityCreditCards",
                column: "CreditCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BussinessEntitityCreditCards_PersonId",
                table: "BussinessEntitityCreditCards",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_Email",
                table: "EmailAddresses",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_PersonId",
                table: "EmailAddresses",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_PersonId",
                table: "Passwords",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessEntityAdresses");

            migrationBuilder.DropTable(
                name: "BussinessEntitityCreditCards");

            migrationBuilder.DropTable(
                name: "EmailAddresses");

            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
