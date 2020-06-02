using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InHouseApp.EntityModel.BusinessEntity;


namespace InHouseApp.DataAccess
{
    public class ProductsDBContext : DbContext
    {
        public ProductsDBContext() : base("name=ProductDbConnection") { }

        public DbSet<Product> Products { get; set; }
    }
}
