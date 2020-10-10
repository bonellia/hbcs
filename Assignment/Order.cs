namespace Assignment
{
    /// <summary>
    /// <para>This class is responsible of containing different orders as separate instances.</para>
    /// <para>Orders are not uniquely identified by their properties, but every instance of an order object is still unique.</para>
    /// </summary>
    public class Order
    {
        /// <value>An alphanumeric string for the product.</value>
        public string productCode { get; }
        /// <value>A number that shows how many of the given product is ordered.</value>
        public int quantity { get; }

        /// <summary>
        /// <para>An order is created using the given parameters and added to orders lists on Store instance it is created.</para>
        /// <para>It cannot be modified after it is created.</para>
        /// </summary>
        /// <param name="productCode">An alphanumeric string for the product.</param>
        /// <param name="quantity">A number that shows how many of the given product is ordered.</param>
        public Order(string productCode, int quantity)
        {
            this.productCode = productCode;
            this.quantity = quantity;
        }
    
    }
}