using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    //给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

    //示例 1：

    //输入: "babad"
    //输出: "bab"
    //注意: "aba" 也是一个有效答案。
    //示例 2：

    //输入: "cbbd"
    //输出: "bb"
    public class LongestPalindrome : IBase
    {
        public void Execute()
        {
            var a = "";
            var str = Solution(a);
            Console.Write(str);
            Console.ReadLine();
        }

        private string Solution(string s)
        {
            for(int i = 0; i < s.Length; i++)
                for(int j=i;j<s.Length;j++){
                    
            }
            return "";
        }
    }
}
