using System.Collections.Generic;

namespace QueuingForm
{
    internal static class CashierClass
    {
        private static int _counter = 10000;                   
        public static readonly Queue<string> CashierQueue = new Queue<string>();
        public static string NowServing { get; private set; } = "—";

        public static string GenerateNextTicket()
        {
            _counter++;
            string ticket = $"P - {_counter}";
            CashierQueue.Enqueue(ticket);
            return ticket;
        }


        public static bool TryServeNext(out string served)
        {
            served = null;
            if (CashierQueue.Count == 0) return false;

            served = CashierQueue.Dequeue();
            NowServing = served;
            return true;
        }

 
        public static string PeekOrNull() => CashierQueue.Count > 0 ? CashierQueue.Peek() : null;
    }
}
