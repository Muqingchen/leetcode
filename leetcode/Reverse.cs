using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace leetcode
{
    //给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。

    public class Reverse : IBase
    {
        public void Execute()
        {
            var ret = Solution2(Int32.MinValue);
            Console.WriteLine("值为：{0}", ret);
            Console.ReadLine();
        }


        private int Solution(int x)
        {
            var flag = x < 0 ? -1 : 1;
            var a = string.Join("", x.ToString().Trim('-') .Reverse());
            long y = flag * Int64.Parse(a);
            if (y > Int32.MaxValue || y < Int32.MinValue) return 0;
            return (int)y;
        }

        private int Solution2(int x)
        {
            long y=0;
            for (; x!=0; y = y * 10 + x % 10, x /= 10) { }
            return (y > Int32.MaxValue || y < Int32.MinValue) ? 0 : (int)y;
        }
    }
}
