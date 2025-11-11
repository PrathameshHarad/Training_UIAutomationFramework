using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationApplicationLayer.Models
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string postalCode { get; set; }

    }

    public class UserBuilder
    {
        private readonly User user = new User();

        public UserBuilder WithFirstName(string firstName)
        {
            user.firstName = firstName;
            return this;
        }

        public UserBuilder WithLastName(string lastName)
        {
            user.lastName = lastName;
            return this;
        }

        public UserBuilder WithPostalCode(string postalCode)
        {
            user.postalCode = postalCode;
            return this;
        }

        public User Build()
        {
            return user;
        }
    }
}
