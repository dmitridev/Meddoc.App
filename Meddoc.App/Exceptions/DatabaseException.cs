using System;
using System.Collections.Generic;
using System.Text;

namespace Meddoc.App.Exceptions
{
    public class DatabaseException :Exception
    {
        public DatabaseException(string message) : base(message)
        {

        }
    }
}
