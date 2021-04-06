using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voıdler ıcın baslangic
    public interface IResult
    {
        bool Success { get; }//bu programa
        string Message { get; }//bu da kullanııcıya cevap veriyor

    }
}
