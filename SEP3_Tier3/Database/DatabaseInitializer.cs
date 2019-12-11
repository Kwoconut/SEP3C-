using SEP3_TIER3.Model;
using System.Collections.Generic;
using System.Linq;
namespace SEP3_TIER3.Database
{
    class DatabaseInitializer
    {
        public static void Initialize(AppDbContext context)
        {

            context.Database.EnsureCreated();
            if (context.Nodes.Any() && context.Planes.Any() && context.Positions.Any() && context.FlightPlans.Any() && context.Edges.Any() && context.NodeEdges.Any() && context.FlightDates.Any())
            {
                return;
            }

            var positions = new List<Position>
            {
                new Position { XCoordinate = 1095, YCoordinate = 770},
                new Position { XCoordinate = 1100, YCoordinate = 730 },
                new Position { XCoordinate = 1090, YCoordinate = 690 },
                new Position { XCoordinate = 1070, YCoordinate = 660 },
                new Position { XCoordinate = 1020, YCoordinate = 700 },
                new Position { XCoordinate = 845, YCoordinate = 238 },
                new Position { XCoordinate = 505, YCoordinate = 238 },
                new Position { XCoordinate = 335, YCoordinate = 238 },
                new Position { XCoordinate = 323, YCoordinate = 185 },
                new Position { XCoordinate = 330, YCoordinate = 114 },
                new Position { XCoordinate = 520, YCoordinate = 114 },
                new Position { XCoordinate = 500, YCoordinate = 185 },
                new Position { XCoordinate = 800, YCoordinate = 114 },
                new Position { XCoordinate = 828, YCoordinate = 185 },
                new Position { XCoordinate = 1160, YCoordinate = 114 },
                new Position { XCoordinate = 1175, YCoordinate = 185 },
                new Position { XCoordinate = 1300, YCoordinate = 114 },
                new Position { XCoordinate = 1327, YCoordinate = 185 },
                new Position { XCoordinate = 1315, YCoordinate = 238 },
                new Position { XCoordinate = 1170, YCoordinate = 238 },
                new Position { XCoordinate = 0, YCoordinate = 115 },
                new Position { XCoordinate = 1550, YCoordinate = 115 },
                new Position { XCoordinate = 956, YCoordinate = 486 },
                new Position { XCoordinate = 1008, YCoordinate = 790 },
                new Position { XCoordinate = 1380, YCoordinate = 560 },
                new Position { XCoordinate = 1362, YCoordinate = 430 },
                new Position { XCoordinate = 1345, YCoordinate = 290 },
                new Position { XCoordinate = 940, YCoordinate = 165 },
                new Position { XCoordinate = 543, YCoordinate = 390 },
                new Position { XCoordinate = 565, YCoordinate = 530 },
                new Position { XCoordinate = 580, YCoordinate = 660 },
                new Position { XCoordinate = 720, YCoordinate = 680 },
                new Position { XCoordinate = 1255, YCoordinate = 620 },
                new Position { XCoordinate = 1210, YCoordinate = 270 },
                new Position { XCoordinate = 690, YCoordinate = 335 },
                new Position { XCoordinate = 575, YCoordinate = 980 },
                new Position { XCoordinate = 290, YCoordinate = 910 },
                new Position { XCoordinate = 105, YCoordinate = 765 },
                new Position { XCoordinate = 60, YCoordinate = 410 },
                new Position { XCoordinate = 470, YCoordinate = 92 },
                new Position { XCoordinate = 1300, YCoordinate = 10 },
                new Position { XCoordinate = 1650, YCoordinate = 50 },
                new Position { XCoordinate = 1835, YCoordinate = 200 },
                new Position { XCoordinate = 1872, YCoordinate = 560 },
                new Position { XCoordinate = 1730, YCoordinate = 750 },
                new Position { XCoordinate = 1464, YCoordinate = 868 },
            };

            var flightDates = new List<FlightDate>
            {
                new FlightDate(10, 5, 2005, 10, 5, 10),
                new FlightDate(12, 2, 2005, 15, 5, 10)
            };

            var flightPlans = new List<FlightPlan>
            {
            new FlightPlan{StartLocation="Sibiu", EndLocation="Aalborg", ArrivalTime= flightDates[0], DepartureTime = flightDates[1]},
            new FlightPlan{StartLocation="Copenhagen", EndLocation="Aalborg", ArrivalTime= flightDates[0], DepartureTime = flightDates[1]},
            new FlightPlan{StartLocation="Aalborg", EndLocation="Iasi", ArrivalTime= flightDates[0], DepartureTime = flightDates[1]},
            new FlightPlan{StartLocation="Berlin", EndLocation="Aalborg", ArrivalTime= flightDates[0], DepartureTime = flightDates[1]},
            new FlightPlan{StartLocation="London", EndLocation="Aalborg", ArrivalTime= flightDates[0], DepartureTime = flightDates[1]},
            new FlightPlan{StartLocation="Roma", EndLocation="Aalborg", ArrivalTime= flightDates[0], DepartureTime = flightDates[1]},
            new FlightPlan{StartLocation="Lisbon", EndLocation="Aalborg", ArrivalTime= flightDates[0], DepartureTime = flightDates[1]},
            new FlightPlan{StartLocation="Bucharest", EndLocation="Aalborg", ArrivalTime= flightDates[0], DepartureTime = flightDates[1]},
            new FlightPlan{StartLocation="Detroit", EndLocation="Aalborg", ArrivalTime= flightDates[0], DepartureTime = flightDates[1]},
            new FlightPlan{StartLocation="Milano", EndLocation="Aalborg", ArrivalTime= flightDates[0], DepartureTime = flightDates[1]},
            };

            Position positionStated = new Position { XCoordinate = 0, YCoordinate = 114 };

            var planes = new List<Plane>
            {
            new Plane{CallSign="Wz3689", Company= "Wizz Air", Model="Airbus A700", Status="In Air", FlightPlan = flightPlans[0], Position = positionStated},
            new Plane{CallSign="Wz4214", Company= "Wizz Air", Model="Airbus A700", Status="In Air", FlightPlan = flightPlans[1], Position = positionStated},
            new Plane{CallSign="Wz1533", Company= "Wizz Air", Model="Airbus A700", Status="In Air", FlightPlan = flightPlans[2], Position = positionStated},
            new Plane{CallSign="Rn1634", Company= "Ryan Air", Model="Airbus A301", Status="In Air", FlightPlan = flightPlans[3], Position = positionStated},
            new Plane{CallSign="Rn3359", Company= "Ryan Air", Model="Airbus A301", Status="In Air", FlightPlan = flightPlans[4], Position = positionStated},
            new Plane{CallSign="Va7433", Company= "Voila", Model="Airbus A320", Status="In Air", FlightPlan = flightPlans[5], Position = positionStated},
            new Plane{CallSign="Va9463", Company= "Voila", Model="Airbus A320", Status="In Air", FlightPlan = flightPlans[6], Position = positionStated},
            new Plane{CallSign="Ta3759", Company= "Turkish Airlines", Model="Boeing 777", Status="In Air", FlightPlan = flightPlans[7], Position = positionStated},
            new Plane{CallSign="Ta6732", Company= "Turkish Airlines", Model="Boeing 777", Status="In Air", FlightPlan = flightPlans[8], Position = positionStated}
            };
            var edges = new List<Edge>
            {
                new Edge{EdgeId = 1, FromNodeIndex = 8, ToNodeIndex = 9, Length = 4 },
                new Edge{EdgeId = 2, FromNodeIndex = 0, ToNodeIndex = 4, Length = 2 },
                new Edge{EdgeId = 3, FromNodeIndex = 11, ToNodeIndex = 10, Length = 4 },
                new Edge{EdgeId = 4, FromNodeIndex = 10, ToNodeIndex = 9, Length = 4},
                new Edge{EdgeId = 5, FromNodeIndex = 13, ToNodeIndex = 12, Length = 8},
                new Edge{EdgeId = 6, FromNodeIndex = 12, ToNodeIndex = 10, Length = 4},
                new Edge{EdgeId = 7, FromNodeIndex = 1, ToNodeIndex = 4, Length = 2},
                new Edge{EdgeId = 8, FromNodeIndex = 2, ToNodeIndex = 4, Length = 2},
                new Edge{EdgeId = 9, FromNodeIndex = 3, ToNodeIndex = 4, Length = 2},
                new Edge{EdgeId = 10, FromNodeIndex = 4, ToNodeIndex = 5, Length = 16},
                new Edge{EdgeId = 11, FromNodeIndex = 5, ToNodeIndex = 6, Length = 4},
                new Edge{EdgeId = 12, FromNodeIndex = 5, ToNodeIndex = 13, Length = 8},
                new Edge{EdgeId = 13, FromNodeIndex = 6, ToNodeIndex = 7, Length = 4},
                new Edge{EdgeId = 14, FromNodeIndex = 6, ToNodeIndex = 11, Length = 4},
                new Edge{EdgeId = 15, FromNodeIndex = 7, ToNodeIndex = 8, Length = 4},
                new Edge{EdgeId = 16, FromNodeIndex = 12, ToNodeIndex = 14, Length = 10},
                new Edge{EdgeId = 17, FromNodeIndex = 14, ToNodeIndex = 16, Length = 4},
                new Edge{EdgeId = 18, FromNodeIndex = 16, ToNodeIndex = 17, Length = 4},
                new Edge{EdgeId = 19, FromNodeIndex = 17, ToNodeIndex = 18, Length = 4},
                new Edge{EdgeId = 20, FromNodeIndex = 18, ToNodeIndex = 19, Length = 4},
                new Edge{EdgeId = 21, FromNodeIndex = 19, ToNodeIndex = 5, Length = 4},
                new Edge{EdgeId = 22, FromNodeIndex = 19, ToNodeIndex = 15, Length = 8},
                new Edge{EdgeId = 23, FromNodeIndex = 15, ToNodeIndex = 14, Length = 8}
            };


            var nodes = new List<Node>
            {
            new Node{NodeId = 0,  Name = "Gate A", IsVisited = false, Position = positions[0], isGroundNode = true},
            new Node{NodeId = 1, Name = "Gate B", IsVisited = false, Position = positions[1], isGroundNode = true},
            new Node{NodeId = 2, Name = "Gate C", IsVisited = false, Position = positions[2], isGroundNode = true },
            new Node{NodeId = 3, Name = "Gate D", IsVisited = false, Position = positions[3], isGroundNode = true },
            new Node{NodeId = 4, Name = "Main Taxiway", IsVisited = false, Position = positions[4], isGroundNode = true },
            new Node{NodeId = 5, Name = "Taxiway Chokepoint", IsVisited = false, Position = positions[5], isGroundNode = true },
            new Node{NodeId = 6, Name = "Taxiway A2", IsVisited = false, Position = positions[6], isGroundNode = true },
            new Node{NodeId = 7, Name = "Taxiway A2", IsVisited = false, Position = positions[7], isGroundNode = true },
            new Node{NodeId = 8, Name = "Auxiliary Taxiway C32", IsVisited = false, Position = positions[8], isGroundNode = true },
            new Node{NodeId = 9, Name = "Runway 14", IsVisited = false, Position = positions[9], isGroundNode = true },
            new Node{NodeId = 10, Name = "Runway", IsVisited = false, Position = positions[10], isGroundNode = true },
            new Node{NodeId = 11, Name = "Auxiliary Taxiway C33", IsVisited = false, Position = positions[11], isGroundNode = true },
            new Node{NodeId = 12, Name = "Runway", IsVisited = false, Position = positions[12], isGroundNode = true },
            new Node{NodeId = 13, Name = "Auxiliary Taxiway C34", IsVisited = false, Position = positions[13], isGroundNode = true },
            new Node{NodeId = 14, Name = "Runway", IsVisited = false, Position = positions[14], isGroundNode = true },
            new Node{NodeId = 15, Name = "Auxiliary Taxiway C35", IsVisited = false, Position = positions[15], isGroundNode = true },
            new Node{NodeId = 16, Name = "Runway 25", IsVisited = false, Position = positions[16], isGroundNode = true },
            new Node{NodeId = 17, Name = "Auxiliary Taxiway C36", IsVisited = false, Position = positions[17], isGroundNode = true },
            new Node{NodeId = 18, Name = "Taxiway A2", IsVisited = false, Position = positions[18], isGroundNode = true },
            new Node{NodeId = 19, Name = "Taxiway A2", IsVisited = false, Position = positions[19], isGroundNode = true },
            new Node{NodeId = 20, Name = "Exit Point West", IsVisited = false, Position = positions[20], isGroundNode = true },
            new Node{NodeId = 21, Name = "Exit Point East", IsVisited = false, Position = positions[21], isGroundNode = true },
            new Node{NodeId = 22, Name = "Aalborg Airport", IsVisited = false, Position = positions[22], isGroundNode = false },
            new Node{NodeId = 23, Name = "Airspace A1", IsVisited = false, Position = positions[23], isGroundNode = false },
            new Node{NodeId = 24, Name = "Airspace A2", IsVisited = false, Position = positions[24], isGroundNode = false },
            new Node{NodeId = 25, Name = "Airspace A3", IsVisited = false, Position = positions[25], isGroundNode = false },
            new Node{NodeId = 26, Name = "Airspace A4", IsVisited = false, Position = positions[26], isGroundNode = false },
            new Node{NodeId = 27, Name = "Airspace A5", IsVisited = false, Position = positions[27], isGroundNode = false },
            new Node{NodeId = 28, Name = "Airspace A6", IsVisited = false, Position = positions[28], isGroundNode = false },
            new Node{NodeId = 29, Name = "Airspace A7", IsVisited = false, Position = positions[29], isGroundNode = false },
            new Node{NodeId = 30, Name = "Airspace A8", IsVisited = false, Position = positions[30], isGroundNode = false },
            new Node{NodeId = 31, Name = "Airspace A9", IsVisited = false, Position = positions[31], isGroundNode = false },
            new Node{NodeId = 32, Name = "Airspace A10", IsVisited = false, Position = positions[32], isGroundNode = false },
            new Node{NodeId = 33, Name = "Airspace A11", IsVisited = false, Position = positions[33], isGroundNode = false },
            new Node{NodeId = 34, Name = "Airspace A12", IsVisited = false, Position = positions[34], isGroundNode = false },
            new Node{NodeId = 35, Name = "Airspace B1", IsVisited = false, Position = positions[35], isGroundNode = false },
            new Node{NodeId = 36, Name = "Airspace B2", IsVisited = false, Position = positions[36], isGroundNode = false },
            new Node{NodeId = 37, Name = "Airspace B3", IsVisited = false, Position = positions[37], isGroundNode = false },
            new Node{NodeId = 38, Name = "Airspace B4", IsVisited = false, Position = positions[38], isGroundNode = false },
            new Node{NodeId = 39, Name = "Airspace B5", IsVisited = false, Position = positions[39], isGroundNode = false },
            new Node{NodeId = 40, Name = "Airspace B6", IsVisited = false, Position = positions[40], isGroundNode = false },
            new Node{NodeId = 41, Name = "Airspace B7", IsVisited = false, Position = positions[41], isGroundNode = false },
            new Node{NodeId = 42, Name = "Airspace B8", IsVisited = false, Position = positions[42], isGroundNode = false },
            new Node{NodeId = 43, Name = "Airspace B9", IsVisited = false, Position = positions[43], isGroundNode = false },
            new Node{NodeId = 44, Name = "Airspace B10", IsVisited = false, Position = positions[44], isGroundNode = false },
            new Node{NodeId = 45, Name = "Airspace B11", IsVisited = false, Position = positions[45], isGroundNode = false }
            };

            var nodeEdges = new List<NodeEdge>
            {
                new NodeEdge{EdgeId = 1, NodeId = 9},
                new NodeEdge{EdgeId = 1, NodeId = 10},
                new NodeEdge{EdgeId = 2, NodeId = 1},
                new NodeEdge{EdgeId = 2, NodeId = 5},
                new NodeEdge{EdgeId = 3, NodeId = 11},
                new NodeEdge{EdgeId = 3, NodeId = 12},
                new NodeEdge{EdgeId = 4, NodeId = 10},
                new NodeEdge{EdgeId = 4, NodeId = 11},
                new NodeEdge{EdgeId = 5, NodeId = 13},
                new NodeEdge{EdgeId = 5, NodeId = 14},
                new NodeEdge{EdgeId = 6, NodeId = 11},
                new NodeEdge{EdgeId = 6, NodeId = 13},
                new NodeEdge{EdgeId = 7, NodeId = 2},
                new NodeEdge{EdgeId = 7, NodeId = 5},
                new NodeEdge{EdgeId = 8, NodeId = 3},
                new NodeEdge{EdgeId = 8, NodeId = 5},
                new NodeEdge{EdgeId = 9, NodeId = 4},
                new NodeEdge{EdgeId = 9, NodeId = 5},
                new NodeEdge{EdgeId = 10, NodeId = 5},
                new NodeEdge{EdgeId = 10, NodeId = 6},
                new NodeEdge{EdgeId = 11, NodeId = 6},
                new NodeEdge{EdgeId = 11, NodeId = 7},
                new NodeEdge{EdgeId = 12, NodeId = 6},
                new NodeEdge{EdgeId = 12, NodeId = 14},
                new NodeEdge{EdgeId = 13, NodeId = 8},
                new NodeEdge{EdgeId = 13, NodeId = 7},
                new NodeEdge{EdgeId = 14, NodeId = 12},
                new NodeEdge{EdgeId = 14, NodeId = 7},
                new NodeEdge{EdgeId = 15, NodeId = 8},
                new NodeEdge{EdgeId = 15, NodeId = 9},
                new NodeEdge{EdgeId = 16, NodeId = 11},
                new NodeEdge{EdgeId = 16, NodeId = 15},
                new NodeEdge{EdgeId = 17, NodeId = 15},
                new NodeEdge{EdgeId = 17, NodeId = 17},
                new NodeEdge{EdgeId = 18, NodeId = 17},
                new NodeEdge{EdgeId = 18, NodeId = 18},
                new NodeEdge{EdgeId = 19, NodeId = 18},
                new NodeEdge{EdgeId = 19, NodeId = 19},
                new NodeEdge{EdgeId = 20, NodeId = 19},
                new NodeEdge{EdgeId = 20, NodeId = 20},
                new NodeEdge{EdgeId = 21, NodeId = 20},
                new NodeEdge{EdgeId = 21, NodeId = 6},
                new NodeEdge{EdgeId = 22, NodeId = 16},
                new NodeEdge{EdgeId = 23, NodeId = 16}
            };

            foreach (Position position in positions)
            {
                context.Add(position);
            }
            context.SaveChanges();

            foreach (FlightDate flightDate in flightDates)
            {
                context.Add(flightDate);
            }
            context.SaveChanges();

            foreach (FlightPlan flight in flightPlans)
            {
                context.Add(flight);
            }
            context.SaveChanges();

            foreach (Plane plane in planes)
            {
                context.Add(plane);
            }
            context.SaveChanges();

            foreach (Edge edge in edges)
            {
                context.Add(edge);
            }
            context.SaveChanges();

            foreach (Node node in nodes)
            {
                context.Add(node);
            }
            context.SaveChanges();

            foreach (NodeEdge nodeEdge in nodeEdges)
            {
                context.Add(nodeEdge);
            }
            context.SaveChanges();
        }
    }
}