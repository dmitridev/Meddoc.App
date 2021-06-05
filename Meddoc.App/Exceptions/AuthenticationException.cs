using System;
using System.Collections.Generic;
using System.Text;

namespace Meddoc.App.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message) : base(message)
        {
        }

        public static AuthenticationException WrongUser()
        {
            AuthenticationException exception = new AuthenticationException("Логин или пароль не совпадают.");
            return exception;
        }

        public static AuthenticationException WrongPasswordConfirm()
        {
            AuthenticationException exception = new AuthenticationException("Пароли не совпадают");
            return exception;
        }
    }
}
