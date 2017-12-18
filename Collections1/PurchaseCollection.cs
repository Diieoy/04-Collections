using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Collections1.CsvExceptions;

namespace Collections1
{
    enum NumberOfClassFields { Purchase = 3, PricePurchase = 4 }

    class PurchaseCollection : IEnumerable, IEnumerator
    {
        private List<Purchase> listPurchases;
        private int position = -1;

        internal List<Purchase> ListPurchases { get => listPurchases; }
        public object Current { get => listPurchases[position]; }

        public PurchaseCollection() { }
        public PurchaseCollection(string inFile)
        {
            StreamReader sr = new StreamReader(inFile + ".csv");
            listPurchases = new List<Purchase>();
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                try
                {                   
                    listPurchases.Add(createPurchase(s));
                }
                catch (CsvException e)
                {
                    Console.Write(e.CsvString + " - ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
        }
        
        private Purchase createPurchase(string csvString)
        {
            string[] data = csvString.Split(';');

            if (String.IsNullOrEmpty(data[0]))
            {
                throw new CsvException(csvString, "имя покупки не указано");
            }

            try
            {
                switch (data.Length)
                {
                    case (int)NumberOfClassFields.Purchase:
                        return new Purchase(data[0], decimal.Parse(data[1]), int.Parse(data[2]));

                    case (int)NumberOfClassFields.PricePurchase:
                        {
                            decimal price = decimal.Parse(data[1]);
                            decimal discountInRubles = decimal.Parse(data[3]);
                            if (price <= discountInRubles)
                            {
                                throw new CsvException(csvString, "неверная скидка (больше или равна цене)");
                            }
                            return new PricePurchase(data[0], price, int.Parse(data[2]), discountInRubles);
                        }
                    
                    default:
                        throw new CsvException(csvString, "неверное количество данных");
                }
            }
            catch (FormatException)
            {
                throw new CsvException(csvString, "неверный формат данных");
            }
        }       

        public Purchase GetElement(int index)
        {                      
            return listPurchases[index];
        }

        public static string FindItemInCollection(Purchase item, List<Purchase> collection)
        {
            int index = collection.BinarySearch(item, new AscendingNamesComparator());

            if(index >= 0)
            {
                return ("Элемент " + item + " найден в позиции " + index);
            }
            else
            {
                return ("Элемент " + item + " не найден");
            }
        }
        
        public void Insert(int index, Purchase p)
        {
            if(index < 0 || index >= listPurchases.Count)
            {
                listPurchases.Add(p);
            }
            else
            {
                listPurchases.Insert(index, p);
            }
        }

        public int Delete(int index)
        {
            if(index < 0 || index >= listPurchases.Count)
            {
                return -1;
            }
            else
            {
                listPurchases.RemoveAt(index);
                return index;
            }
        }

        public decimal TotalCost()
        {
            decimal sum = 0;
            foreach (Purchase item in listPurchases)
            {
                sum += item.GetCost();
            }

            return sum;
        }

        public void Sort(IComparer<Purchase> cmp)
        {
            listPurchases.Sort(cmp);
        }

        public void Print()
        {
            Console.WriteLine(String.Format("{0,10}{1,10}{2,10}{3,10}{4,10}", "Name", "Price", "Number", "Cost", "Discount"));

            foreach (Purchase item in listPurchases)
            {
                Console.WriteLine(item.GetTableRow());               
            }

            Console.WriteLine(String.Format("{0,-10}{1,30:N0}", "Total cost", TotalCost()));
        }            

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (position < listPurchases.Count - 1)
            {
                position++;
                return true;
            }

            Reset();

            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
