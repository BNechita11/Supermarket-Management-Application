using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using WpfApp3.Models;

namespace WpfApp3.DataBase
{
    public static class Program
    {
        public static void Start()
        {
            var factory = new MagazinContextFactory();
            using (var context = factory.CreateDbContext(Array.Empty<string>()))
            {
                // Adaugă un produs nou dacă nu există
                if (!context.Produs.Any())
                {
                    context.Produs.Add(new Produs { Nume = "Produs nou", CodDeBare = "123456789", CategorieId = 1, ProducatorId = 1 });
                    context.SaveChanges();
                }

                // Afișează stările entităților
                DisplayStates(context.ChangeTracker.Entries());
            }
        }

        static void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State}");
            }
        }
    }
}
