using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCode.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campuss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campuss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Uf = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Pontos = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Detalhes = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividades_Campos_CampoId",
                        column: x => x.CampoId,
                        principalTable: "Campos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(100)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(100)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Campuss_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servidors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(100)", nullable: true),
                    Siape = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(100)", nullable: true),
                    CampusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servidors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servidors_Campuss_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Situacaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovimentadoPorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovimentadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Detalhes = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Situacaos_Statuss_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuss",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Progressaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClasseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(100)", nullable: true),
                    AtividadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progressaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progressaos_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Progressaos_Classes_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comprovantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgressaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtividadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arquivo = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprovantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comprovantes_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comprovantes_Progressaos_ProgressaoId",
                        column: x => x.ProgressaoId,
                        principalTable: "Progressaos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Validacaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComprovanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Justificativa = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Validacaos_Comprovantes_ComprovanteId",
                        column: x => x.ComprovanteId,
                        principalTable: "Comprovantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_CampoId",
                table: "Atividades",
                column: "CampoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidades",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comprovantes_AtividadeId",
                table: "Comprovantes",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comprovantes_ProgressaoId",
                table: "Comprovantes",
                column: "ProgressaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_CampusId",
                table: "Enderecos",
                column: "CampusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Progressaos_AtividadeId",
                table: "Progressaos",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Progressaos_ClasseId",
                table: "Progressaos",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Servidors_CampusId",
                table: "Servidors",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_Situacaos_StatusId",
                table: "Situacaos",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Validacaos_ComprovanteId",
                table: "Validacaos",
                column: "ComprovanteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Servidors");

            migrationBuilder.DropTable(
                name: "Situacaos");

            migrationBuilder.DropTable(
                name: "Validacaos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Campuss");

            migrationBuilder.DropTable(
                name: "Statuss");

            migrationBuilder.DropTable(
                name: "Comprovantes");

            migrationBuilder.DropTable(
                name: "Progressaos");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Campos");
        }
    }
}
