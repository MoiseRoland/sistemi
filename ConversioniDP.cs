using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConversioniDP //Moise Roland-Adrian
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dp = new int[4];
            string Indirizzo = Console.ReadLine();
            string[] ip = Indirizzo.Split('.');
            for (int i = 0; i < ip.Length; i++)
            {
                dp[i] = int.Parse(ip[i]);
            }

            bool[] bn = Convert_Dp_to_Bin (dp);
            for (int i = 0; i < bn.Length; i++)
            {
                Console.Write(Convert.ToInt32(bn[i]));
            }

            Console.WriteLine("\n" + Convert_Dp_to_Int(dp));
            Console.WriteLine(Convert_Bin_to_Int(bn));
            Console.WriteLine(string.Join(".", Convert_Bin_to_DP(bn)));


            Console.ReadLine();
        }
        static bool[] Convert_Dp_to_Bin(int[] dp)
        {
            bool[] bn = new bool[32];
            int j = bn.Length - 1; 
            for (int i = 0; i < dp.Length; i++)
            {
                int num = dp[i];
                for (int z = 0; z < 8; z++)
                {
                    if (num % 2 == 1)
                        bn[j] = true;

                    j--;
                    num = num / 2;
                }
            }
            return bn;
        }
        static int Convert_Dp_to_Int (int[] dp)
        {
            int num = 0;
            int pos = dp.Length-1;
            for (int i =0; i < dp.Length; i++)
            {
                num = num + dp[i] * (int)Math.Pow(256, pos);
                pos--;
            }

            return num;
        }
static int Convert_Bin_to_Int(bool[] bn)
{
    int pos = bn.Length - 1;
    int num = 0;
    for (int i = 0; i < bn.Length; i++)
    {
        if (bn[i] != false)
            num = num + (int)Math.Pow(2, pos);
        pos--;
    }
    return num;
}

static int[] Convert_Bin_to_DP(bool[] bn)
{
    int[] dp = new int[4];

    for (int i = 0; i < 4; i++)
    {
        int otetto = 0;

        for (int j = 0; j < 8; j++)
        {
            int pos = (i * 8) + j;
            if (bn[pos] != false)
            otetto = otetto + (int)Math.Pow(2, 7 - j);
        }

        dp[i] = otetto;
    }
    return dp;
}
    }
}
