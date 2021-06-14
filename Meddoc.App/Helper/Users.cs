using System;
using System.Collections.Generic;
using System.Text;
using Meddoc.App.Entity;
using MongoDB.Bson;
using Meddoc.App.Exceptions;
using Encryption = BCrypt.Net.BCrypt;
using System.Threading.Tasks;

namespace Meddoc.App.Helper
{
    public class Users
    {
        public static async Task<User> Login(string login, string password)
        {
            User user = null;


            var document = new BsonDocument("Login", login);
            user = await Collection<User>.Load(document);


            if (user == null)
            {
                throw AuthenticationException.WrongUser();
            }

            bool verified = Encryption.Verify(password, user.Password);

            if (!verified)
                throw AuthenticationException.WrongUser();

            return user;
        }

        public static void Register(string login, string email, string password, string passwordConfirm)
        {
            if (!password.Equals(passwordConfirm))
                throw AuthenticationException.WrongPasswordConfirm();

            User user = new User
            {
                Id = ObjectId.GenerateNewId(),
                Login = login,
                Email = email,
                Password = Encryption.HashPassword(password),
            };


            Collection<User>.Save(user);
        }
    }
}
