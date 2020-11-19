using System;
using System.Transactions;

namespace LinkedLists
{

    public class Node
    {
        public object data;
        public Node next;
        public Node(object data)
        {
            this.data = data;
            this.next = null;
        }
    }

    public class LinkedList
    {
        private Node head;

        public void PrintAllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }

        public Node GetHead()
        {
            return head;
        }

        public void AddFirst(Object data)
        {
            Node newHead = new Node(data);

            newHead.next = head;
            head = newHead;
        }

        public void AddLast(Object data)
        {
            if (head == null)
            {
                head = new Node(data);
                head.next = null;
            }
            else
            {
                Node newTail = new Node(data);

                Node current = head;

                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newTail;
            }
        }

        public int SumList(Node head1, Node head2)
        {
            Node curr_1 = head1;
            Node curr_2 = head2;

            int total_sum = 0;

            int placeValue = 1;

            while(curr_1 != null)
            {
                total_sum += ( (int)curr_1.data * placeValue);
                placeValue *= 10;

                curr_1 = curr_1.next;
            }
            
            //Reset place value
            placeValue = 1;
            while(curr_2 != null)
            {
                total_sum += ( (int)curr_2.data * placeValue);
                placeValue *= 10;

                curr_2 = curr_2.next;
            }

            return total_sum;
        }

        
        //Get the sum of a linked lists nodes recursively
        public int SumListRecursive(Node head1, int place_value)
        {
            if (head1.next == null)
            {
                return ((int) head1.data * place_value);
            }
            int total_sum = (int)head1.data * place_value;
            return total_sum + SumListRecursive(head1.next, place_value * 10);
        }

        public void Partition(int partitionValue)
        {
            Node l_partition_head = null; 
            Node l_partition_tail = null; 
        
            Node r_partition_head = null; 
            Node r_partition_tail = null;

            Node current = head;

            while(current != null)
            {
                Node next = current.next;
                if ((int)current.data < partitionValue)
                {
                    if (l_partition_head == null)
                    {
                        l_partition_head = current;
                        l_partition_tail = current;
                    }
                    else
                    {
                        l_partition_tail.next = current;
                        l_partition_tail = current;
                        l_partition_tail.next = null;
                    }
                }

                if ((int)current.data >= partitionValue)
                {
                    if (r_partition_head == null)
                    {
                        r_partition_head = current;
                        r_partition_tail = current;
                    }
                    else
                    {
                        r_partition_tail.next = current;
                        r_partition_tail = current;
                        r_partition_tail.next = null;
                    }
                }
                current = next;
            }

            if (l_partition_head == null)
            {
                return;
            }

            l_partition_tail.next = r_partition_head;
            r_partition_tail.next = null;
            head = l_partition_head;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList l = new LinkedList();
            l.AddFirst(0);
            l.AddLast(5);
            l.AddLast(2);

            LinkedList l2 = new LinkedList();
            l2.AddFirst(0);
            l2.AddLast(5);
            l2.AddLast(2);

            int sum_of_lists = l.SumList(l.GetHead(), l2.GetHead());
            Console.WriteLine(sum_of_lists);
            Console.WriteLine(l.SumListRecursive(l.GetHead(), 1));
        }
    }
}
