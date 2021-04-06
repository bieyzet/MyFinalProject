using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //Securit Key, appsettings'de olusturdugum tokenOptions yani bu bir registerClaim'dir.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }//Security Key'i JWT'nin anlayacagı bir dile cevirdik.
}
