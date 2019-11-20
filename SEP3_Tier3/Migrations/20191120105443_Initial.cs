using System;
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
                    EdgeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<int>(nullable: false),
                    FromNodeIndex = table.Column<int>(nullable: false),
                    ToNodeIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edges", x => x.EdgeId);
                });

            migrationBuilder.CreateTable(
                name: "FlightPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    Delay = table.Column<DateTime>(nullable: false),
                    StartLocation = table.Column<string>(nullable: true),
                    EndLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPlans", x => x.Id);
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
                name: "Target",
                columns: table => new
                {
                    XCoordinate = table.Column<double>(nullable: false),
                    YCoordinate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Target", x => new { x.XCoordinate, x.YCoordinate });
                });

            migrationBuilder.CreateTable(
                name: "GroundNodes",
                columns: table => new
                {
                    NodeId = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsVisited = table.Column<bool>(nullable: false),
                    PositionXCoordinate = table.Column<double>(nullable: false),
                    PositionYCoordinate = table.Column<double>(nullable: false),
                    DistanceFromSource = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundNodes", x => x.NodeId);
                    table.ForeignKey(
                        name: "FK_GroundNodes_Positions_PositionXCoordinate_PositionYCoordinate",
                        columns: x => new { x.PositionXCoordinate, x.PositionYCoordinate },
                        principalTable: "Positions",
                        principalColumns: new[] { "XCoordinate", "YCoordinate" },
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
                    TargetXCoordinate = table.Column<double>(nullable: false),
                    TargetYCoordinate = table.Column<double>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Planes_Target_TargetXCoordinate_TargetYCoordinate",
                        columns: x => new { x.TargetXCoordinate, x.TargetYCoordinate },
                        principalTable: "Target",
                        principalColumns: new[] { "XCoordinate", "YCoordinate" },
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_NodeEdges_GroundNodes_NodeId",
                        column: x => x.NodeId,
                        principalTable: "GroundNodes",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroundNodes_PositionXCoordinate_PositionYCoordinate",
                table: "GroundNodes",
                columns: new[] { "PositionXCoordinate", "PositionYCoordinate" });

            migrationBuilder.CreateIndex(
                name: "IX_NodeEdges_NodeId",
                table: "NodeEdges",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_FlightPlanId",
                table: "Planes",
                column: "FlightPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_PositionXCoordinate_PositionYCoordinate",
                table: "Planes",
                columns: new[] { "PositionXCoordinate", "PositionYCoordinate" });

            migrationBuilder.CreateIndex(
                name: "IX_Planes_TargetXCoordinate_TargetYCoordinate",
                table: "Planes",
                columns: new[] { "TargetXCoordinate", "TargetYCoordinate" });
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
                name: "GroundNodes");

            migrationBuilder.DropTable(
                name: "FlightPlans");

            migrationBuilder.DropTable(
                name: "Target");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
