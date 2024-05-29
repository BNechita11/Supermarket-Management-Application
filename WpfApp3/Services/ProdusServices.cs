using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using Microsoft.Data.SqlClient;
using WpfApp3.DataBase;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    public class ProdusService
    {

        public ProdusService(MagazinContextDb context)
        {
        }

        public void AdaugaProdus(Produs produs)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                context.Set<Produs>().Add(produs);
                context.SaveChanges();
            }
        }

        public void StergeProdus(int produsId)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
               context.Database.ExecuteSqlRaw("EXEC [dbo].[DeleteProduct] @ProdusId = {0}", produsId);
            }
        
        }

        public List<Produs> GetProduse()
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                return context.Produs.ToList();
            }
        }

        public void ActualizeazaProdus(Produs produs)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                var produsExistent = context.Produs.Find(produs.ProdusId);
                if (produsExistent != null)
                {
                    produsExistent.Nume = produs.Nume;
                    produsExistent.CodDeBare = produs.CodDeBare;
                    produsExistent.PretNormal = produs.PretNormal;
                    produsExistent.PretRedus = produs.PretRedus;
                    produsExistent.CategorieId = produs.CategorieId;
                    produsExistent.ProducatorId = produs.ProducatorId;
                    produsExistent.IsActive = produs.IsActive;

                    context.SaveChanges();
                }
            }
        }
        public List<Produs> GetProduseByProducator(int producatorId)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                var produse = context.Produs.Where(p => p.ProducatorId == producatorId).ToList();
                return produse;
            }
        }
        public List<Produs> GetProduseByName(string searchQuery)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                return context.Produs
                .Where(p => p.Nume.Contains(searchQuery))
                .ToList();
            }
        }
        // Metodă pentru a apela procedura stocată și a returna rezultatele
        public List<Produs> SearchProducts(string nume, string codDeBare, DateTime? dataExpirarii, int? producatorId, int? categorieId)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                var numeParam = new SqlParameter("@Nume", nume ?? (object)DBNull.Value);
                var codDeBareParam = new SqlParameter("@CodDeBare", codDeBare ?? (object)DBNull.Value);
                var producatorIdParam = new SqlParameter("@ProducatorId", producatorId ?? (object)DBNull.Value);
                var categorieIdParam = new SqlParameter("@CategorieId", categorieId ?? (object)DBNull.Value);

                var result = context.Produs.FromSqlRaw("EXEC SearchProducts @Nume, @CodDeBare, @ProducatorId, @CategorieId",
                    numeParam, codDeBareParam, producatorIdParam, categorieIdParam).ToList();

                return result;
            }
        }
    }
}
