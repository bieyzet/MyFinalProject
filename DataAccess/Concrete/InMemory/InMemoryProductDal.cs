    using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
        //get ve getAll fonk. kafan karısacak kesın
        //ama unutma ki --->>> IProductDal:IEntityRepository den !!!! 
    {

        List<Product> _products;//global degisken
        public InMemoryProductDal()
        {
            _products = new List<Product>{
            new Product {CategoryId=1,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new Product {CategoryId=2,ProductId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
            new Product {CategoryId=3,ProductId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
            new Product {CategoryId=4,ProductId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
            new Product {CategoryId=5,ProductId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            };
        }
        
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete= _products.SingleOrDefault
                (p=>p.ProductId==product.ProductId);
        }


        public void Update(Product product)
        {
            //gonderdıgım urun ıd sıne sahıp olan listedeki urunu bul demektır.
            Product productToUpdate= _products.SingleOrDefault
                (p => p.ProductId == product.ProductId);
            productToUpdate.ProductName= product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
