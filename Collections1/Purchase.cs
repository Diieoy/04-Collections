using System;

namespace Collections1
{
    class Purchase
    {
        private string name;
        private decimal price;
        private int quantity;      

        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public Purchase() { }
        public Purchase(string name, decimal price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public virtual string GetTableRow()
        {
            return String.Format("{0,-10:N0}{1,10:N0}{2,10:N0}{3,10:N0}", Name, Price, Quantity, GetCost());
        }

        public virtual decimal GetCost()
        {
            return (price * quantity);
        }

        public override string ToString()
        {
            return (name + ";" + price + ";" + quantity + ";");
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }


            if (obj == null || (GetType() != obj.GetType()))
            {
                return false;
            }

            Purchase product = (Purchase)obj;

            if (price != product.price)
            {
                return false;
            }

            return name.Equals(product.name);
        }

        public override int GetHashCode()
        {
            return (name.GetHashCode() + price.GetHashCode());
        }
    }
}
