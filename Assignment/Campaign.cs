using System;

namespace Assignment
{
    /// <summary>
    /// <para>This class is responsible of managing determining a campaign.</para>
    /// <para>Its properties are used to determine how a product's prive is manipulated.</para>
    /// </summary>
    public class Campaign
    {
        /// <summary>
        /// <para>This value is expected to be unique among campaigns.</para>
        /// <para>It is not enforced programmatically except the fact that it is used as a key on campaigns dictionary.</para>
        /// </summary>
        /// <value>A valid name for the campaign. (e.g., C1, C2.)</value>
        public string name { get; }
        /// <summary>
        /// This refers to an existing product on Store's products dictionary as expected.
        /// </summary>
        /// <value>The unique code of the product.</value>
        public string productCode { get; }
        /// <summary>
        /// The duration is determined upon creation of the campaign and cannot be changed manually afterwards.
        /// </summary>
        /// <value>A valid integer with the unit "hour(s)".</value>
        public int duration { get; }
        /// <summary>
        /// The price manipulation limit is determined upon creation of the campaign and cannot be changed manually afterwards.
        /// </summary>
        /// <value>A valid integer that shows the percentage a price can be increased or decreased by.</value>
        public int priceManipulationLimit { get; }
        /// <summary>
        /// The target sales count is determined upon creation of the campaign and cannot be changed manually afterwards.
        /// </summary>
        /// <value>The amount of the products that is targeted to be sold.</value>
        public int targetSalesCount { get; }
        /// <summary>
        /// Indicates whether a campaign is active or not.
        /// </summary>
        /// <value>A boolean where true implies "Active" and false implies "Ended".</value>
        public bool isActive { get; set; }
        /// <summary>
        /// Indicates the total number of sales for the product with the campaign.
        /// </summary>
        /// <value>A valid integer that may change status of the campaign depending on targetSalesCount.</value>
        public int totalSales { get; set; }
        /// <summary>
        /// Indicates the total revenue of the campaign. Used to determine average item price.
        /// </summary>
        /// <value>A valid decimal.</value>
        public decimal turnover { get; set; }
        /// <summary>
        /// Indicates when does the campaign begin. Set during creation.
        /// </summary>
        /// <value>A valid DateTime object.</value>
        public DateTime startTime { get; set; }
        /// <summary>
        /// Saved in order to determine price changes and reset the product price when a campaign ends.
        /// </summary>
        /// <value>A valid decimal value.</value>
        /// 
        public decimal initialPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">A valid name for the campaign. (e.g., C1, C2.)</param>
        /// <param name="productCode">The unique code of the product.</param>
        /// <param name="duration">A valid integer with the unit "hour(s)".</param>
        /// <param name="priceManipulationLimit">A valid integer that shows the percentage a price can be increased or decreased by.</param>
        /// <param name="targetSalesCount">The amount of the products that is targeted to be sold.</param>
        public Campaign(string name, string productCode, int duration, int priceManipulationLimit, int targetSalesCount)
        {
            this.name = name;
            this.productCode = productCode;
            this.duration = duration;
            this.priceManipulationLimit = priceManipulationLimit;
            this.targetSalesCount = targetSalesCount;
            this.isActive = true;
            this.totalSales = 0;
            this.turnover = 0;
            // This should be updated during the creation of a new campaign.
            this.initialPrice = 0;
        }        
    }
}