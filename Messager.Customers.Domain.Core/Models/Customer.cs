using System;

namespace Messager.Customers.Domain.Core.Models
{
    public class Customer
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string CustomerTag { get; set; } //tag for search
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}
