﻿using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ef_asp.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.ID);
                });

            Randomizer.Seed = new Random(8675309);

            var fakerArticle = new Faker<Article>();
            fakerArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5));
            fakerArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2021, 1, 1), new DateTime(2022, 1, 1)));
            fakerArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 4));

            for (int i = 0; i < 150; i++)
            {
                Article article = fakerArticle.Generate();
                migrationBuilder.InsertData(
                    table: "articles",
                    columns: new[] { "Title", "Created", "Content" },
                    values: new Object[]{
                        article.Title,
                        article.Created,
                        article.Content
                    }
                );
            }

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
