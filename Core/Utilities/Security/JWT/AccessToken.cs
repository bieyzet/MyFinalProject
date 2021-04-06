using System;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }//hasleenmiş securtykey(şifrelenmmiş veri)
        public DateTime Expiration { get; set; }
    }//her login isleminden sonra headera konulacak tokendır yeni anhtarımız bu.
}
