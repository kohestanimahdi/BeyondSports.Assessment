using BeyondSports.Assessment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Domain.Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException(string message)
           : base(ApiResultStatusCode.NotFound, message)
        {
        }
    }
}
