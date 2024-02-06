using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
//using System.Decimal;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        private static string BinaryTo(string input) //перевод в двоичную систему счисления
        {
            string[] strARR = new string[4];
            int[] n = input.Split('.').Select(x => int.Parse(x)).ToArray();
            for (int i = 0; i < n.Length; i++)
            {
                string nul = "";
                string k = Convert.ToString(n[i], 2);
                if (k.Length != 8 - k.Length)
                {
                    int kol = 8 - k.Length;
                    for (int j = 0; j < kol; j++)
                    {
                        nul += "0";
                    }
                }
                k = nul + k;
                strARR[i] = k;
            }
            string s = string.Join(".", strARR);
            return s;
        }

        static void Main(string[] args)
        {
            string ip = "10.216.0.134";
            string mask = "255.255.255.0";


            var ipAddress = IPAddress.Parse(ip);
            var maskAddress = IPAddress.Parse(mask);

            Console.WriteLine($"Subnet address: {GetSubnetAddress(maskAddress, ipAddress)}");


            Console.ReadLine();
        }
        private static string NetworkIP(string ip, string mask) //ip-адрес сети
        {
            string result = "";
            ip = BinaryTo(ip);
            mask = BinaryTo(mask);
            char[] p = mask.ToCharArray(); ;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] == '1')
                {
                    result += ip[i];
                }
                if (p[i] == '0')
                {
                    result += '0';
                }
                if (p[i] == '.')
                {
                    result += '.';
                }
            }
            Console.WriteLine("ip-адрес сети: ", result);
            // result = ToDecimal(result);
            return result;
        }



        private static string HostIP(string ip, string mask)
        {
            string result = "";


            return result;
        }

        static IPAddress GetSubnetAddress(IPAddress subnetMask, IPAddress hostIp)
        {
            var ipBytes = hostIp.GetAddressBytes();
            var maskBytes = subnetMask.GetAddressBytes();

            //IpV4
            var subnetBytes = Enumerable.Range(0, 4).Select((index) => (byte)(ipBytes[index] & maskBytes[index])).ToArray();
            return new IPAddress(subnetBytes);
        }
    }



}