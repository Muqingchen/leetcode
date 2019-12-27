using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    //给定一个字符串，请你找出其中不含有重复字符的 最长子串的长度。

    //示例 1:

    //输入: "abcabcbb"
    //输出: 3 
    //解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
    //示例 2:

    //输入: "bbbbb"
    //输出: 1
    //解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
    //示例 3:

    //输入: "pwwkew"
    //输出: 3
    //解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
    //        请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
    public class LengthOfLongestSubstring:IBase
    {
        public void Execute()
        {
            var a = "";
            var len = Solution(a);
            Console.Write(len.ToString());
            Console.ReadLine();
        }

        private int Solution(string s)
        {
            int max = 0;
            int len = s.Length;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for(int start=0,end=0; end < len; end++)
            {
                if (dic.ContainsKey(s[end]))
                {
                    start = Math.Max(dic[s[end]], start);
                }
                max = Math.Max(max, end - start + 1);
                dic[s[end]] = end + 1;
            }
            return max;
        }
    }
}
