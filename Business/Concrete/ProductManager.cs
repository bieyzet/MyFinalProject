using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.BusinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Business;


namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }


        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 9)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>
                (Messages.ProductsListed, _productDal.GetAll());

        }
        [CacheAspect]
        [PerformanceAspect(5)]//çalışma süresi 5 sn yeyi gecerse beni uyar demek.
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>
                (_productDal.Get(p => p.ProductId == productId));
        }

        //claim
        [SecuredOperation("product.add,admin")]
        //[CacheRemoveAspect("IProductService.Get")]
        [ValidationAspect(typeof(ProductValidator))]
        
        public IResult Add(Product product)
        {
            //Aynı isimde ürün eklenemez.
            //Eger mevcut kategori sayısı 15i gectiyse sisteme yeni ürün eklenemez.

            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExists(product),_categoryService.CheckIfCategoryLimitExceded());
            if (result != null)
            {
                return result;
            }


            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);



        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
           return new SuccessResult("Ürün güncellendi.");
        }
        //[CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.Deleted);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);
            if (product.UnitPrice < 10)
            {
                throw new Exception("");
            }

            Add(product);
            return null;
        }


        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll
                (p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll
                (p => p.UnitPrice >= min && p.UnitPrice <= max));

        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            //if (DateTime.Now.Hour==15)
            //{
            //    return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<ProductDetailDto>>
                (_productDal.GetProductDetails());
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result > 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(Product product)
        {
            var result = _productDal.GetAll(p => p.ProductName == product.ProductName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();

        }

       
        
    }
}
