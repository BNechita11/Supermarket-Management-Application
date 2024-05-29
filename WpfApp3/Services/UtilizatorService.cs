using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using WpfApp3.DataBase;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    public class UtilizatorService
    {

        public UtilizatorService(MagazinContextDb context)
        {
        }

        public void AddUtilizator(Utilizator utilizator)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                context.Database.ExecuteSqlRaw("BiaInsertUser @p0, @p1, @p2, @p3",
                    parameters: [utilizator.Nume, utilizator.Parola, utilizator.TipUtilizator, utilizator.IsActive]);
            }
        }

        public void UpdateUtilizator(Utilizator utilizator)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                context.Database.ExecuteSqlRaw(
                    "EXEC UpdateUser @p0, @p1, @p2, @p3, @p4",
                    utilizator.UtilizatorId,
                    utilizator.Nume,
                    utilizator.Parola,
                    utilizator.TipUtilizator,
                    utilizator.IsActive
                );
            }
        }

        public void DeleteUtilizator(int utilizatorId)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                context.Database.ExecuteSqlRaw("EXEC [dbo].[BiancaDeleteUser] @UtilizatorId = {0}", utilizatorId);
            }
        }

        public List<Utilizator> GetUtilizatori()
        {
            var utilizatori = new List<Utilizator>();

            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                var utilizatoriParam = new SqlParameter("@utilizatori", System.Data.SqlDbType.Structured);
                utilizatoriParam.Value = utilizatori;
                utilizatoriParam.TypeName = "dbo.Utilizator"; 

                var results = context.Utilizator.FromSqlRaw("EXEC GetAllUsers").ToList();

                return results;
            }
        }
    }
}