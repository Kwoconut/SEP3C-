using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SEP3_TIER3.Database
{
    class DatabaseManager
    {
        public static void DeleteFlightPlan(AppDbContext context, string callSign)
        {
            context.Database.EnsureCreated();
            if (!context.FlightPlans.Any())
            {
                return;
            }
            var plane = context.Planes.Include(p => p.FlightPlan).Include(p => p.PlanePosition).Single(x => x.FlightPlan.CallSign.Equals(callSign));
            plane.FlightPlan = null;
            context.SaveChanges();
            context.FlightPlans.Remove(context.FlightPlans.Single(p => p.CallSign.Equals(callSign)));
            context.SaveChanges();
        }
    }
}
