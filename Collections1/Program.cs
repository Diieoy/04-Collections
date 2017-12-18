using System;
using System.IO;

namespace Collections1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PurchaseCollection purchaseCollection = new PurchaseCollection(@"..\..\..\" + args[0]);
                Console.WriteLine();
                Console.WriteLine("in.csv:");
                purchaseCollection.Print();

                PurchaseCollection purchaseCollection2 = new PurchaseCollection(@"..\..\..\" + args[1]);
                Console.WriteLine();
                Console.WriteLine("addon.csv:");
                purchaseCollection2.Print();

                //вставить последний элемент второй коллекции в позицию 0 первой коллекции покупок
                purchaseCollection.Insert(0, purchaseCollection2.GetElement(purchaseCollection2.ListPurchases.Count - 1));

                //вставить первый элемент второй коллекции в позицию 1000 первой коллекции покупок
                purchaseCollection.Insert(1000, purchaseCollection2.GetElement(0));

                //вставить элемент с позицией 2 из второй коллекции в позицию 2 первой коллекции покупок
                purchaseCollection.Insert(2, purchaseCollection2.GetElement(2));

                //последовательно удалить элементы через метод Delete() с индексами 3, 10 и –5
                purchaseCollection.Delete(3);
                purchaseCollection.Delete(10);
                purchaseCollection.Delete(-5);

                Console.WriteLine();
                purchaseCollection.Sort(new AscendingNamesComparator());
                Console.WriteLine("После сортировки:");
                purchaseCollection.Print();

                Console.WriteLine();
                Console.WriteLine("Результат поиска:");
                Console.WriteLine(PurchaseCollection.FindItemInCollection(purchaseCollection2.GetElement(1), purchaseCollection.ListPurchases));
                Console.WriteLine(PurchaseCollection.FindItemInCollection(purchaseCollection2.GetElement(3), purchaseCollection.ListPurchases));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }
    }
}
