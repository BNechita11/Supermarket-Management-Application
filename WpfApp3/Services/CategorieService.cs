using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using WpfApp3.DataBase;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    public class CategorieService
    {

        public CategorieService(MagazinContextDb context)
        {
        }

        public void AdaugaCategorie(Categorie categorie)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                context.Database.ExecuteSqlRaw("InsertCategory @p0, @p1",
                    parameters: [categorie.Nume, categorie.IsActive]);
            }
        }

        public void StergeCategorie(int categorieId)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
               context.Database.ExecuteSqlRaw("EXEC [dbo].[DeleteCategory] @CategorieId = {0}", categorieId);

            }
        }

         public List<Categorie> GetCategorii()
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                var categories = context.Categorie.FromSqlRaw("EXEC GetAllCategories").ToList();
                return categories;
            }
        }

        public void ActualizeazaCategorie(Categorie categorie)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                var categorieIdParam = new SqlParameter("@CategorieId", categorie.CategorieId);
                var numeParam = new SqlParameter("@Nume", categorie.Nume);
                var isActiveParam = new SqlParameter("@IsActive", categorie.IsActive);

                context.Database.ExecuteSqlRaw("EXEC UpdateCategories @CategorieId, @Nume, @IsActive",
                                                categorieIdParam, numeParam, isActiveParam);
            }
        }

        public Categorie GetCategorieById(int categorieId)
        {
            using (var context = new MagazinContextFactory().CreateDbContext(new string[] { }))
            {
                try
                {
                    return context.Categorie.FirstOrDefault(c => c.CategorieId == categorieId);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Eroare la obținerea categoriei după ID: {ex.Message}");
                }
            }
        }

    }
}
