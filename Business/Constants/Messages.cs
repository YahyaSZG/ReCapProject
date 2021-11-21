using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "";
        public static string CarNameInvalid = "";
        public static string CarListed = "";
        public static string UserRegistered = "";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola doğru değil";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "Access token oluşturuldu";
        public static string AuthorizationDenied = "";
        public static string ProductUpdated = "";
    }
}
