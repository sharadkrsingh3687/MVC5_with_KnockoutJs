using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using InHouseApp.DataAccess;
using InHouseApp.WebPortal.Models;
using InHouseApp.DataAccess.Repository;
using InHouseApp.EntityModel.BusinessEntity;
using System.Web.Helpers;

namespace InHouseApp.WebPortal.Controllers
{
    public class ProductController : Controller
    {
        private ProductModel productModel = null;
        private IProductRepository productRepository = null;

        public ProductController()
        {
            this.productRepository = new ProductRepository(new ProductsDBContext());
        }

        [HttpGet]
        public ActionResult Products()
        {
            if (this.productModel == null)
                this.productModel = new ProductModel();

            this.productModel.ProductList = productRepository.GetProducts();
            return View("ProductsPage", this.productModel);
        }

        [HttpPost]
        public ActionResult Products(string SearchProduct)
        {
            if (!string.IsNullOrEmpty(SearchProduct))
            {
                if (this.productModel == null)
                    this.productModel = new ProductModel();

                this.productModel.SearchProduct = SearchProduct;
                this.productModel.ProductList = productRepository.GetProducts(SearchProduct);
                return View("ProductsPage", this.productModel);
            }
            return View("ProductsPage", new ProductModel());
        }
        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if(id.HasValue)
            {
                productModel = new ProductModel();
                productModel.Product = productRepository.GetProductById(id.Value);
                if (productModel.Product != null)
                {
                    productModel.IsEditMode = true;
                    return View("EditProductPage", productModel);
                }
            }
            return View("EditProductPage", new ProductModel());
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            productModel = new ProductModel();
            productModel.Product = new Product();
            productModel.IsEditMode = false;
            return View("EditProductPage", productModel);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            bool status = false;
            if(product != null)
            {
                if (product.ProductID > 0)
                {
                    product.ModifiedBy = "User";
                    product.ModifiedOn = DateTime.UtcNow;
                }
                else
                {
                    product.CreatedBy = "User"; // in future we will use data from HttpContext.
                    product.CreatedOn = DateTime.UtcNow;
                    product.ModifiedBy = "User";
                    product.ModifiedOn = DateTime.UtcNow;
                }

                status = productRepository.SaveAndUpdate(product);
                if (status)
                    return Json(new { status = "success" });
                return Json(new { status = "fail" });
            }
            return Json(new { status = "fail" });
        }

        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            bool status = false;
            if(productId > 0)
            {
                status = productRepository.DeleteProduct(productId);
                if (status)
                    return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
                return Json(new { status = "fail" }, JsonRequestBehavior.DenyGet);
            }
            return Json(new { status = "fail" }, JsonRequestBehavior.DenyGet);
        }
    }
}