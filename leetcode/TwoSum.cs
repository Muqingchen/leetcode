using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace leetcode
{
    //给定一个整数数组 nums和一个目标值 target，请你在该数组中找出和为目标值的那 两个整数，并返回他们的数组下标。

    //你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。

    //示例:

    //            给定 nums = [2, 7, 11, 15], target = 9

    //            因为 nums[0] +nums[1] = 2 + 7 = 9
    //            所以返回[0, 1]
    public class TwoSum:IBase
    {
        public void Execute()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;
            var ret = Solution2(nums, target);
            Console.WriteLine("值为：{0} {1}", ret[0], ret[1]);
            Console.ReadLine();
        }


        private int[] Solution(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] {i,j};
                    }
                }
            }
            throw new Exception("不合法的输入");
        }

        private int[] Solution2(int[] nums, int target)
        {
            var keyValuePairs = new Dictionary<int,int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var difference = target - nums[i];
                if (keyValuePairs.ContainsKey(difference))
                {
                    return new int[] { keyValuePairs[difference],i };
                }
                keyValuePairs.TryAdd(nums[i], i);
            }
            throw new Exception("不合法的输入");
        }
    }
}
