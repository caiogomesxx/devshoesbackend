using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRODUTOS_TB_IMAGEM_PRODUTO_ImagemProdutoId",
                table: "TB_PRODUTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_TB_IMAGEM_USUARIO_ListaImagemUsuarioImagemUsuari~",
                table: "TB_USUARIOS");

            migrationBuilder.DropTable(
                name: "TB_IMAGEM_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_IMAGEM_USUARIO");

            migrationBuilder.DropIndex(
                name: "IX_TB_USUARIOS_ListaImagemUsuarioImagemUsuarioID",
                table: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_PRODUTOS_ImagemProdutoId",
                table: "TB_PRODUTOS");

            migrationBuilder.DropColumn(
                name: "ListaImagemUsuarioImagemUsuarioID",
                table: "TB_USUARIOS");

            migrationBuilder.DropColumn(
                name: "ImagemProdutoId",
                table: "TB_PRODUTOS");

            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "TB_CATEGORIAS");

            migrationBuilder.AddColumn<int>(
                name: "ImagemId",
                table: "TB_PRODUTOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_IMAGEM",
                columns: table => new
                {
                    ImagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImagemUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMAGEM", x => x.ImagemId);
                    table.ForeignKey(
                        name: "FK_TB_IMAGEM_TB_PRODUTOS_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "TB_PRODUTOS",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMAGEM_ProdutoId",
                table: "TB_IMAGEM",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_IMAGEM");

            migrationBuilder.DropColumn(
                name: "ImagemId",
                table: "TB_PRODUTOS");

            migrationBuilder.AddColumn<int>(
                name: "ListaImagemUsuarioImagemUsuarioID",
                table: "TB_USUARIOS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImagemProdutoId",
                table: "TB_PRODUTOS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "TB_CATEGORIAS",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_IMAGEM_PRODUTO",
                columns: table => new
                {
                    ImagemProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Imagem = table.Column<byte[]>(type: "longblob", nullable: false),
                    NomeImagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    TamanhoImagem = table.Column<long>(type: "bigint", nullable: false),
                    TipoImagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMAGEM_PRODUTO", x => x.ImagemProdutoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_IMAGEM_USUARIO",
                columns: table => new
                {
                    ImagemUsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Imagem = table.Column<byte[]>(type: "longblob", nullable: false),
                    NomeImagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TamanhoImagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoImagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMAGEM_USUARIO", x => x.ImagemUsuarioID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIOS_ListaImagemUsuarioImagemUsuarioID",
                table: "TB_USUARIOS",
                column: "ListaImagemUsuarioImagemUsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTOS_ImagemProdutoId",
                table: "TB_PRODUTOS",
                column: "ImagemProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRODUTOS_TB_IMAGEM_PRODUTO_ImagemProdutoId",
                table: "TB_PRODUTOS",
                column: "ImagemProdutoId",
                principalTable: "TB_IMAGEM_PRODUTO",
                principalColumn: "ImagemProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_TB_IMAGEM_USUARIO_ListaImagemUsuarioImagemUsuari~",
                table: "TB_USUARIOS",
                column: "ListaImagemUsuarioImagemUsuarioID",
                principalTable: "TB_IMAGEM_USUARIO",
                principalColumn: "ImagemUsuarioID");
        }
    }
}
