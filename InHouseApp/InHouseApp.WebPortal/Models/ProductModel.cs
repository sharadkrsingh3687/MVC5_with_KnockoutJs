using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using InHouseApp.EntityModel.BusinessEntity;

namespace InHouseApp.WebPortal.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            this.SearchProduct = "";
            this.ProductList = new List<Product>();
            this.IsEditMode = false;
        }
        public bool IsEditMode { get; set; }
        public Product Product { get; set; }
        public string SearchProduct { get; set; }
        public IList<Product> ProductList { get; set; }

    }
}