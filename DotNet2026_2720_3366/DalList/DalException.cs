using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalException:Exception
    {
        public class DalIdNotExistsException : Exception
        {
            public DalIdNotExistsException(string message) : base(message) { }

            public DalIdNotExistsException(string message, Exception innerExcepion) : base(message, innerExcepion) { }

        }

        public class DalIdAlreadyExistsException : Exception
        {
            public DalIdAlreadyExistsException(string message) : base(message) { }

            public DalIdAlreadyExistsException(string message, Exception innerExcepion) : base(message, innerExcepion) { }

        }
    }
}
