using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Comunidad.Infraestructura.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ocupaciones",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemaEventos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemaEventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEventos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Direccion = table.Column<string>(maxLength: 400, nullable: false),
                    Ciudad = table.Column<string>(maxLength: 250, nullable: true),
                    Provincia = table.Column<string>(maxLength: 250, nullable: true),
                    CodigoPostal = table.Column<string>(maxLength: 10, nullable: true),
                    PaisId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ubicacion_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TipoEventoId = table.Column<long>(nullable: false),
                    TemaEventoId = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 400, nullable: false),
                    UbicacionId = table.Column<long>(nullable: true),
                    FileName = table.Column<string>(maxLength: 150, nullable: true),
                    Path = table.Column<string>(maxLength: 400, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 4000, nullable: false),
                    Organizador = table.Column<string>(maxLength: 250, nullable: false),
                    EsPaginaPublica = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MostrarLasEntradasRestantes = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemaEvento_Eventos",
                        column: x => x.TemaEventoId,
                        principalTable: "TemaEventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoEvento_Eventos",
                        column: x => x.TipoEventoId,
                        principalTable: "TipoEventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventos_Ubicacion_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "Ubicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Apellido = table.Column<string>(maxLength: 250, nullable: false),
                    ApellidoCasada = table.Column<string>(maxLength: 250, nullable: false),
                    Nombre = table.Column<string>(maxLength: 250, nullable: false),
                    Dni = table.Column<string>(maxLength: 8, nullable: false),
                    UbicacionId = table.Column<long>(nullable: true),
                    Telefono = table.Column<string>(maxLength: 25, nullable: true),
                    Celular = table.Column<string>(maxLength: 25, nullable: true),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    AltaPorMostrador = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Ubicacion_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "Ubicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EventoId = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 250, nullable: false),
                    CantidadDisponible = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TipoEntrada = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrada_Evento",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programaciones",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EventoId = table.Column<long>(nullable: false),
                    FechaDesde = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "Date", nullable: false),
                    HoraEntrada = table.Column<string>(maxLength: 10, nullable: false),
                    HoraSalida = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programacion_Evento",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PersonaId = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EntradaId = table.Column<long>(nullable: false),
                    PersonaId = table.Column<long>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EstadoInscripcion = table.Column<int>(nullable: false),
                    OcupacionId = table.Column<long>(nullable: true),
                    EventoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Entrada",
                        column: x => x.EntradaId,
                        principalTable: "Entradas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Ocupaciones_OcupacionId",
                        column: x => x.OcupacionId,
                        principalTable: "Ocupaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Inscripciones",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acreditaciones",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PersonaId = table.Column<long>(nullable: false),
                    ProgramacionId = table.Column<long>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    EventoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acreditaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acreditaciones_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Acreditaciones",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programacion_Acreditaciones",
                        column: x => x.ProgramacionId,
                        principalTable: "Programaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 1L, "AFGANISTÁN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 127L, "NEPAL", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 128L, "NICARAGUA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 129L, "NÍGER", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 130L, "NIGERIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 131L, "NORUEGA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 132L, "NUEVA ZELANDA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 133L, "OMÁN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 134L, "PAÍSES BAJOS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 135L, "PAKISTÁN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 126L, "NAURU", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 136L, "PALAOS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 138L, "PAPÚA NUEVA GUINEA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 139L, "PARAGUAY", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 140L, "PERÚ", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 141L, "POLONIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 142L, "PORTUGAL", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 143L, "REINO UNIDO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 144L, "REPÚBLICA CENTROAFRICANA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 145L, "REPÚBLICA CHECA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 146L, "REPÚBLICA DE MACEDONIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 137L, "PANAMÁ", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 125L, "NAMIBIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 124L, "MOZAMBIQUE", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 123L, "MONTENEGRO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 101L, "LESOTO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 102L, "LETONIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 103L, "LÍBANO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 104L, "LIBERIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 105L, "LIBIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 106L, "LIECHTENSTEIN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 107L, "LITUANIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 109L, "MADAGASCAR", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 110L, "MALASIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 111L, "MALAUI", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 112L, "MALDIVAS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 113L, "MALÍ", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 114L, "MALTA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 115L, "MARRUECOS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 116L, "MAURICIO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 117L, "MAURITANIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 118L, "MÉXICO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 119L, "MICRONESIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 120L, "MOLDAVIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 121L, "MÓNACO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 122L, "MONGOLIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 147L, "REPÚBLICA DEL CONGO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 100L, "LAOS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 148L, "REPÚBLICA DEMOCRÁTICA DEL CONGO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 150L, "REPÚBLICA SUDAFRICANA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 176L, "TAYIKISTÁN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 177L, "TIMOR ORIENTAL", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 178L, "TOGO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 179L, "TONGA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 180L, "TRINIDAD Y TOBAGO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 181L, "TÚNEZ", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 182L, "TURKMENISTÁN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 183L, "TURQUÍA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 184L, "TUVALU", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 175L, "TANZANIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 185L, "UCRANIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 187L, "URUGUAY", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 188L, "UZBEKISTÁN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 189L, "VANUATU", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 190L, "VENEZUELA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 191L, "VIETNAM", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 192L, "YEMEN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 193L, "YIBUTI", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 194L, "ZAMBIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 195L, "ZIMBABUE", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 186L, "UGANDA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 174L, "TAILANDIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 173L, "SURINAM", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 172L, "SUIZA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 151L, "RUANDA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 152L, "RUMANÍA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 153L, "RUSIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 154L, "SAMOA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 155L, "SAN CRISTÓBAL Y NIEVES", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 156L, "SAN MARINO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 157L, "SAN VICENTE Y LAS GRANADINAS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 158L, "SANTA LUCÍA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 159L, "SANTO TOMÉ Y PRÍNCIPE", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 160L, "SENEGAL", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 161L, "SERBIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 162L, "SEYCHELLES", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 163L, "SIERRA LEONA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 164L, "SINGAPUR", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 165L, "SIRIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 166L, "SOMALIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 167L, "SRI LANKA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 168L, "SUAZILANDIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 169L, "SUDÁN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 170L, "SUDÁN DEL SUR", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 171L, "SUECIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 149L, "REPÚBLICA DOMINICANA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 99L, "KUWAIT", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 108L, "LUXEMBURGO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 97L, "KIRGUISTÁN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 27L, "BRUNÉI", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 28L, "BULGARIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 29L, "BURKINA FASO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 30L, "BURUNDI", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 31L, "BUTÁN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 32L, "CABO VERDE", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 33L, "CAMBOYA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 34L, "CAMERÚN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 35L, "CANADÁ", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 36L, "CATAR", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 37L, "CHAD", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 38L, "CHILE", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 39L, "CHINA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 98L, "KIRIBATI", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 41L, "CIUDAD DEL VATICANO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 42L, "COLOMBIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 43L, "COMORAS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 44L, "COREA DEL NORTE", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 45L, "COREA DEL SUR", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 46L, "COSTA DE MARFIL", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 47L, "COSTA RICA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 26L, "BRASIL", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 48L, "CROACIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 25L, "BOTSUANA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 23L, "BOLIVIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 2L, "ALBANIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 3L, "ALEMANIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 4L, "ANDORRA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 5L, "ANGOLA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 6L, "ANTIGUA Y BARBUDA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 7L, "ARABIA SAUDITA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 8L, "ARGELIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 9L, "ARGENTINA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 10L, "ARMENIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 11L, "AUSTRALIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 12L, "AUSTRIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 13L, "AZERBAIYÁN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 14L, "BAHAMAS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 15L, "BANGLADÉS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 16L, "BARBADOS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 17L, "BARÉIN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 18L, "BÉLGICA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 19L, "BELICE", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 20L, "BENÍN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 21L, "BIELORRUSIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 22L, "BIRMANIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 24L, "BOSNIA Y HERZEGOVINA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 49L, "CUBA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 40L, "CHIPRE", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 51L, "DOMINICA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 77L, "GUINEA-BISÁU", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 78L, "HAITÍ", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 79L, "HONDURAS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 80L, "HUNGRÍA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 81L, "INDIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 82L, "INDONESIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 83L, "IRAK", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 50L, "DINAMARCA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 85L, "IRLANDA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 76L, "GUINEA ECUATORIAL", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 86L, "ISRAEL", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 88L, "ISLAS MARSHALL", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 89L, "ISLAS SALOMÓN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 90L, "ISRAEL", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 91L, "ITALIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 92L, "JAMAICA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 93L, "JAPÓN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 94L, "JORDANIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 95L, "KAZAJISTÁN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 96L, "KENIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 87L, "ISLANDIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 75L, "GUINEA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 84L, "IRÁN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 73L, "GUATEMALA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 52L, "ECUADOR", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 74L, "GUYANA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 54L, "EL SALVADOR", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 55L, "EMIRATOS ÁRABES UNIDOS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 56L, "ERITREA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 57L, "ESLOVAQUIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 58L, "ESLOVENIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 59L, "ESPAÑA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 60L, "ESTADOS UNIDOS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 61L, "ESTONIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 53L, "EGIPTO", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 63L, "FILIPINAS", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 64L, "FINLANDIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 65L, "FIYI", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 66L, "FRANCIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 67L, "GABÓN", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 68L, "GAMBIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 69L, "GEORGIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 70L, "GHANA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 71L, "GRANADA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 72L, "GRECIA", false });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 62L, "ETIOPÍA", false });

            migrationBuilder.InsertData(
                table: "TemaEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 10L, "OTROS", false });

            migrationBuilder.InsertData(
                table: "TemaEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 9L, "SEMINARIO O CHARLA", false });

            migrationBuilder.InsertData(
                table: "TemaEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 8L, "TV SHOW", false });

            migrationBuilder.InsertData(
                table: "TemaEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 7L, "FIESTA O REUNION SOCIAL", false });

            migrationBuilder.InsertData(
                table: "TemaEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 6L, "FESTIVAL O FERIA", false });

            migrationBuilder.InsertData(
                table: "TemaEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 5L, "CONVENCION", false });

            migrationBuilder.InsertData(
                table: "TemaEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 3L, "CARRERA O EVENTO DEPORTIVO", false });

            migrationBuilder.InsertData(
                table: "TemaEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 2L, "CAMPAMENTO O RETIRO", false });

            migrationBuilder.InsertData(
                table: "TemaEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 1L, "CONCIERTO O PERFORMANCE", false });

            migrationBuilder.InsertData(
                table: "TemaEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 4L, "CONFERENCIA", false });

            migrationBuilder.InsertData(
                table: "TipoEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 9L, "Moda y belleza ", false });

            migrationBuilder.InsertData(
                table: "TipoEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 1L, "Hogar y estilo de vida", false });

            migrationBuilder.InsertData(
                table: "TipoEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 2L, "Artes escenicas y visuales", false });

            migrationBuilder.InsertData(
                table: "TipoEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 3L, "Cine medios de comunicacion y entretenimiento", false });

            migrationBuilder.InsertData(
                table: "TipoEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 4L, "Deportes y salud", false });

            migrationBuilder.InsertData(
                table: "TipoEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 5L, "Dias de fiesta", false });

            migrationBuilder.InsertData(
                table: "TipoEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 6L, "Familias y educacion", false });

            migrationBuilder.InsertData(
                table: "TipoEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 7L, "Gastronomia", false });

            migrationBuilder.InsertData(
                table: "TipoEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 8L, "Política", false });

            migrationBuilder.InsertData(
                table: "TipoEventos",
                columns: new[] { "Id", "Descripcion", "EstaBorrado" },
                values: new object[] { 10L, "Otros", false });

            migrationBuilder.CreateIndex(
                name: "IX_Acreditaciones_EventoId",
                table: "Acreditaciones",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Acreditaciones_PersonaId",
                table: "Acreditaciones",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Acreditaciones_ProgramacionId",
                table: "Acreditaciones",
                column: "ProgramacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_EventoId",
                table: "Entradas",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TemaEventoId",
                table: "Eventos",
                column: "TemaEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoEventoId",
                table: "Eventos",
                column: "TipoEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UbicacionId",
                table: "Eventos",
                column: "UbicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EntradaId",
                table: "Inscripciones",
                column: "EntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EventoId",
                table: "Inscripciones",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_OcupacionId",
                table: "Inscripciones",
                column: "OcupacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_PersonaId",
                table: "Inscripciones",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_UbicacionId",
                table: "Personas",
                column: "UbicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Programaciones_EventoId",
                table: "Programaciones",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_PaisId",
                table: "Ubicacion",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios",
                column: "PersonaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acreditaciones");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Programaciones");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Ocupaciones");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "TemaEventos");

            migrationBuilder.DropTable(
                name: "TipoEventos");

            migrationBuilder.DropTable(
                name: "Ubicacion");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
