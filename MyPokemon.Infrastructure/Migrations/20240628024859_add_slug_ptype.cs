using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyPokemon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_slug_ptype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "PTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "PTypes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "PTypes");

            migrationBuilder.InsertData(
                table: "PTypes",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2777), false, "Fire", new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2794) },
                    { 2, new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2797), false, "Water", new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2798) },
                    { 3, new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2799), false, "Grass", new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2800) },
                    { 4, new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2801), false, "Flying", new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2801) }
                });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "CreatedAt", "Height_m", "IsDeleted", "Name", "UpdatedAt", "Weight_kg" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2865), 0.6f, false, "Charmander", new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2866), 8.5f },
                    { 2, new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2868), 0.5f, false, "Squirtle", new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2869), 9f },
                    { 3, new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2870), 0.7f, false, "Bulbasaur", new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2871), 6.9f },
                    { 4, new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2872), 1.7f, false, "Charizard", new DateTime(2024, 6, 19, 16, 21, 18, 996, DateTimeKind.Local).AddTicks(2873), 90.5f }
                });

            migrationBuilder.InsertData(
                table: "PokemonTypes",
                columns: new[] { "PokemonId", "TypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 4 }
                });
        }
    }
}
