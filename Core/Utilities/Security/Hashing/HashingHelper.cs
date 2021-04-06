using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //register islemi esnasında olusturulur.(password veririyoruz.)salt isleminide burada yapıyoruz.
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash,out byte[] passwordSalt)//out ile bos girilen degerleri dolu gönderebiliyoruz. 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//Password'u byte olarak vermemiz icin encoding yaptık.
            }
        }

        //login islemi esnasında varolan (registerda olusturulan) passwordSalt ile burada dogrulama islemi yapılır.
        public static bool VerifyPasswordHash(string password,byte [] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
