using System.Runtime.Serialization;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;

namespace Business.Constants
{
    public static class Messages//kalıtıma ıhtıyac duymamak ıcın 
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz!";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string Deleted = "Ürün silme başarılı!";

        public static string ProductCountOfCategoryError = "Ürün adedi hatalı!";
        
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için ekleme yapılamaz!";
        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
    }

    
}
