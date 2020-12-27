using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogImplementation.Models
{
    public class SerilogTestModel
    {
        public void ThroughException()
        {
            throw new Exception("Error occurred from SerilogTestModel->ThroughException");
        }
    }
}
