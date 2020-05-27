using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace bioResearchSystem.ВLL.DomainModels.DeviceModule
{
    public class SerialPortBuilder
    {
        private SerialPort serialPort;
        public bool IsConfigured { get; private set; }
        public SerialPortBuilder()
        {
            serialPort = new SerialPort();
            
        }

        public SerialPortBuilder SetPortName(string portName) {
            serialPort.PortName = portName;
            return this;
        }

        public SerialPortBuilder SetBoundRate(int portNumber) {
            serialPort.BaudRate = portNumber;
            return this;
        }
        public SerialPort Build() {
            IsConfigured = true;
            return serialPort;
        }
    }
}
