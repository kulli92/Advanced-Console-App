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
          
        }


        public void OpenPort(string Port)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.PortName = Port;
                serialPort.Handshake = Handshake.None;
                serialPort.BaudRate = 57600;
                serialPort.Handshake = Handshake.None;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.ReadTimeout = 200;
                serialPort.WriteTimeout = 50;
                serialPort.DtrEnable = true;
                serialPort.Open();
            }
        }
        public void ClosePort()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        public async Task<string> SelectedParameterValueGetter(string ManullyWrittenShema, short IntervalTime,short Repeat)
        {
            /*
            $GS,<2 bytes Schema ID or buffered Sch length ><2 bytes Interval Time ><2 Bytes Repeat ><Buffered Sch >
            value < 0x8000 indicate to Schema ID 
            else first byte show length of buffered Sch which will be sent in same packet 
            buffered sch max length 128 char 
            included 3B ';'send for continuous Repeat = 0
            to cancel current command send Interval = 0*/
            // Store integer 182
            //int intValue = 182;
            //int intValue;/*
            /*byte[] intBytes = BitConverter.GetBytes(intValue);
             Array.Reverse(intBytes);
             byte[] result = intBytes;*/


            if (serialPort.IsOpen)
            {

                byte[] IntervalTimeArray = BitConverter.GetBytes(IntervalTime);
                //Array.Reverse(IntervalTimeArray);
                byte[] RepeatArray = BitConverter.GetBytes(Repeat);
                char[] CustomSchema = ManullyWrittenShema.ToCharArray();
                byte[] SchemaIdArray = BitConverter.GetBytes((short)(ManullyWrittenShema.Count() + 32768)); //  32768 = 8000
                byte[] PrefixCommand = { 0xAA, 0x55, 0x00, 0x01, 0x01, 0xFF, 0xFF, 0xFF, 0xFF };
                byte[] DataLength = BitConverter.GetBytes((short)(ManullyWrittenShema.Count() + 10));
                //byte DataLength = SchemaIdArray[0];
                byte[] Command = { 0x24, 0x47, 0x53, 0x2c }; // @GS,
                byte[] crc = { 0xAA, 0XEA };//Any crc


                // char[] temparray = FinalFormattedString.ToCharArray();
                serialPort.Write(PrefixCommand, 0, PrefixCommand.Length);
                serialPort.Write(DataLength, 0, 2);
                serialPort.Write(Command, 0, Command.Length);
                serialPort.Write(SchemaIdArray, 0, SchemaIdArray.Count());
                serialPort.Write(IntervalTimeArray, 0, IntervalTimeArray.Count());
                serialPort.Write(RepeatArray, 0, RepeatArray.Count());
                serialPort.Write(CustomSchema, 0, CustomSchema.Count());
                serialPort.Write(crc, 0, crc.Count());
                await Task.Delay(1000);
                string DeviceResponse = serialPort.ReadExisting() + " ";
                return DeviceResponse;
                /*  int x = StaticResponseString.LastIndexOf(';');
                  if (x == -1)
                      x = 0;
                  while (StaticResponseString[x] == 59 && FinalFormattedString.Count() != 0 )
                  {
                      StaticResponseString = serialPort.ReadExisting() + " ";
                  }*/
            }
            // Asking for parameters command
            else
            {
                return "Serial Port is not Open";
            }

        }

        /*{
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
        }*/
    }
}
