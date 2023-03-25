using TruckManager.Domain.Common.Models;
using TruckManager.Domain.UserAggregate.ValueObjects;

namespace TruckManager.Domain.UserAggregate
{
    public class UserAggregate : AggregateRoot<UserId>
    {
        public UserAggregate(UserId userId, string firstName, string lastName, string email, string password, DateTime updateDateTime, DateTime createdDateTime)
            : base(userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UpdateDateTime = updateDateTime;
            CreatedDateTime = createdDateTime;
        }

        public string FirstName { get; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime UpdateDateTime { get; }

        public DateTime CreatedDateTime { get; }
    }
}
