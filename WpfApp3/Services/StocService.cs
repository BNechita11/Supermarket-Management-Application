using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using WpfApp3.DataBase;
using WpfApp3.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace WpfApp3.Services
{
    public class StocService
    {

        public StocService(MagazinContextDb context)
        {
        }

        public void AdaugaStoc(Stoc stoc)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                context.Database.ExecuteSqlRaw(
                    "EXEC InsertStoc @p0, @p1, @p2, @p3, @p4, @p5, @p6",
                    stoc.ProdusId,
                    stoc.Cantitate,
                    stoc.UnitateDeMasura,
                    stoc.DataAprovizionarii,
                    stoc.DataExpirarii,
                    stoc.PretAchizitie,
                    stoc.IsActive
                );
            }
        }

        public void ActualizeazaStoc(Stoc stoc)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                var stocExistent = context.Stoc.Find(stoc.StocId);
                if (stocExistent == null) throw new Exception("Stocul nu a fost găsit.");

                stocExistent.Cantitate = stoc.Cantitate;
                stocExistent.UnitateDeMasura = stoc.UnitateDeMasura;
                stocExistent.DataAprovizionarii = stoc.DataAprovizionarii;
                stocExistent.DataExpirarii = stoc.DataExpirarii;
                stocExistent.PretVanzare = stoc.PretVanzare;
                stocExistent.PretAchizitie = stoc.PretAchizitie;

                context.SaveChanges();
            }
        }

        public void StergeStoc(int stocId)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                context.Database.ExecuteSqlRaw("EXEC [dbo].[DeleteStoc] @StocId = {0}", stocId);

            }
        }

        public List<Stoc> GetStocuri()
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                return context.Stoc.ToList();
            }
        }
        public Dictionary<int, decimal> GetProduseCuCantitati()
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                var stocuri = context.Stoc.ToList();
                var produseCuCantitati = new Dictionary<int, decimal>();

                foreach (var stoc in stocuri)
                {
                    if(!produseCuCantitati.ContainsKey(stoc.ProdusId))
                    {
                        produseCuCantitati.Add(stoc.ProdusId, stoc.Cantitate); 
                    }
                }

                return produseCuCantitati;
            }
        }

    }
}
