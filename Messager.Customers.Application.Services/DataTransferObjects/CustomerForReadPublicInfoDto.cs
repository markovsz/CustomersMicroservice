using System;

namespace Messager.Customers.Application.Services.DataTransferObjects
{
    public class CustomerForReadPublicInfoDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string CustomerTag { get; set; } //tag for search
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
