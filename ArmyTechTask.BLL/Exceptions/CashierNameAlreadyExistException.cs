using System;

namespace ArmyTechTask.BLL.Exceptions
{
    public class CashierNameAlreadyExistException: Exception
    {
        public CashierNameAlreadyExistException() : base("Cashier is already exist")
        {

        }
    }
}
