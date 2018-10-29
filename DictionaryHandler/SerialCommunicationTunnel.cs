using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DictionaryHandler
{
  public  class SerialCommunicationTunnel
    {
        SerialPort serialPort = new SerialPort();
        public SerialCommunicationTunnel()
        {
            if (!serialPort.IsOpen)
            {
                serialPort.PortName = "COM9";
                serialPort.Handshake = Handshake.None;
                serialPort.BaudRate = 57600;
                serialPort.Handshake = Handshake.None;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.ReadTimeout = 200;
                serialPort.WriteTimeout = 50;
                serialPort.Open();
            }
        }
       
        public async Task<string> SelectedParameterValueGetter(string ConfigurationString)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
            var counter = 0;
            serialPort.Write("$" + ConfigurationString);
            string ResponseString = "";
            await Task.Delay(500);
            ResponseString = serialPort.ReadExisting();
            while  (ResponseString == "")
            {
                ResponseString = serialPort.ReadExisting();
                counter++;
                if (counter == 5)
                {
                    serialPort.Dispose();
                    return ResponseString = "AA'No Response From the device side';";
                    
                }
            }
            //Add Check if the string is formated properly;;
            return ResponseString;
        }
    }
}
