using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;

namespace DecryptNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var cryptedNumbers = new List<string>
            {
                "())(",
                "*$(#&",
                "!!!!!!!!!!",
                "$*^&@!",
                "!)(^&(#@",
                "!)(#&%(*@#%"
            };

            var decryptKey = new List<char>() { ')', '!', '@', '#', '$', '%', '^', '&', '*', '(' };

            foreach (string encrypted in cryptedNumbers)
            {
                var decryptQuery =
                    (from character in encrypted
                        select decryptKey.IndexOf(character)).ToList();

                Console.WriteLine(string.Join("", decryptQuery));
            }

            Console.ReadKey();
        }
    }
}
