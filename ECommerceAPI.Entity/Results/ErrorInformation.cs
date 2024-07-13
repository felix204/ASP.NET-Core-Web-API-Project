using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Entity.Results
{
    public class ErrorInformation
    {
        public object? Error { get; set; }
        public string ErrorDescription { get; set; }

        public static ErrorInformation NotFound(string errorInformation= "Sonuç Bulunamadı", object? error=null) 
        {
            return new ErrorInformation() { ErrorDescription = errorInformation, Error = error };
        }

        public static ErrorInformation Errors(object? error = null, string errorDescription = "Hata Oluştu.")
        {
            return new ErrorInformation() { ErrorDescription = errorDescription, Error = null };
        }

        public static ErrorInformation FieldValidationError(object? error= null, string errorDescription = "Zorunlu Alanlar Eksik")
        {
            return new ErrorInformation { Error = error, ErrorDescription = errorDescription };
        }

        public static ErrorInformation TokenNotFoundError(object? error = null, string errorDescription = "Token Bilgisi Bulunamadı")
        {
            return new ErrorInformation { Error = error, ErrorDescription = errorDescription };
        }

        public static ErrorInformation TokenValidationError(object? error = null, string errorDescription = "Token Geçerli Değil")
        {
            return new ErrorInformation { Error = error, ErrorDescription = errorDescription };
        }
    }
}
