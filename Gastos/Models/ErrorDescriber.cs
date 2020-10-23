using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Models
{
    public class ErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError() { Code = nameof(DuplicateEmail), Description = "El email esta siendo usado por otro usuario." };
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError() { Code = nameof(LoginAlreadyAssociated), Description = "El email esta siendo usado por otro usuario." };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = "El email esta siendo usado por otro usuario." };
        }
    }
}
