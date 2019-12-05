using Microsoft.EntityFrameworkCore;
using SEP3_TIER3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_TIER3.Database
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-VF4OOIP\SQLEXPRESS;Database=Database;Trusted_Connection=True;");
            //System.Data.Entity.Database.Delete(@"Server=DESKTOP-6MHDJSO\SQLEXPRESS;Database=Database;Trusted_Connection=True;");
        }

        public DbSet<Plane> Planes { get; set; }
        public DbSet<FlightPlan> FlightPlans { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Edge> Edges { get; set; }
        public DbSet<GroundNode> GroundNodes { get; set; }
        public DbSet<NodeEdge> NodeEdges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroundNode>().HasKey("NodeId");
            modelBuilder.Entity<GroundNode>().Property(p => p.NodeId).ValueGeneratedNever();
            modelBuilder.Entity<Edge>().HasKey("EdgeId");
            modelBuilder.Entity<Edge>().Property(p => p.EdgeId).ValueGeneratedNever();
            modelBuilder.Entity<FlightPlan>().HasKey("Id");
            modelBuilder.Entity<Position>().HasKey("XCoordinate", "YCoordinate");

            modelBuilder.Entity<NodeEdge>()
                .HasKey(nodeEdge => new { nodeEdge.EdgeId, nodeEdge.NodeId });

            modelBuilder.Entity<NodeEdge>()
                .HasOne(nodeEdge => nodeEdge.Edge)
                .WithMany(edge => edge.NodeEdges)
                .HasForeignKey(nodeEdge => nodeEdge.EdgeId);

            modelBuilder.Entity<NodeEdge>()
                .HasOne(nodeEdge => nodeEdge.GroundNode)
                .WithMany(groundNode => groundNode.NodeEdges)
                .HasForeignKey(nodeEdge => nodeEdge.NodeId);
        }
    }
}