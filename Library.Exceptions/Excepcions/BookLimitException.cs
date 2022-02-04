using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Exceptions.Excepcions
{
    public class BookLimitException: Exception
    {
        public BookLimitException(string message) : base("LimitBookException: " + message)
        {

        }
    }
}
