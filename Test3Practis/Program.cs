using System;
using System.Text;
using DataStructure;

namespace Test3Practis
{
    class Program
    {
        public static void NoDouble(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            while(!q.IsEmpty())
            {
                int val = q.Remove();
                if (!IsIn(temp, val))
                    temp.Insert(val);
            }
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }
        public static bool IsIn(Queue<int> q, int num)
        {
            bool isIn = false;
            Queue<int> temp = new Queue<int>();
            while(!q.IsEmpty())
            {
                if (q.Head() == num)
                    isIn = true;
                temp.Insert(q.Remove());
            }
            while(!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            return isIn;
        }
        public static bool GoldenBall(Queue<string> tube, int num)
        {
            int counter = 0;
            while((counter < num) && !tube.IsEmpty())
            {
                string val = tube.Remove();
                counter++;
                tube.Insert(val);
            }
            return tube.Head() == "gold";
        }
        public static Stack<int> ToStackSort(Queue<int> q)
        {
            Stack<int> stack = new Stack<int>();
            while(!q.IsEmpty())
            {
                Queue<int> temp = new Queue<int>();
                int min = q.Remove();
                while ((!q.IsEmpty()))
                {
                    if (min > q.Head())
                    {
                        temp.Insert(min);
                        min = q.Remove();
                    }
                    else
                        temp.Insert(q.Remove());
                }
                while (!temp.IsEmpty())
                {
                    q.Insert(temp.Remove());
                }
                stack.Push(min);
            }
            return stack;
        }
        public static void PlaceInRightPlase(Queue<int> q, int num)
        {
            Queue<int> temp = new Queue<int>();
            bool right = false;
            while(!q.IsEmpty())
            {
                int val = q.Remove();
                if(num>val&&!right)
                {
                    temp.Insert(num);
                    temp.Insert(val);
                    right = true;
                }
                else
                {
                    temp.Insert(val);
                }
            }
            if(!false)
            {
                temp.Insert(num);
            }
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            
        }
    
        public static void merge(Queue<int> q1, Queue<int> q2)
        {
            while (!q2.IsEmpty())
            {
                PlaceInRightPlase(q1, q2.Remove());
            }
        }
        static void MinPriorirty(Queue<Queue<int>> q)// מדפיסה לפי הסדר
        {
            int place = 0;
            while (!q.IsEmpty())
            {
                place = MinFirstPlace(q);
                for (int i = 0; i < place-1; i++)
                {
                    if (!q.Head().IsEmpty())
                    {
                        q.Insert(q.Remove());
                    }

                }
                Console.WriteLine(q.Head().Remove());
                if (q.Head().IsEmpty())
                    q.Remove();
            }
        }
     
        static int MinFirstPlace(Queue<Queue<int>> q)// מחזיר את מיקום התור שראש התוק בו מינימלי
        {
            int count2 = 0, min = int.MaxValue;
            q.Insert(null);
            while (q.Head() != null)
            {
                if (q.Head().Head() < min)
                {
                    min = q.Head().Head();
                    count2++;
                }
                q.Insert(q.Remove());
            }
            q.Remove();
            return count2;
        }
        static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();
            q.Insert(20);
            q.Insert(3);
            q.Insert(15);
            Queue<int> q2 = new Queue<int>();
            q2.Insert(5);
            q2.Insert(2);
            q2.Insert(106);
            Queue<int> q3 = new Queue<int>();
            q3.Insert(7);
            Queue<Queue<int>> q4 = new Queue<Queue<int>>();
            q4.Insert(q);
            q4.Insert(q2);
            q4.Insert(q3);
            MinPriorirty(q4);
        }
    }
  
}
