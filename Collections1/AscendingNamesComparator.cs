using System.Collections.Generic;

namespace Collections1
{
    class AscendingNamesComparator : IComparer<Purchase>
    {
        public int Compare(Purchase x, Purchase y)
        {           
            if (x.Name == y.Name)
            {
                if(x.GetType() == y.GetType())
                {
                    return x.GetCost().CompareTo(y.GetCost());
                }

                if (x.GetType() == typeof(PricePurchase))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            } 
            else
            {
                return (x.Name.CompareTo(y.Name));
            }           
        }
    }
}
