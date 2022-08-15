using System;

namespace Messager.Customers.Application.Services.DataTransferObjects
{
    public class CustomerForUpdateDto
    {
        public string UserName { get; set; }
        public string CustomerTag { get; set; } //tag for search
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string IconImageSrc { get; set; }
    }
}
