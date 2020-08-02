using System;
using System.Numerics;

namespace SpecFlowNunit
{
    class ForLetterConunter
    {
        private static BigInteger letterCounter;
        public static BigInteger LetterCounter
        {
            get
            {
                return letterCounter;
            }
            private set { }
        }
        public static void GetLetterCounter(string URL)
        {
            int posEnd = URL.LastIndexOf('/'), posStart = -1;
            for (int i = 0; i < URL.Length; ++i)
            {
                if (Char.IsDigit(Convert.ToChar(URL[i])))
                {
                    posStart = URL.IndexOf(URL[i]);
                    break;
                }
            }

            letterCounter = BigInteger.Parse(URL.Substring(posStart, posEnd - posStart));
        }
        public static string XPathBuilder(string begin, string middle, string end)
        {
            return begin + middle + end;
        }
    }
}
