using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InHouseApp.EntityModel.BusinessEntity;

namespace InHouseApp.DataAccess
{
    public interface IProductRepository
    {
        IList<Product> GetProducts();

        IList<Product> GetProducts(string searchContent);

        Product GetProductById(int Id);

        bool SaveAndUpdate(Product product);

        bool DeleteProduct(int productID);

    }
}
