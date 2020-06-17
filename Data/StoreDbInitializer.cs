using System.Collections.Generic;
using assignment_5.Models;

namespace assignment_5.Data
{
    public class StoreDbInitializer
    {
        public static void Initialize(StoreDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            context.Event.AddRange(new List<Signup>
                {
                    new Signup("Knut", "knut@olsen.no", 12),
                    new Signup("Lise", "lise@larsen.no", 54)
                }
                );
           
            context.SaveChanges(); 
        }
    }
}