using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarketHashTable
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    class Set
    {
        public LinkedList<Product>[] Products_Hash_Table { get; set; }

        int _counter;
        public Set(int How_Much)
        {
            Products_Hash_Table = new LinkedList<Product>[How_Much];
        }
        public Set(params Product[] products)
        {
            Products_Hash_Table = new LinkedList<Product>[products.Length];
            foreach (Product p in products)
                Products_Hash_Table[Hash(p.BarCode)].AddLast(p);
        }
        public void Insert(Product x)
        => Products_Hash_Table[Hash(x.BarCode)].AddLast(x);

        public void Delete(Product x)
        => Products_Hash_Table[Hash(x.BarCode)].Remove(x);

        public double Price(Product x)
        => Products_Hash_Table[Hash(x.BarCode)].First(p => p == x).Price * (1 - Product.Discount);

        public void Discount(double discount)
        => Product.Discount = discount;

        public int Hash(string BarCode)
        => (3129 * ASCIIEncoding.ASCII.GetBytes(BarCode).Sum(b => b) / 200) % Products_Hash_Table.Length;
    }
    class Product
    {
        public string Name { get; set; }
        public string BarCode { get; set; }
        public double Price { get; set; }

        public static double Discount;
        public Product(string name, string barcode, double price)
        {
            Name = name;
            BarCode = barcode;
            Price = price;
        }
    }
}
