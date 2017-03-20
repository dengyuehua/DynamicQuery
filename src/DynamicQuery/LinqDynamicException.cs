using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq.Dynamic
{
    public class LinqDynamicException : Exception
    {
        public LinqDynamicException()
        {
        }

        public LinqDynamicException(string message) : base(message)
        {
        }

        public LinqDynamicException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
