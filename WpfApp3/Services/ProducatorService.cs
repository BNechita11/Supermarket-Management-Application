using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using WpfApp3.DataBase;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    public class ProducatorService
    {


        public ProducatorService(MagazinContextDb context)
        {

        }

        public void AdaugaProducator(Producator producator)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {

                context.Set<Producator>().Add(producator);
                context.SaveChanges();
            }
        }
        public void StergeProducator(int producatorId)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                context.Database.ExecuteSqlRaw("EXEC [dbo].[DeleteProducer] @ProducatorId = {0}", producatorId);
            }
        }


        public void ActualizeazaProducator(Producator producator)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                var producatorExistent = context.Producator.Find(producator.ProducatorId);
                if (producatorExistent != null)
                {
                    producatorExistent.Nume = producator.Nume;
                    producatorExistent.TaraDeOrigine = producator.TaraDeOrigine;
                    producatorExistent.IsActive = producator.IsActive;
                    context.SaveChanges();
                }
            }
        }

        public List<Producator> GetProducatori()
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                return context.Producator.ToList();
            }
        }
    }
}

