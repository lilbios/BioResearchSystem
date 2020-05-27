using bioResearchSystem.Models.Exceptions;
using bioResearchSystem.ВLL.DomainModels.DeviceModule.Biology;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.DomainModels.DeviceModule
{
    public class DnaSequencer : IBaseDevice
    {
        public SerialPort SerialPort { get; set; }
        public bool InProcess { get; set; }

      

     

        public async  Task Connect()
        {
            await Task.Run(() => SerialPort.Open());
        }

        public async  Task Disconect()
        {
            await Task.Run(() => SerialPort.Close());
        }

        public async Task<DnaUnit> LoadDnaSquence(int sizeSequence)
        {
            if (SerialPort.IsOpen)
            {
                var dnaUnit = new DnaUnit(sizeSequence);
                var result = await Task.Run(() =>
                {

                    while (dnaUnit.DnaLength != sizeSequence)
                    {
                        var generatedData = SerialPort.ReadLine();
                        dnaUnit.ConcatenateNucleobase(generatedData);
                    }
                    return dnaUnit;
                });

                return result;
            }
            else
            {
                throw new DeviceNotConnectedException("Device is not connected!");
            }
        }

        public void SetSerialPort(SerialPort serialPort)
        {
            SerialPort = serialPort;
        }
    }
}
