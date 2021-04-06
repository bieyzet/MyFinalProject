using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
        //IEntity veya implementleri olabılır ama new() ekledıkten sonra IEntity eklenmez artık.
        //Cunku burda newlenebilr olanları da istedik

    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null); 
        //filtre vermeyebilirsin manasına gelıyor yani tüm datayı veriyor.
        T Get(Expression<Func<T, bool>> filter );//filtremeler, eticaret sitelerinde oldugu gibi 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       
    }
}
