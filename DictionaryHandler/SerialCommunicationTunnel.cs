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
        public string SelectedParameterValueGetter(string ConfigurationString)
        {
            
            serialPort.Write("$" + ConfigurationString);
            Thread.Sleep(222);
            string ResponseString = "";
            ResponseString = serialPort.ReadExisting();
            while(ResponseString == "")
            {
               
                ResponseString = serialPort.ReadExisting();
            }
            return ResponseString;

        }

    }
}
