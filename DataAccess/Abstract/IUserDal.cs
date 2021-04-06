using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);//join islemi yapıyoruz.
    }
}
