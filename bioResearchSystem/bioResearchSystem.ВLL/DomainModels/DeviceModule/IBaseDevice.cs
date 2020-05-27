using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using bioResearchSystem.ВLL.DomainModels.DeviceModule.Biology;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.DomainModels.DeviceModule
{
    public  interface  IBaseDevice
    {
        public SerialPort SerialPort { get; set; }
        public bool InProcess { get; set; }
        public  Task Connect();
        public  Task Disconect();
        public void SetSerialPort(SerialPort serialPort);
        public abstract Task<DnaUnit> LoadDnaSquence(int sizeSequence);
        
        
        
        

    }
}
