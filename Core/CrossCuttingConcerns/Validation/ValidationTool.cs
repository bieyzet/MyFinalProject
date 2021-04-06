using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public  class ValidationTool//suanda ProductValidator ile çalışıyor.
    //yaptıgı iş sadece validator  dogrulama kodlarınsda hata alırsa hata fırlatıyor.
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            //ProductValidator productValidator=new ProductValidator();
            var result = validator.Validate(context);//productValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
