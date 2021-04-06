using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
//Succes ve message bilgisi de iceriyor.
    {
        T Data { get; }//type dikkat!(Entity)
    }
}
