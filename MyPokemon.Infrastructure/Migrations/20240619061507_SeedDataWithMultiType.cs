using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyPokemon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataWithMultiType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PTypes",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4263), false, "Fire", new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4279) },
                    { 2, new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4282), false, "Water", new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4283) },
                    { 3, new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4284), false, "Grass", new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4285) },
                    { 4, new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4286), false, "Flying", new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4286) }
                });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "CreatedAt", "Height_m", "IsDeleted", "Name", "UpdatedAt", "Weight_kg" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4355), 0.6f, false, "Charmander", new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4355), 8.5f },
                    { 2, new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4358), 0.5f, false, "Squirtle", new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4358), 9f },
                    { 3, new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4360), 0.7f, false, "Bulbasaur", new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4361), 6.9f },
                    { 4, new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4402), 1.7f, false, "Charizard", new DateTime(2024, 6, 19, 13, 15, 6, 73, DateTimeKind.Local).AddTicks(4403), 90.5f }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
