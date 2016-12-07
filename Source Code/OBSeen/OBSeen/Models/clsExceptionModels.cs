using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSeen.Models
{
    public class DatabaseErrorException : Exception
    {
        public DatabaseErrorException()
        {

        }

        public DatabaseErrorException(string message) : base(message)
        {

        }

        public DatabaseErrorException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
