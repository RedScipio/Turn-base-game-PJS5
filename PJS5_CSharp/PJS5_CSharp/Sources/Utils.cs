﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PJS5_CSharp.Sources
{
    public class Utils
    {
        public static int GetInt()
        {
            int iInt;
            iInt = Console.ReadKey().KeyChar - '0';
            Console.WriteLine(iInt);
            return iInt;
        }

        public static String SerializeInJson(object obj, String fileName)
        {
            String jsonText = JsonSerializer.Serialize<object>(obj);

            File.WriteAllText(fileName, jsonText);

            return jsonText;
        }
    }
}
