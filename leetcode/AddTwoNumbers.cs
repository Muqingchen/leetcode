using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode
{
    //给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序的方式存储的，并且它们的每个节点只能存储 一位数字。

    //如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。

    //您可以假设除了数字 0 之外，这两个数都不会以 0 开头。

    //示例：

    //    输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
    //    输出：7 -> 0 -> 8
    //    原因：342 + 465 = 807
    public class AddTwoNumbers:IBase
    {
        public void Execute()
        {
            var a = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            var b = new int[] { 5,6,4 };
            var l1 = GetListNode(a);
            var l2 = GetListNode(b);
            var l3 = Solution(l1, l2);
            while (l3 != null)
            {
                Console.Write(l3.val.ToString());
                l3 = l3.next;
            };
            Console.ReadLine();
        }

        private ListNode Solution(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            int carry = 0;
            ListNode curr = dummyHead;
            while (l1 !=null || l2 != null)
            {
                int x = l1 != null ? l1.val : 0;
                int y = l2 != null ? l2.val : 0;
                carry += x + y;
                curr.next = new ListNode(carry % 10);
                carry /= 10;
                curr = curr.next;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;
        }


        private ListNode GetListNode(int[] nums)
        {
            ListNode dummyHead = new ListNode(0);
            var curr = dummyHead;
            for (int i = 0; i < nums.Length; i++)
            {
                curr.next = new ListNode(nums[i]);
                curr = curr.next;
            }
            return dummyHead.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}
