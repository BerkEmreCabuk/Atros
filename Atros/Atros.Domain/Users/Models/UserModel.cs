using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Domain.Users.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public void WithoutPassword()
        {
            this.Password = null;
        }
    }
}
