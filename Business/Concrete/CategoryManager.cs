using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;//ctor injeksiyon

        public CategoryManager(ICategoryDal categoryDal)
            //categorymanager diyorki ben ıcategorydala baglıyım ama zayıf 
            //baglantı yani sen dataaccessde istedıgın degisiklikleri yap.
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
            
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
            
        }
        public IResult CheckIfCategoryLimitExceded()//13.ders 
        {
            var result = _categoryDal.GetAll();
            if (result.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
