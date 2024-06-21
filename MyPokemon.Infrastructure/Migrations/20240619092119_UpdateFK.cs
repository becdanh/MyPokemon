using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPokemon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonTypes_PTypes_PokemonId",
                table: "PokemonTypes");

            migrationBuilder.UpdateData(
                table: "PTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2777), new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2794) });

            migrationBuilder.UpdateData(
                table: "PTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2797), new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2798) });

            migrationBuilder.UpdateData(
                table: "PTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2799), new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2800) });

            migrationBuilder.UpdateData(
                table: "PTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2801), new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2801) });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2865), new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2866) });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2868), new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2869) });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2870), new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2871) });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2872), new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2873) });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTypes_TypeId",
                table: "PokemonTypes",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonTypes_PTypes_TypeId",
                table: "PokemonTypes",
                column: "TypeId",
                principalTable: "PTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonTypes_PTypes_TypeId",
                table: "PokemonTypes");

            migrationBuilder.DropIndex(
                name: "IX_PokemonTypes_TypeId",
                table: "PokemonTypes");

            migrationBuilder.UpdateData(
                table: "PTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4263), new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4279) });

            migrationBuilder.UpdateData(
                table: "PTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4282), new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4283) });

            migrationBuilder.UpdateData(
                table: "PTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4284), new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4285) });

            migrationBuilder.UpdateData(
                table: "PTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4286), new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4286) });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4355), new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4355) });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4358), new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4358) });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4360), new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4361) });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4402), new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4403) });

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonTypes_PTypes_PokemonId",
                table: "PokemonTypes",
                column: "PokemonId",
                principalTable: "PTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
