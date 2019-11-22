﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Utilities
{
    public static class XConvert
    {
        public static string HexStringToBase64String(this string input)
        {
            return System.Convert.ToBase64String(input.HexStringToHex());
        }

        private static byte[] HexStringToHex(this string inputHex)
        {
            var resultantArray = new byte[inputHex.Length / 2];
            for (var i = 0; i < resultantArray.Length; i++)
            {
                resultantArray[i] = System.Convert.ToByte(inputHex.Substring(i * 2, 2), 16);
            }
            return resultantArray;
        }
    }
}
