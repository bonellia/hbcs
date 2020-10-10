namespace Assignment
{
    /// <summary>
    /// 
    /// </summary>
    public class Product
    {
        /// <summary>
        /// <para>This value is expected to be unique among products.</para>
        /// <para>It is not enforced programmatically except the fact that it is used as a key on campaigns dictionary.</para>
        /// </summary>
        /// <value>A valid, unique code for the campaign. (e.g., P1, P2.)</value>
        public string productCode { get; }
        /// <summary>
        /// This value is manipulated during the campaigns depending on the demand.
        /// </summary>
        /// <value>A decimal number that denotes the product's price.</value>
        public decimal price { get; set; }
        /// <summary>
        /// This value decreased by successful orders, but cannot be increased.
        /// </summary>
        /// <value>A valid integer that shouldn't be negative at any time.</value>
        public int stock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCode">A valid, unique code for the campaign. (e.g., P1, P2.)</param>
        /// <param name="price">A decimal number that denotes the product's price.</param>
        /// <param name="stock">A valid integer that shouldn't be negative at any time.</param>
        public Product(string productCode, decimal price, int stock)
        {
            this.productCode = productCode;
            this.price = price;
            this.stock = stock;
        }
    }
}