using Microsoft.AspNetCore.Identity;

namespace Gastos.Models
{
    public class ErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError()
        {
            return new IdentityError() { Code = nameof(DefaultError), Description = "Algo salio mal, contacta al administrador." };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError() { Code = nameof(DuplicateEmail), Description = $"El email {email} esta siendo usado por otro usuario." };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError() { Code = nameof(DuplicateUserName), Description = $"El nombre de usuario {userName} esta siendo usado por otro usuario." };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError() { Code = nameof(InvalidEmail), Description = $"El email proporcionado es invalido." };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError() { Code = nameof(InvalidUserName), Description = "El nombre de usuario proporcionado es invalido." };
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError() { Code = nameof(LoginAlreadyAssociated), Description = "La cuenta proporcionada esta asociada a otro usuario." };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError() { Code = nameof(PasswordMismatch), Description = "Las contraseñas no coinciden." };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError() { Code = nameof(PasswordRequiresDigit), Description = "La contraseña debe contener al menos 1 número." };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError() { Code = nameof(PasswordRequiresLower), Description = "La contraseña debe contener al menos 1 minúscula." };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError() { Code = nameof(PasswordRequiresUpper), Description = "La contraseña debe contener al menos 1 mayúscula." };
        }        
    }
}
