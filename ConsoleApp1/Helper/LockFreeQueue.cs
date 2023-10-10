using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Helper
{
    //CAS（Compare-And-Swap） 无锁算法类  
    public class LockFreeQueue<T>
    {
        private class Node
        {
            public T Value;
            public Node Next;
        }

        private Node head;
        private Node tail;

        public LockFreeQueue()
        {
            head = new Node();
            tail = head;
        }


        public void Enqueue(T item)
        {
            Node newNode = new Node { Value = item };

            while (true)
            {
                Node currentTail = tail;
                Node tailNext = currentTail.Next;

                if (currentTail == tail)
                {
                    if (tailNext == null) // Check if the tail is at the end 检查尾部是否在末尾
                    {
                        if (Interlocked.CompareExchange(ref currentTail.Next, newNode, null) == null)
                        {
                            Interlocked.CompareExchange(ref tail, newNode, currentTail);
                            return;
                        }
                    }
                    else // Help advance the tail 帮助推进尾巴
                    {
                        Interlocked.CompareExchange(ref tail, tailNext, currentTail);
                    }
                }
            }
        }

        public bool Dequeue(out T result)
        {
            while (true)
            {
                Node currentHead = head;
                Node currentTail = tail;
                Node headNext = currentHead.Next;

                if (currentHead == head)
                {
                    if (currentHead == currentTail) // The queue is empty 队列等于空
                    {
                        result = default(T);
                        return false;
                    }

                    if (headNext != null)
                    {
                        result = headNext.Value;
                        if (Interlocked.CompareExchange(ref head, headNext, currentHead) == currentHead)
                            return true;
                    }
                }
            }
        }
    }
}
