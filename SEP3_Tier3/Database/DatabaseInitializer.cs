
using SEP3_TIER3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SEP3_TIER3.Database
{
    class DatabaseInitializer
    {
        public static void Initialize(AppDbContext context)
        {

            context.Database.EnsureCreated();
            if (context.Planes.Any() && context.Positions.Any() && context.FlightPlans.Any() && context.Edges.Any() && context.GroundNodes.Any() && context.NodeEdges.Any())
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
                new Position { XCoordinate = 1170, YCoordinate = 238 }
            };


            var flightPlans = new List<FlightPlan>
            {
            new FlightPlan{ },
            new FlightPlan{ArrivalTime= new System.DateTime(2019, 12, 28, 11, 1, 10, DateTime.Now.Kind),DepartureTime = new System.DateTime(2019, 12, 28, 10, 00, 30, DateTime.Now.Kind),  Delay = new System.DateTime(2019,12,28,10,30,30, DateTime.Now.Kind )},
            new FlightPlan{ArrivalTime= new System.DateTime(2019, 12, 28, 11, 4, 30, DateTime.Now.Kind),DepartureTime = new System.DateTime(2019, 12, 28, 10, 00, 30, DateTime.Now.Kind),  Delay = new System.DateTime(2019,12,28,10,30,30, DateTime.Now.Kind )},
            new FlightPlan{ArrivalTime= new System.DateTime(2019, 12, 28, 11, 9, 30, DateTime.Now.Kind),DepartureTime = new System.DateTime(2019, 12, 28, 10, 00, 30, DateTime.Now.Kind),  Delay = new System.DateTime(2019,12,28,10,30,30, DateTime.Now.Kind )},
            new FlightPlan{ArrivalTime= new System.DateTime(2019, 12, 28, 11, 13, 30, DateTime.Now.Kind),DepartureTime = new System.DateTime(2019, 12, 28, 10, 00, 30, DateTime.Now.Kind),  Delay = new System.DateTime(2019,12,28,10,30,30, DateTime.Now.Kind )},
            new FlightPlan{ArrivalTime= new System.DateTime(2019, 12, 28, 11, 17, 30, DateTime.Now.Kind),DepartureTime = new System.DateTime(2019, 12, 28, 10, 00, 30, DateTime.Now.Kind),  Delay = new System.DateTime(2019,12,28,10,30,30, DateTime.Now.Kind )},
            new FlightPlan{ArrivalTime= new System.DateTime(2019, 12, 28, 11, 21, 30, DateTime.Now.Kind),DepartureTime = new System.DateTime(2019, 12, 28, 10, 00, 30, DateTime.Now.Kind),  Delay = new System.DateTime(2019,12,28,10,30,30, DateTime.Now.Kind )},
            new FlightPlan{ArrivalTime= new System.DateTime(2019, 12, 28, 11, 25, 30, DateTime.Now.Kind),DepartureTime = new System.DateTime(2019, 12, 28, 10, 00, 30, DateTime.Now.Kind),  Delay = new System.DateTime(2019,12,28,10,30,30, DateTime.Now.Kind )},
            new FlightPlan{ArrivalTime= new System.DateTime(2019, 12, 28, 11, 28, 30, DateTime.Now.Kind),DepartureTime = new System.DateTime(2019, 12, 28, 10, 00, 30, DateTime.Now.Kind),  Delay = new System.DateTime(2019,12,28,10,30,30, DateTime.Now.Kind )},
            new FlightPlan{ArrivalTime= new System.DateTime(2019, 12, 28, 11, 30, 30, DateTime.Now.Kind),DepartureTime = new System.DateTime(2019, 12, 28, 10, 00, 30, DateTime.Now.Kind),  Delay = new System.DateTime(2019,12,28,10,30,30, DateTime.Now.Kind )},
            };

            Position positionStated = new Position { XCoordinate = 0, YCoordinate = 114 };
            Target target = new Target { XCoordinate = 255, YCoordinate = 255 };

            var planes = new List<Plane>
            {
            new Plane{CallSign="Wz3689", Company= "Wizz Air", Model="Airbus A700", Status="In Air", FlightPlan = flightPlans[0], Position = positionStated, Target = target },
            new Plane{CallSign="Wz4214", Company= "Wizz Air", Model="Airbus A700", Status="In Air", FlightPlan = flightPlans[0], Position = positionStated, Target = target },
            new Plane{CallSign="Wz1533", Company= "Wizz Air", Model="Airbus A700", Status="In Air", FlightPlan = flightPlans[0], Position = positionStated, Target = target },
            new Plane{CallSign="Rn1634", Company= "Ryan Air", Model="Airbus A301", Status="In Air", FlightPlan = flightPlans[0], Position = positionStated, Target = target },
            new Plane{CallSign="Rn3359", Company= "Ryan Air", Model="Airbus A301", Status="In Air", FlightPlan = flightPlans[0], Position = positionStated, Target = target },
            new Plane{CallSign="Va7433", Company= "Voila", Model="Airbus A320", Status="In Air", FlightPlan = flightPlans[0], Position = positionStated, Target = target },
            new Plane{CallSign="Va9463", Company= "Voila", Model="Airbus A320", Status="In Air", FlightPlan = flightPlans[0], Position = positionStated, Target = target },
            new Plane{CallSign="Ta3759", Company= "Turkish Airlines", Model="Boeing 777", Status="In Air", FlightPlan = flightPlans[0], Position = positionStated, Target = target },
            new Plane{CallSign="Ta6732", Company= "Turkish Airlines", Model="Boeing 777", Status="In Air", FlightPlan = flightPlans[0], Position = positionStated, Target = target }
            };
            var edges = new List<Edge>
            {
                new Edge{FromNodeIndex = 8, ToNodeIndex = 9, Length = 4 },
                new Edge{FromNodeIndex = 0, ToNodeIndex = 4, Length = 2 },
                new Edge{FromNodeIndex = 11, ToNodeIndex = 10, Length = 4 },
                new Edge{FromNodeIndex = 10, ToNodeIndex = 9, Length = 4},
                new Edge{FromNodeIndex = 13, ToNodeIndex = 12, Length = 8},
                new Edge{FromNodeIndex = 12, ToNodeIndex = 10, Length = 4},
                new Edge{FromNodeIndex = 1, ToNodeIndex = 4, Length = 2},
                new Edge{FromNodeIndex = 2, ToNodeIndex = 4, Length = 2},
                new Edge{FromNodeIndex = 3, ToNodeIndex = 4, Length = 2},
                new Edge{FromNodeIndex = 4, ToNodeIndex = 5, Length = 16},
                new Edge{FromNodeIndex = 5, ToNodeIndex = 6, Length = 4},
                new Edge{FromNodeIndex = 5, ToNodeIndex = 13, Length = 8},
                new Edge{FromNodeIndex = 6, ToNodeIndex = 7, Length = 4},
                new Edge{FromNodeIndex = 6, ToNodeIndex = 11, Length = 4},
                new Edge{FromNodeIndex = 7, ToNodeIndex = 8, Length = 4},
                new Edge{FromNodeIndex = 12, ToNodeIndex = 14, Length = 10},
                new Edge{FromNodeIndex = 14, ToNodeIndex = 16, Length = 4},
                new Edge{FromNodeIndex = 16, ToNodeIndex = 17, Length = 4},
                new Edge{FromNodeIndex = 17, ToNodeIndex = 18, Length = 4},
                new Edge{FromNodeIndex = 18, ToNodeIndex = 19, Length = 4},
                new Edge{FromNodeIndex = 19, ToNodeIndex = 5, Length = 4},
                new Edge{FromNodeIndex = 19, ToNodeIndex = 15, Length = 8},
                new Edge{FromNodeIndex = 15, ToNodeIndex = 14, Length = 8}
            };


            var groundNodes = new List<GroundNode>
            {
            new GroundNode{ Name = "Gate A", IsVisited = false, Position = positions[0]},
            new GroundNode{ Name = "Gate B", IsVisited = false, Position = positions[1]},
            new GroundNode{ Name = "Gate C", IsVisited = false, Position = positions[2] },
            new GroundNode{ Name = "Gate D", IsVisited = false, Position = positions[3] },
            new GroundNode{ Name = "Main Taxiway", IsVisited = false, Position = positions[4] },
            new GroundNode{ Name = "Taxiway Chokepoint", IsVisited = false, Position = positions[5] },
            new GroundNode{ Name = "Taxiway A2", IsVisited = false, Position = positions[6] },
            new GroundNode{ Name = "Taxiway A2", IsVisited = false, Position = positions[7] },
            new GroundNode{ Name = "Auxiliary Taxiway C32", IsVisited = false, Position = positions[8] },
            new GroundNode{ Name = "Runway 14", IsVisited = false, Position = positions[9] },
            new GroundNode{ Name = "Runway", IsVisited = false, Position = positions[10] },
            new GroundNode{ Name = "Auxiliary Taxiway C33", IsVisited = false, Position = positions[11] },
            new GroundNode{ Name = "Runway", IsVisited = false, Position = positions[12] },
            new GroundNode{ Name = "Auxiliary Taxiway C34", IsVisited = false, Position = positions[13] },
            new GroundNode{ Name = "Runway", IsVisited = false, Position = positions[14] },
            new GroundNode{ Name = "Auxiliary Taxiway C35", IsVisited = false, Position = positions[15] },
            new GroundNode{ Name = "Runway 25", IsVisited = false, Position = positions[16] },
            new GroundNode{ Name = "Auxiliary Taxiway C36", IsVisited = false, Position = positions[17] },
            new GroundNode{ Name = "Taxiway A2", IsVisited = false, Position = positions[18] },
            new GroundNode{ Name = "Taxiway A2", IsVisited = false, Position = positions[19] }
            };

            /* var nodeEdges = new List<NodeEdge>
             {
                 new NodeEdge{EdgeId = 0, NodeId =8},
                 new NodeEdge{EdgeId = 0, NodeId =9},
                 new NodeEdge{EdgeId = 1, NodeId =0},
                 new NodeEdge{EdgeId = 1, NodeId =4},
                 new NodeEdge{EdgeId = 2, NodeId =10},
                 new NodeEdge{EdgeId = 2, NodeId =11},
                 new NodeEdge{EdgeId = 3, NodeId =9},
                 new NodeEdge{EdgeId = 3, NodeId =10},
                 new NodeEdge{EdgeId = 4, NodeId =12},
                 new NodeEdge{EdgeId = 4, NodeId =13},
                 new NodeEdge{EdgeId = 5, NodeId =10},
                 new NodeEdge{EdgeId = 5, NodeId =12},
                 new NodeEdge{EdgeId = 6, NodeId =1},
                 new NodeEdge{EdgeId = 6, NodeId =4},
                 new NodeEdge{EdgeId = 7, NodeId =2},
                 new NodeEdge{EdgeId = 7, NodeId =4},
                 new NodeEdge{EdgeId = 8, NodeId =3},
                 new NodeEdge{EdgeId = 8, NodeId =4},
                 new NodeEdge{EdgeId = 9, NodeId =4},
                 new NodeEdge{EdgeId = 9, NodeId =5},
                 new NodeEdge{EdgeId = 10, NodeId =5},
                 new NodeEdge{EdgeId = 10, NodeId =6},
                 new NodeEdge{EdgeId = 11, NodeId =5},
                 new NodeEdge{EdgeId = 11, NodeId =13},
                 new NodeEdge{EdgeId = 12, NodeId =7},
                 new NodeEdge{EdgeId = 12, NodeId =6},
                 new NodeEdge{EdgeId = 13, NodeId =11},
                 new NodeEdge{EdgeId = 13, NodeId =6},
                 new NodeEdge{EdgeId = 14, NodeId =7},
                 new NodeEdge{EdgeId = 14, NodeId =8},
                 new NodeEdge{EdgeId = 15, NodeId =12},
                 new NodeEdge{EdgeId = 15, NodeId =14},
                 new NodeEdge{EdgeId = 16, NodeId =14},
                 new NodeEdge{EdgeId = 16, NodeId =16},
                 new NodeEdge{EdgeId = 17, NodeId =16},
                 new NodeEdge{EdgeId = 17, NodeId =17},
                 new NodeEdge{EdgeId = 18, NodeId =17},
                 new NodeEdge{EdgeId = 18, NodeId =18},
                 new NodeEdge{EdgeId = 19, NodeId =18},
                 new NodeEdge{EdgeId = 19, NodeId =19},
                 new NodeEdge{EdgeId = 20, NodeId =19},
                 new NodeEdge{EdgeId = 20, NodeId =5}
             };*/

             var nodeEdges = new List<NodeEdge>
            {
                new NodeEdge{EdgeId = 1, NodeId =9},
                new NodeEdge{EdgeId = 1, NodeId =10},
                new NodeEdge{EdgeId = 2, NodeId =1},
                new NodeEdge{EdgeId = 2, NodeId =5},
                new NodeEdge{EdgeId = 3, NodeId =11},
                new NodeEdge{EdgeId = 3, NodeId =12},
                new NodeEdge{EdgeId = 4, NodeId =10},
                new NodeEdge{EdgeId = 4, NodeId =11},
                new NodeEdge{EdgeId = 5, NodeId =13},
                new NodeEdge{EdgeId = 5, NodeId =14},
                new NodeEdge{EdgeId = 6, NodeId =11},
                new NodeEdge{EdgeId = 6, NodeId =13},
                new NodeEdge{EdgeId = 7, NodeId =2},
                new NodeEdge{EdgeId = 7, NodeId =5},
                new NodeEdge{EdgeId = 8, NodeId =3},
                new NodeEdge{EdgeId = 8, NodeId =5},
                new NodeEdge{EdgeId = 9, NodeId =4},
                new NodeEdge{EdgeId = 9, NodeId =5},
                new NodeEdge{EdgeId = 10, NodeId =5},
                new NodeEdge{EdgeId = 10, NodeId =6},
                new NodeEdge{EdgeId = 11, NodeId =6},
                new NodeEdge{EdgeId = 11, NodeId =7},
                new NodeEdge{EdgeId = 12, NodeId =6},
                new NodeEdge{EdgeId = 12, NodeId =14},
                new NodeEdge{EdgeId = 13, NodeId =8},
                new NodeEdge{EdgeId = 13, NodeId =7},
                new NodeEdge{EdgeId = 14, NodeId =12},
                new NodeEdge{EdgeId = 14, NodeId =7},
                new NodeEdge{EdgeId = 15, NodeId =8},
                new NodeEdge{EdgeId = 15, NodeId =9},
                new NodeEdge{EdgeId = 16, NodeId =11},
                new NodeEdge{EdgeId = 16, NodeId =15},
                new NodeEdge{EdgeId = 17, NodeId =15},
                new NodeEdge{EdgeId = 17, NodeId =17},
                new NodeEdge{EdgeId = 18, NodeId =17},
                new NodeEdge{EdgeId = 18, NodeId =18},
                new NodeEdge{EdgeId = 19, NodeId =18},
                new NodeEdge{EdgeId = 19, NodeId =19},
                new NodeEdge{EdgeId = 20, NodeId =19},
                new NodeEdge{EdgeId = 20, NodeId =20},
                new NodeEdge{EdgeId = 21, NodeId =20},
                new NodeEdge{EdgeId = 21, NodeId =6}
            };

            foreach (Position position in positions)
            {
                context.Add(position);
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

            foreach (GroundNode groundNode in groundNodes)
            {
                context.Add(groundNode);
            }
            context.SaveChanges();
            foreach (Edge edge in edges)
            {
                context.Add(edge);

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