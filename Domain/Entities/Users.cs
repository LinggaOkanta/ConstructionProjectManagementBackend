using System;

namespace ConstructionProjectManagement.Domain.Entities
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
