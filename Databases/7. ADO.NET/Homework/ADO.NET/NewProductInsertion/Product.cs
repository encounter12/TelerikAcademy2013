namespace NewProductInsertion
{
    using System;
    using System.Linq;

    internal class Product
    {
        public Product(string productName, decimal unitPrice)
        {
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsInOrder { get; set; }
        public short ReorderLevel { get; set; }
        public byte Discontinued { get; set; }
    }
}
