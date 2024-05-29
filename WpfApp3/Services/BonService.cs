using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WpfApp3.DataBase;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    public class BonService
    {

        public BonService(MagazinContextDb context)
        {
        }

        public void AdaugaBon(BonCasa bon)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {

                context.Set<BonCasa>().Add(bon);
                context.SaveChanges();
            }
        }

        public void StergeBon(int bonId)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                try
                {
                    context.Database.ExecuteSqlRaw("EXEC sp_DeleteBonCasa @p0", bonId);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Eroare la ștergerea bonului: {ex.Message}");
                }
            }
        }

        public void ActualizeazaBon(BonCasa bon)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                try
                {
                    var bonExistent = context.BonCasa.Find(bon.BonCasaId);
                    if (bonExistent != null)
                    {
                        bonExistent.DataEliberarii = bon.DataEliberarii;
                        bonExistent.CasierId = bon.CasierId;
                        bonExistent.SumaIncasata = bon.SumaIncasata;
                        bonExistent.isActive = bon.isActive;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Bonul nu a fost găsit în baza de date.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Eroare la actualizarea bonului: {ex.Message}");
                }
            }
            }
        public List<BonCasa> GetBonuri()
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                return context.BonCasa.ToList();
            }
        }

        public void GetCelMaiMareBon(DateTime dataSelectata)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                var dataParam = new SqlParameter("@DataSelectata", dataSelectata);
                context.Database.ExecuteSqlRaw("EXEC GetBiggestBon @DataSelectata", dataParam);

            }
        }
        public decimal GetProductPrice(int productId)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                var product = context.Produs.FirstOrDefault(p => p.ProdusId == productId);
                if (product == null)
                {
                    throw new InvalidOperationException("Product not found.");
                }
                return product.PretNormal;
            }
        }

    }
}

