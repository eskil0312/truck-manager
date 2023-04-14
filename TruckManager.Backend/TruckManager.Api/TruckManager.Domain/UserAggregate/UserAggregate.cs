using TruckManager.Domain.Common.Models;
using TruckManager.Domain.CompanyAggregate.ValueObjects;
using TruckManager.Domain.UserAggregate.ValueObjects;

namespace TruckManager.Domain.UserAggregate
{
    public class User : AggregateRoot<UserId, Guid>
    {
        private User(UserId userId, string firstName, string lastName, string email, string password, CompanyId companyId, DateTime updateDateTime, DateTime createdDateTime)
            : base(userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UpdateDateTime = updateDateTime;
            CreatedDateTime = createdDateTime;
            CompanyId = companyId;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public CompanyId CompanyId { get; private set; }

        public DateTime UpdateDateTime { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public static User Create(string firstName, string lastName, string email, string password, CompanyId companyId)
        {
            return new(UserId.CreateUnique(), firstName, lastName, email, password, companyId, DateTime.Now, DateTime.Now);
        }

#pragma warning disable CS8618
        private User()
        {
        }
#pragma warning restore CS8618
    }
}
