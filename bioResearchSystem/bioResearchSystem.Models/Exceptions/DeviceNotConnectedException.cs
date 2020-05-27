using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.Models.Exceptions
{
    public class DeviceNotConnectedException:Exception
    {
        public DeviceNotConnectedException(string message):base(message)
        {

        }
    }
}
