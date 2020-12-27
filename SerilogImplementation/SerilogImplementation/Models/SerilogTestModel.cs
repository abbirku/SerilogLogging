using System;

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
