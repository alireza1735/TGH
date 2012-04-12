using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<TGHEntities>
    {
        protected override void Seed(TGHEntities context)
        {
            var Caegories = new List<Categorie>
            {
                new Categorie {Name = "Paper",Description = "Paper in All Size"},
                new Categorie {Name = "Plastic",Description = "Plastic For Banner"}
            };
            var Products = new List<Product>
            {
                new Product {Name = "A4",Description="13*10",Brand="CopyMax", CategorieID = 1, Enabled= true, Rating=1, RatingNumber=1, ProductStores = new List<ProductStore>{new ProductStore{ SellPrice = 12000, FellowPrice = 10000, BuyPrice=8000, Quantity = 10}}}
            };
        }
    }
}
