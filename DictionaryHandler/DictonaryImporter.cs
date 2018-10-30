﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace DictionaryHandler
{
    public class DictonaryImporter
    {
        public static Dictionary<string, Parameter> ParamDic = new Dictionary<string, Parameter> { };
        public static Dictionary<string, Parameter> ParamObjectRelatedDic = new Dictionary<string, Parameter> { };
        static Dictionary<string, ParameterObject> ObjectDic = new Dictionary<string, ParameterObject> { };
       // readonly string data;
        static public bool DictionaryHasBeenInitilized { get; set; } = false;
        public static SerialCommunicationTunnel Tunnel { get; set; } = new SerialCommunicationTunnel();
        //------------------------------------------
        public static void ParameterDicInitilizer()
        {
            DictionaryHasBeenInitilized = true;
            var package = new ExcelPackage(new FileInfo(@"C:\Users\Aklli\Desktop\ParamsDic08082018.xlsx"));
            ExcelWorksheet sheet = package.Workbook.Worksheets[1];
            for (int i = 1; i < 419; i++)
            {
                ParamDic.Add(sheet.Cells["A" + i].Value.ToString(),
                new Parameter()
                {
                    ParamName = sheet.Cells["B" + i].Value.ToString(),
                    Index = Convert.ToInt16(sheet.Cells["G" + i].Value.ToString()),
                    MemoryAddress = sheet.Cells["F" + i].Value.ToString(),
                    MinValue = sheet.Cells["C" + i].Value.ToString(),
                    MaxValue = sheet.Cells["D" + i].Value.ToString(),
                });
               ParamObjectRelatedDic.Add(sheet.Cells["A" + i].Value.ToString(),
               new Parameter()
               {
                   ParamName = sheet.Cells["B" + i].Value.ToString(),
                   Index = Convert.ToInt16(sheet.Cells["G" + i].Value.ToString()),
                   MemoryAddress = sheet.Cells["F" + i].Value.ToString(),
                   MinValue = sheet.Cells["C" + i].Value.ToString(),
                   MaxValue = sheet.Cells["D" + i].Value.ToString(),
               });
            }
            var package2 = new ExcelPackage(new FileInfo(@"C:\Users\Aklli\Desktop\Object Dic.xlsx"));
            ExcelWorksheet sheet2 = package2.Workbook.Worksheets[1];
            for (int i = 1; i < 21; i++)
            {
                ObjectDic.Add(sheet2.Cells["A" + i].Value.ToString(),
                new ParameterObject()
                {
                    Name = sheet2.Cells["B" + i].Value.ToString(),
                    MemoryAddress = sheet2.Cells["E" + i].Value.ToString(),
                    Value = ""
                });
            }
        }
        //------------------------------------------
        public static Dictionary<string,Parameter> RowDictionaryProvider()
        {
            if (DictionaryHasBeenInitilized)
            {
                return ParamDic;
            }
            else
            {
                ParameterDicInitilizer();
                return ParamDic;
            }
        }
        //------------------------------------------
        private static List<string> StringSplitter(string str)
        {
            if (str == "")
            {
                throw new NotImplementedException();
            }
         
            List<string> ProccessedList = new List<string> { };
            ProccessedList.Add(str[0] + "" + str[1]);
            var SinglPartString = ProccessedList[0];
           
            int counter = 3;
            int i = 0;

            //59 = ;
            while (counter < str.Length && str[counter - 1] != 59)
            {
                //as long as it is a decimal number increase the counter  .=46
                while (str[counter - 1] > 47 && str[counter - 1] < 58 || str[counter -1] == 46 )
                {
                    SinglPartString = ProccessedList[i];
                    SinglPartString += str[counter - 1];
                    ProccessedList[i] = SinglPartString;
                    if (str.Length - counter == 0)
                    {
                        break;
                    }
                    counter++;
                }
                //handling "[]" and "<>" and "'"
                #region
                // If the character is "["--------
                if (str[counter - 1] == 91)
                    //Keep in while until u meen "]"
                    while (str[counter - 1] != 93)
                    {
                        SinglPartString = ProccessedList[i];
                        SinglPartString += str[counter - 1];
                        ProccessedList[i] = SinglPartString;
                        if (str.Length - counter == 0)
                        {
                            break;
                        }
                        counter++;
                    }
                if (str[counter - 1] == 93)
                {
                    SinglPartString = ProccessedList[i];
                    SinglPartString += str[counter - 1];
                    ProccessedList[i] = SinglPartString;
                    counter++;
                }
                // If the character is "<"-------
                if (str[counter - 1] == 60)
                    //Keep in while until u meen ">"
                    while (str[counter - 1] != 62)
                    {
                        SinglPartString = ProccessedList[i];
                        SinglPartString += str[counter - 1];
                        ProccessedList[i] = SinglPartString;
                        if (str.Length - counter == 0)
                        {
                            break;
                        }
                        counter++;
                    }
                if (str[counter - 1] == 62)
                {
                    SinglPartString = ProccessedList[i];
                    SinglPartString += str[counter - 1];
                    ProccessedList[i] = SinglPartString;
                    counter++;
                }
                // If the character is "'"-------
                if (str[counter - 1] == 39)
                    //Keep in while until u meet "the second '"
                    do
                    {
                        SinglPartString = ProccessedList[i];
                        SinglPartString += str[counter - 1];
                        ProccessedList[i] = SinglPartString;
                        if (str.Length - counter == 0)
                        {
                            break;
                        }
                        counter++;
                    }
                while (str[counter - 1] != 39);
                if (str[counter - 1] == 39)
                {
                    SinglPartString = ProccessedList[i];
                    SinglPartString += str[counter - 1];
                    ProccessedList[i] = SinglPartString;
                    counter++;
                }

                #endregion
                i++;
                if (str[counter-1] == 59)
                    break;
                if (str.Length - counter != 0) //count is standing on a letter take it 
                    //ProccessedList[i] += str[counter-1] + "" + str[counter]; Delete this
                    ProccessedList.Add(str[counter - 1] + "" + str[counter]);
                if (str.Length - counter == 0)
                    break;
                if (str.Length - counter > 2)
                    counter += 2;
            }
            return ProccessedList;
        }

        //------------------------------------------ Assign Value for each key
        private static void ParameterDefiner(List<string> ProccessedList)
        {
            List<string> TempObjectContainer = new List<string> { };
            List<string> TempParameterContainer = new List<string> { };
            List<char> temp = new List<char> { };

            foreach (var item in ProccessedList)
            {
                if (item[2] == 60)  //Seperate Objects segments that starts with a <
                    TempObjectContainer.Add(item);
                else
                    TempParameterContainer.Add(item);
            }
            foreach (var item in TempParameterContainer)
            {
                temp = item.ToList();
                ParamDic[temp[0] + "" + temp[1]].Value = "";
                for (int i = 2; i < temp.Count; i++)
                {
                    //Assign The value in the stinrg to value in dictionary 
                    ParamDic[temp[0] + "" + temp[1]].Value += temp[i];
                }
            }
            foreach (var item in TempObjectContainer)
            {
                temp = item.ToList();
                ObjectDic[temp[0] + "" + temp[1]].Value = "";

                // i =3 to count -1 
                for (int i = 2; i < temp.Count; i++)
                {
                    +[temp[0] + "" + temp[1]].Value += temp[i];
                }
            }
        }
        //------------------------------------------
        private static  ObservableCollection<Parameter> FinalList = new ObservableCollection<Parameter> { };
        public static async Task<ObservableCollection<Parameter>> ParameterList(string ConfigurationString)
        {
            string TempString = "";
            //string DeviceResponse = "";
            FinalList.Clear();
            List<string> ProccessedList = new List<string> { };
            if (DictionaryHasBeenInitilized == false)
            {
                ParameterDicInitilizer();
            }
            ProccessedList =  StringSplitter( await Tunnel.SelectedParameterValueGetter(ConfigurationString));

            foreach (var item in ParamDic)
            {
                item.Value.Value = "";
            }
            ParameterDefiner(ProccessedList);
            foreach (var ParameterKey in ParamDic)
            {
                if (ParameterKey.Value.Value != "")
                {
                    TempString = ParameterKey.Value.Value;
                    TempString = new string((from c in TempString
                                             where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c) || c == '/' || c == '.' || c ==':'
                                             select c
                                              ).ToArray());
                    ParameterKey.Value.Value = TempString;
                    FinalList.Add(ParameterKey.Value);
                }
            }
            return FinalList;
        }
     
     
    }
}
