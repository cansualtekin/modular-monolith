using Example.Platform.Persistence;
using Example.SharedKernel.Enums;

namespace Example.User.Domain.Entities
{
    public class UserEntity : EntityBase<long>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte Age { get; set; }

        public string EmailAddress { get; set; }

        public Gender Gender { get; set; }
    }
}
