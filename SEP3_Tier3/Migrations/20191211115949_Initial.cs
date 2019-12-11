using Microsoft.EntityFrameworkCore.Migrations;

namespace SEP3_TIER3.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edges",
                columns: table => new
                {
                    EdgeId = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    FromNodeIndex = table.Column<int>(nullable: false),
                    ToNodeIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edges", x => x.EdgeId);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    XCoordinate = table.Column<double>(nullable: false),
                    YCoordinate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => new { x.XCoordinate, x.YCoordinate });
                });

            migrationBuilder.CreateTable(
                name: "Timer",
                columns: table => new
                {
                    Seconds = table.Column<int>(nullable: false),
                    Minutes = table.Column<int>(nullable: false),
                    Hour = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Day = table.Column<int>(nullable: true),
                    Month = table.Column<int>(nullable: true),
                    Year = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timer", x => new { x.Hour, x.Minutes, x.Seconds });
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    NodeId = table.Column<int>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsVisited = table.Column<bool>(nullable: false),
                    PositionXCoordinate = table.Column<double>(nullable: false),
                    PositionYCoordinate = table.Column<double>(nullable: false),
                    DistanceFromSource = table.Column<int>(nullable: false),
                    IsGroundNode = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.NodeId);
                    table.ForeignKey(
                        name: "FK_Nodes_Positions_PositionXCoordinate_PositionYCoordinate",
                        columns: x => new { x.PositionXCoordinate, x.PositionYCoordinate },
                        principalTable: "Positions",
                        principalColumns: new[] { "XCoordinate", "YCoordinate" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureTimeHour = table.Column<int>(nullable: true),
                    DepartureTimeMinutes = table.Column<int>(nullable: true),
                    DepartureTimeSeconds = table.Column<int>(nullable: true),
                    ArrivalTimeHour = table.Column<int>(nullable: true),
                    ArrivalTimeMinutes = table.Column<int>(nullable: true),
                    ArrivalTimeSeconds = table.Column<int>(nullable: true),
                    StartLocation = table.Column<string>(nullable: true),
                    EndLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightPlans_Timer_ArrivalTimeHour_ArrivalTimeMinutes_ArrivalTimeSeconds",
                        columns: x => new { x.ArrivalTimeHour, x.ArrivalTimeMinutes, x.ArrivalTimeSeconds },
                        principalTable: "Timer",
                        principalColumns: new[] { "Hour", "Minutes", "Seconds" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightPlans_Timer_DepartureTimeHour_DepartureTimeMinutes_DepartureTimeSeconds",
                        columns: x => new { x.DepartureTimeHour, x.DepartureTimeMinutes, x.DepartureTimeSeconds },
                        principalTable: "Timer",
                        principalColumns: new[] { "Hour", "Minutes", "Seconds" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NodeEdges",
                columns: table => new
                {
                    EdgeId = table.Column<int>(nullable: false),
                    NodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeEdges", x => new { x.EdgeId, x.NodeId });
                    table.ForeignKey(
                        name: "FK_NodeEdges_Edges_EdgeId",
                        column: x => x.EdgeId,
                        principalTable: "Edges",
                        principalColumn: "EdgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NodeEdges_Nodes_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Nodes",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    CallSign = table.Column<string>(maxLength: 10, nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    FlightPlanId = table.Column<int>(nullable: false),
                    PositionXCoordinate = table.Column<double>(nullable: false),
                    PositionYCoordinate = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.CallSign);
                    table.ForeignKey(
                        name: "FK_Planes_FlightPlans_FlightPlanId",
                        column: x => x.FlightPlanId,
                        principalTable: "FlightPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planes_Positions_PositionXCoordinate_PositionYCoordinate",
                        columns: x => new { x.PositionXCoordinate, x.PositionYCoordinate },
                        principalTable: "Positions",
                        principalColumns: new[] { "XCoordinate", "YCoordinate" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlans_ArrivalTimeHour_ArrivalTimeMinutes_ArrivalTimeSeconds",
                table: "FlightPlans",
                columns: new[] { "ArrivalTimeHour", "ArrivalTimeMinutes", "ArrivalTimeSeconds" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlans_DepartureTimeHour_DepartureTimeMinutes_DepartureTimeSeconds",
                table: "FlightPlans",
                columns: new[] { "DepartureTimeHour", "DepartureTimeMinutes", "DepartureTimeSeconds" });

            migrationBuilder.CreateIndex(
                name: "IX_NodeEdges_NodeId",
                table: "NodeEdges",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_PositionXCoordinate_PositionYCoordinate",
                table: "Nodes",
                columns: new[] { "PositionXCoordinate", "PositionYCoordinate" });

            migrationBuilder.CreateIndex(
                name: "IX_Planes_FlightPlanId",
                table: "Planes",
                column: "FlightPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_PositionXCoordinate_PositionYCoordinate",
                table: "Planes",
                columns: new[] { "PositionXCoordinate", "PositionYCoordinate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NodeEdges");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Edges");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "FlightPlans");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Timer");
        }
    }
}
