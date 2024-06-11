using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.MVPSaude.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MEDICO",
                columns: table => new
                {
                    MEDICOID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOMEMEDICO = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    CRM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ESPECIALIDADE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CONTATO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICO", x => x.MEDICOID);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTE",
                columns: table => new
                {
                    PACIENTEID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOMEPACIENTE = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DATANASCIMENTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GENERO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ENDERECO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    CONTATO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    EMAILPACIENTE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.PACIENTEID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    USUARIOID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOMEUSUARIO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    SENHAUSUARIO = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    EMAILUSUARIO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.USUARIOID);
                });

            migrationBuilder.CreateTable(
                name: "CONSULTA",
                columns: table => new
                {
                    CONSULTAID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PACIENTEID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MEDICOID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATACONSULTA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    HORACONSULTA = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    LOCALCONSULTA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    MENSAGEM = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSULTA", x => x.CONSULTAID);
                    table.ForeignKey(
                        name: "FK_CONSULTA_MEDICO_MEDICOID",
                        column: x => x.MEDICOID,
                        principalTable: "MEDICO",
                        principalColumn: "MEDICOID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONSULTA_PACIENTE_PACIENTEID",
                        column: x => x.PACIENTEID,
                        principalTable: "PACIENTE",
                        principalColumn: "PACIENTEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRONTUARIO",
                columns: table => new
                {
                    PRONTUARIOID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PACIENTEID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HISTORICOPACIENTE = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    MEDICAMENTO = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    TRIAGEM = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    HISTORICOFAMILIAR = table.Column<string>(type: "NVARCHAR2(2000)", maxLength: 2000, nullable: true),
                    EXAMES = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: true),
                    DATAPRONTUARIO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MEDICOID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRONTUARIO", x => x.PRONTUARIOID);
                    table.ForeignKey(
                        name: "FK_PRONTUARIO_MEDICO_MEDICOID",
                        column: x => x.MEDICOID,
                        principalTable: "MEDICO",
                        principalColumn: "MEDICOID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRONTUARIO_PACIENTE_PACIENTEID",
                        column: x => x.PACIENTEID,
                        principalTable: "PACIENTE",
                        principalColumn: "PACIENTEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_MEDICOID",
                table: "CONSULTA",
                column: "MEDICOID");

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_PACIENTEID",
                table: "CONSULTA",
                column: "PACIENTEID");

            migrationBuilder.CreateIndex(
                name: "IX_PRONTUARIO_MEDICOID",
                table: "PRONTUARIO",
                column: "MEDICOID");

            migrationBuilder.CreateIndex(
                name: "IX_PRONTUARIO_PACIENTEID",
                table: "PRONTUARIO",
                column: "PACIENTEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONSULTA");

            migrationBuilder.DropTable(
                name: "PRONTUARIO");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "MEDICO");

            migrationBuilder.DropTable(
                name: "PACIENTE");
        }
    }
}
