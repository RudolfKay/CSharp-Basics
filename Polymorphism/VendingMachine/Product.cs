namespace VendingMachine
{
    public struct Product
    {
        ///<summary>Gets or sets the available amount of product.</summary>
        public int Available { get; set; }
        ///<summary>Gets or sets the product price.</summary>
        public Money Price { get; set; }
        ///<summary>Gets or sets the product name.</summary>
        public string Name { get; set; }

        public Product(string name, Money price, int numAvailable)
        {
            Name = name;
            Price = price;
            Available = numAvailable;
        }

        public override string ToString()
        {
            return $"{Name}: {Price.ToString()}, {Available}";
        }
    }
}
