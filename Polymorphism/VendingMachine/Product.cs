namespace VendingMachine
{
    public struct Product
    {
        public int Available { get; set; }
        public Money Price { get; set; }
        public string Name { get; set; }

        public Product(string name, Money price, int numAvailable)
        {
            Name = name;
            Price = price;
            Available = numAvailable;
        }

        public override string ToString()
        {
            return $"{Name}: {Price.ToString()}, Amount: {Available}";
        }
    }
}
