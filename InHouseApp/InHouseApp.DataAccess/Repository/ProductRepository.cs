using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InHouseApp.EntityModel.BusinessEntity;
using InHouseApp.DataAccess;
using System.Data.Entity.Migrations;

namespace InHouseApp.DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ProductsDBContext productsDBContext;

        public ProductRepository(ProductsDBContext productsDB)
        {
            productsDBContext = productsDB;
        }

        public Product GetProductById(int id)
        {
            var product = (from result in productsDBContext.Products
                           where result.ProductID == id
                           select result);
            if (product != null)
                return product.FirstOrDefault();
            return null;
        }

        public bool DeleteProduct(int productID)
        {
            try
            {
                var product = (from result in productsDBContext.Products
                               where result.ProductID == productID
                               select result).FirstOrDefault();
                if (product != null)
                {
                    productsDBContext.Products.Remove(product);
                    productsDBContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IList<Product> GetProducts()
        {
            try
            {
                var productList = (from resultSet in productsDBContext.Products
                                   select resultSet);
                if (productList != null && productList.Count() > 0)
                    return productList.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public IList<Product> GetProducts(string searchKey)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchKey))
                {
                    var productList = (from searchResult in productsDBContext.Products
                                       where searchResult.ProductName.Contains(searchKey)
                                       || searchResult.ProductType.Contains(searchKey)
                                       || searchResult.ProductDesc.Contains(searchKey)
                                       || searchResult.SKUNumber.Contains(searchKey)
                                       select searchResult);

                    if (productList != null && productList.Count() > 0)
                        return productList.ToList();
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public bool SaveAndUpdate(Product product)
        {
            try
            {
                if (product.ProductID.HasValue && product.ProductID.Value > 0)
                {
                    var dbProduct = (from result in productsDBContext.Products
                                     where result.ProductID == product.ProductID
                                     select result).FirstOrDefault();

                    if(dbProduct != null)
                    {
                        dbProduct.ProductName = product.ProductName;
                        dbProduct.ProductType = product.ProductType;
                        dbProduct.ProductDesc = product.ProductDesc;
                        dbProduct.StarRating = product.StarRating;
                        dbProduct.Stock = product.Stock;
                        dbProduct.UnitPrice = product.UnitPrice;
                        dbProduct.SKUNumber = product.SKUNumber;
                        dbProduct.ImageUrl = product.ImageUrl;

                        productsDBContext.Products.AddOrUpdate(dbProduct);
                    }
                }else
                    productsDBContext.Products.AddOrUpdate(product);

                productsDBContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
