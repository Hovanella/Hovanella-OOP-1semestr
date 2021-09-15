using System;

namespace Laba4
{
    public static class StatisticOperation
    {
        public static int CountCapacity(List list)
        {
            var current = list.Head;
            int count = 0;

            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        public static string FindTheMostLongString(List list)
        {
            if (list.Head == null)
                throw new InvalidOperationException();
            
            var current = list.Head;
            var maxString = "";
            while (current!=null)
            {
                if (current.Data.Length > maxString.Length)
                    maxString = current.Data;
                current = current.Next;
                
            }

            return maxString;
        }

        public static void ShortenString(this List list,int length)
        {
            var current = list.Head;
            while (current != null)
            {
                current.Data = current.Data.Substring(0, length);
                current = current.Next;
            }
        }

        public static string ConcatAllElements(this List list)
        {
            if (list.Head == null)
                throw new InvalidOperationException();

            string newLine="";
                
            var current = list.Head;
            while (current != null)
            {
                newLine += current.Data;
                current = current.Next;
            }

            return newLine;

        }
        
        //TODO ещё какие-нибудь методы придумать
    }
}