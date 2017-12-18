using System;

namespace Collections1
{
    class PricePurchase : Purchase
    {
        private decimal discountInRubles;

        public decimal DiscountInRubles { get => discountInRubles; set => discountInRubles = value; }

        public PricePurchase() { }
        public PricePurchase(string name, decimal price, int quantity, decimal discountInRubles) : base(name, price, quantity)
        {
            this.discountInRubles = discountInRubles;
        }

        public override string GetTableRow()
        {
            return (base.GetTableRow() + String.Format("{0,10:N0}", DiscountInRubles));
        }

        public override decimal GetCost()
        {
            if (discountInRubles > Price)
            {
                throw new Exception("The discount can't be more than price");
            }

            if (discountInRubles > 0)
            {
                return (decimal.Round(Price - discountInRubles) * Quantity);
            }
            else
            {
                return base.GetCost();
            }
        }

        public override string ToString()
        {
            return (base.ToString() + discountInRubles + ";");
        }
    }
}
