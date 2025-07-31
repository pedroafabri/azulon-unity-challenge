using UnityEngine;

namespace GameExceptions
{
    
    public class NotEnoughWalletBalanceException: System.Exception
    {
        public NotEnoughWalletBalanceException(string message): base(message) { }
    }
}
