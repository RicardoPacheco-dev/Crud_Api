// Model for error handling on application

namespace CRUD_API.Models
{
       public class ErrorResponse
 {
     public string Title { get; set; }
     public int StatusCode { get; set; }
     public string Message { get; set; }
 }
}