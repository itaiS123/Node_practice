using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace practice_node
{
    class Program
    {
        public static int CountNode(Node<int> n)
        {
            int count = 0;
            while (n != null)
            {
                count++;
                n = n.GetNext();
            }
            return count;
        }
        public static int SumNode(Node<int> n)
        {
            int sum = 0;
            while (n != null)
            {
                sum += n.GetValue();
                n = n.GetNext();
            }
            return sum;
        }
        public static bool IsInNode(Node<int> n, Node<int> findNode)
        {
            while (n != null)
            {
                if (n.GetValue() == findNode.GetValue())
                {
                    return true;
                }
                n = n.GetNext();
            }
            return false;
        }
        public static void PrintNode(Node<int> n)
        {
            while (n != null)
            {
                Console.Write("{0} ", n.GetValue());
                n = n.GetNext();
            }
            Console.WriteLine();
        }
        public static Node<int> Clone(Node<int> head)
        {
            if (head == null)
                return null;

            Node<int> originalCurrent = head;
            Node<int> cloneHead = new Node<int>(head.GetValue());
            Node<int> cloneCurrent = cloneHead;

            while (originalCurrent.GetNext() != null)
            {
                originalCurrent = originalCurrent.GetNext();
                cloneCurrent.SetNext(new Node<int>(originalCurrent.GetValue()));
                cloneCurrent = cloneCurrent.GetNext();
            }

            return cloneHead;
        }

        public static Node<int> GetLast(Node<int> lst)
        {
            while (lst.HasNext())
                lst = lst.GetNext();
            return lst;
        }
        // הוספה כחוליה ראשונה 
        public static Node<int> Add(Node<int> lst, int num)
        {
            if (lst == null)
                lst = new Node<int>(num);
            else
                lst = new Node<int>(num, lst);
            return lst;
        }
        // הוספה אחרי חוליה אחרת
        public static Node<int> Add(Node<int> lst, Node<int> after, int num)
        {
            if (lst == null)
                return new Node<int>(num);

            if (after == null)
                return new Node<int>(num, lst);


            after.SetNext(new Node<int>(num, after.GetNext()));
            return lst;
        }        
        public Node<int> Build1()
        {
            Node<int> lst = null;
            for (int i = 1; i <= 10; i++)
                lst = new Node<int>(i, lst);
            return lst;
        }
        // הוספת החוליה החדשה כחוליה אחרונה  
        public Node<int> Build2()
        {
            Node<int> lst = new Node<int>(1);
            Node<int> pos = lst;
            for (int i = 2; i <= 10; i++)
            {
                pos.SetNext(new Node<int>(i));
                pos = pos.GetNext();
            }
            return lst;
        }
        // הפניה לשרשרת חוליות של מספרים שלמים ומחזירה אמת אם מספר. המספרים החיוביים גדול ממספר המספרים השליליים, אחרת תחזיר שקר
        public static bool IsPosBigThanNeg(Node<int> n)
        {
            int pos = 0;
            int neg = 0;

            while (n != null)
            {
                if (n.GetValue() > 0)
                {
                    pos++;
                }
                else
                {
                    neg++;
                }
                n= n.GetNext();
            }

            if (pos > neg)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // כתבו פעולה המקבלת הפניה לחוליה ומחזירה כמה איברים זוגיים יש בה
        public static int HowManyEven(Node<int> n)
        {
            int count = 0;
            while (n != null)
            {
                if (n.GetValue() % 2 == 0)
                {
                    count++;
                }
                n = n.GetNext();
            }
            return count;
        }

        // כתבו פעולה המקבלת הפניה לחוליה ומחזירה מהו האיבר במיקום X
        // check here if good
        public static int NodeWithIndex(Node<int> n, int x)
        {
            if (x < 0 || n == null) 
            {
                return int.MinValue; 
            }

            Node<int> current = n;
            while (current != null && x > 0)
            {
                current = current.GetNext();
                x--;
            }

            if (current == null) 
            {
                return int.MinValue; 
            }

            return current.GetValue();
        }

        // כתבו פעולה המקבלת שרשרת חוליות ומחזירה אמת אם היא מסודרת בסדר עולה
        public static bool IsNodeGoUp(Node<int> n)
        {
            while (n != null && n.GetNext().HasNext())
            {
                if (n.GetValue() > n.GetNext().GetValue())
                {
                    return false;
                }
                n = n.GetNext();
            }
            return true;
        }

        // פעולה המקבלת שרשרת חוליות של תווים char ומחרוזת המייצגת שם. הפעולה תחזיר
        // אמת אם אותיות השם מופיעות באותו סדר בשרשרת, אחרת תחזיר שקר.
        public static bool IsCharEquelToName(Node<char> n, string name)
        {
            for (int i = 0; i < name.Length && n!= null; i++)
            {
                if (name[i] != n.GetValue())
                {
                    return false;
                }
                n = n.GetNext();
            }
            
            return true;
        }

        // פעולה המקבלת שרשרת ומחזירה שרשרת חדשה המכילה רק את הערכים הזוגיים בשרשרת המקורית
        public static Node<int> BuildNodeEven(Node<int> n)
        {
            Node<int> newNode = null;
            while (n != null)
            {
                if (n.GetValue() % 2 == 0)
                {
                    newNode = Add(newNode, n.GetValue());
                }
                n = n.GetNext();
            }
            return newNode;
        }

        // אין לשנות את השרשרת 1 כתוב פעולה, המקבלת שתי שרשראות מספרים 1,2. ומוסיפה לשרשרת 2 את האיברים הזוגיים של השרשרת 1
        public static void Even1InNode2(Node<int> c1, Node<int> c2)
        {
            // c1 vals changing ??
            Node<int> tempo = Clone(c1);
            while (tempo != null)
            {
                if (tempo.GetValue() % 2 == 0)
                {
                    c2 = Add(c2, tempo.GetValue());
                }
                tempo = tempo.GetNext();
            }
        }

        // המספר הראשון הוא המספר והשני כמה פעמים הוא יחזור על עצמו. הפעולה תחזיר שרשרת חדשה של כל המספרים.
        public static Node<int> ListMulti(Node<int> n)
        {
            Node<int> newNode = null;
            int num = 0;
            int multi = 0;

            while (n != null)
            {
                num = n.GetValue();
                n = n.GetNext();

                multi = n.GetValue();
                n = n.GetNext();

                newNode = Add(newNode, num * multi);
            }
            return newNode;
        }

        // כתבו פעולה המקבלת שרשרת חוליות ומחזירה שרשרת הפוכה.
        public static Node<int> ReverseNode(Node<int> n)
        {
            Node<int> newNode = null;
            while (n != null)
            {
                newNode = Add(newNode, n.GetValue());
                n = n.GetNext();
            }
            return newNode;
        }

        // פעולה המקבלת שרשרת חוליות של מספרים ומוסיפה בין כל שתי חוליות- חוליה חדשה. שערכה ממוצע של שתי החוליות.
        public static Node<int> AvgNode(Node<int> n)
        {
            Node<int> temp = null;
            Node<int> current = n;

            while (current != null && current.HasNext())
            {
                int average = (current.GetValue() + current.GetNext().GetValue()) / 2;
                temp = new Node<int>(average, temp); // Create a new node with the average value
                current = current.GetNext().GetNext(); // Move to the next pair of nodes
            }

            return temp;
        }


        static void Main(string[] args)
        {
            Node<int> n = new Node<int>(1, new Node<int>(2, new Node<int>(3, new Node<int>(4, new Node<int>(5)))));
            Node<char> n1 = new Node<char>('d', new Node<char>('i', new Node<char>('t', new Node<char>('a'))));
            Node<int> n2 = new Node<int>(6, new Node<int>(7, new Node<int>(8, new Node<int>(9, new Node<int>(10)))));
            Node<int> n3 = new Node<int>(1, new Node<int>(2, new Node<int>(3, new Node<int>(4))));

            Console.WriteLine("CountNode");
            Console.WriteLine(CountNode(n));
            Console.WriteLine("--------------------");

            Console.WriteLine("SumNode");
            Console.WriteLine(SumNode(n));
            Console.WriteLine("--------------------");

            Console.WriteLine("IsInNode");
            Console.WriteLine(IsInNode(n, new Node<int>(8, null)));
            Console.WriteLine("--------------------");

            Console.WriteLine("PrintNode");
            PrintNode(n);
            Console.WriteLine("--------------------");

            Console.WriteLine("IsPosBigThanNeg");
            Console.WriteLine(IsPosBigThanNeg(n));
            Console.WriteLine("--------------------");

            Console.WriteLine("HowManyEven");
            Console.WriteLine(HowManyEven(n));
            Console.WriteLine("--------------------");

            Console.WriteLine("IsNodeGoUp");
            Console.WriteLine(IsNodeGoUp(n));
            Console.WriteLine("--------------------");

            Console.WriteLine("IsCharEquelToName");
            Console.WriteLine(IsCharEquelToName(n1, "dita"));
            Console.WriteLine("--------------------");

            Console.WriteLine("BuildNodeEven");
            PrintNode(BuildNodeEven(n));
            Console.WriteLine("--------------------");

            Console.WriteLine("ListMulti");
            PrintNode(ListMulti(n3));
            Console.WriteLine("--------------------");

            Console.WriteLine("ReverseNode");
            PrintNode(ReverseNode(n));
            Console.WriteLine("--------------------");

            Console.WriteLine("AvgNode");
            PrintNode(n);
            PrintNode(AvgNode(n));
            Console.WriteLine("--------------------");


            Console.ReadKey();
        }
    }
}
