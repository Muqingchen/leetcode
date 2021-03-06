﻿using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode
{
    //给定两个大小为 m 和 n 的有序数组 nums1 和 nums2。

    //请你找出这两个有序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。

    //你可以假设 nums1和 nums2不会同时为空。

    //示例 1:

    //nums1 = [1, 3]
    //    nums2 = [2]

    //    则中位数是 2.0
    //示例 2:

    //nums1 = [1, 2]
    //    nums2 = [3, 4]

    //    则中位数是(2 + 3)/2 = 2.5
    public class FindMedianSortedArrays:IBase
    {
        public void Execute()
        {
            //var nums1 = new int[] { 1, 2,3 };
            //var nums2 = new int[] { 4,5,6,7,8,9,10,11};
            var nums1 = new int[] { 1,  3 };
            var nums2 = new int[] { 2 };
            var ret = Solution1(nums1,nums2);
            Console.Write(ret.ToString());
            Console.ReadLine();
        }


        // 将两个数组划分成4块，根据中位数的定义，当数组1的划分长度i确定，数组2的划分长度j也跟着确定。判断数组1和数组2的划分点大小，因为数组有序，所以
        private double Solution(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            // 确定数组1的长度小于数组2，减少循环
            if (m > n)
            {
                return Solution(nums2, nums1);
            }
            int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2;
            while (iMin <= iMax)
            {
                int i = (iMin + iMax) / 2;
                int j = halfLen - i;
                //  如果
                if (i < iMax && nums2[j - 1] > nums1[i])
                {
                    iMin = i + 1; // i is too small
                }
                else if (i > iMin && nums1[i - 1] > nums2[j])
                {
                    iMax = i - 1; // i is too big
                }
                else
                { // i is perfect
                    int maxLeft;
                    if (i == 0) { maxLeft = nums2[j - 1]; } // 如果数组1都在右边，则中位数左边界为数组2的左边界
                    else if (j == 0) { maxLeft = nums1[i - 1]; }// 如果数组2都在右边，则中位数左边界为数组1的左边界
                    else { maxLeft = Math.Max(nums1[i - 1], nums2[j - 1]); }// 否则中位数左边界为数组1数组2的左边界的大值
                    if ((m + n) % 2 == 1)  return maxLeft; // 如果数组长度和为奇数，则中位数为左边界，否则为左右边界和的一半

                    int minRight;
                    if (i == m) { minRight = nums2[j]; }
                    else if (j == n) { minRight = nums1[i]; }
                    else { minRight = Math.Min(nums2[j], nums1[i]); }

                    return (maxLeft + minRight) / 2.0;
                }
            }
            return 0.0;
        }


        private double Solution1(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            int left = (m + n + 1) / 2;
            int right = (m + n + 2) / 2;
            return (GetKth(nums1, 0, m - 1, nums2, 0, n - 1, left) + GetKth(nums1, 0, m - 1, nums2, 0, n - 1, right)) / 2.0;
        }
        /// <summary>
        /// 求第k小数
        /// </summary>
        /// <param name="nums1">有序数组1</param>
        /// <param name="start1"></param>
        /// <param name="end1"></param>
        /// <param name="nums2">有序数组2</param>
        /// <param name="start2"></param>
        /// <param name="end2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private int GetKth(int[] nums1,int start1,int end1,int[] nums2,int start2,int end2,int k)
        {
            int len1 = end1 - start1 + 1;
            int len2 = end2 - start2 + 1;
            // 保证nums是短的那个数组
            if (len1 > len2) return GetKth(nums2, start2, end2, nums1, start1, end1, k);
            if (len1 == 0) return nums2[start2 + k - 1];// 如果数组1的长度为0，说明第k小数在num2里
            if (k == 1) return Math.Min(nums1[start1], nums2[start2]);

            int i = Math.Min(k / 2, len1) + start1 - 1;
            int j = Math.Min(k / 2, len2) + start2 - 1;
            if (nums1[i] >= nums2[j])
            {
                return GetKth(nums1, start1, end1, nums2, j + 1, end2, k - (j - start2 + 1));
            }
            else
            {
                return GetKth(nums1, i + 1, end1, nums2, start2, end2, k - (i - start1 + 1));
            }

        }
    }
}
