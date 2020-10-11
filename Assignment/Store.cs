using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    /// <summary>
    /// <para>This class is responsible of managing products, orders and campaigns.</para>
    /// <para>It contains various methods to manipulate these entities.</para>
    /// </summary>
    public class Store
    {
        // Initially I was going to use SQLite to save program data more consistently.
        // Then I decided to just use in-memory containers for sake of simplicity.
        // I assumed the following:
        // - Each product is uniquely identified by its product code.
        // - Each campaign is uniquely identified by its name.
        private Dictionary<string, Product> products;
        private List<Order> orders;
        private Dictionary<string, Campaign> campaigns;

        // I could just use integers for simplicity, but I wanted to make use of built-in libraries.
        private DateTime time;

        /// <summary>
        /// <para>Generates a new store object with products, orders and campaigns.</para>
        /// <para>Initially it has no products, orders or campaigns. These should be added using relevant methods.</para>
        /// </summary>
        public Store()
        {
            this.products = new Dictionary<string, Product>();
            this.orders = new List<Order>();
            this.campaigns = new Dictionary<string, Campaign>();
            this.time = DateTime.Today;
        }

        // There is no need for a DAO (Data Access Object) since we don't use a DB.
        // However, we could still use some CRUD-like operations on our containers.

        /// <summary>
        /// <para>Creates a new product with the given parameters.</para>
        /// <para>Newly created product is then added to the products dictionary.</para>
        /// </summary>
        /// <param name="productCode">A valid, unique code for the campaign. (e.g., P1, P2.)</param>
        /// <param name="price">A decimal number that denotes the product's price.</param>
        /// <param name="stock">A valid integer that shouldn't be negative at any time.</param>
        /// <returns>
        /// A message that depends on the success of the operation. Sample output:
        /// <list type="bullet">
        /// <item>Success: Product created; code P1, price 100, stock 1000</item>
        /// <item>Failure: A product with the code P1 already exists.</item>
        /// </list>
        /// </returns>
        public string CreateProduct(string productCode, decimal price, int stock)
        {
            try
            {
                Product newProduct = new Product(productCode, price, stock);
                this.products.Add(productCode, newProduct);
                return $"Product created; code {newProduct.productCode}, price {newProduct.price}, stock {newProduct.stock}";
            }
            catch (System.ArgumentException)
            {
                return $"A product with the code {productCode} already exists.";
            }

        }
        /// <summary>
        /// Prepares a formatted string to indicate current status of a product.
        /// </summary>
        /// <param name="productCode">A valid, unique product code for the product. (e.g., P1, P2.)</param>
        /// <returns>
        /// A message that depends on the success of the operation. Sample output:
        /// <list type="bullet">
        /// <item>Success: Product P1 info; price 100, stock 1000</item>
        /// <item>Failure: Could not find a product with the code P2.</item>
        /// </list>
        /// </returns>
        public string GetProductInfo(string productCode)
        {
            try
            {
                Product theProduct = this.products.GetValueOrDefault(productCode);
                return $"Product {theProduct.productCode} info; price {theProduct.price}, stock {theProduct.stock}";
            }
            catch (System.NullReferenceException)
            {
                return $"Could not find a product with the code {productCode}.";
                // We don't want to throw an exception, since we want program to keep going.
                //throw;
            }
        }
        /// <summary>
        /// Creates an order, updates the following:
        /// <list type="bullet">
        /// <item>Stock of product, if such a product exists and applicable.</item>
        /// <item>Total sales of the campaign, if such a campaign exists for the given product.</item>
        /// <item>Turnover of the campaign, if such a campaign exists.</item>
        /// </list>
        /// </summary>
        /// <param name="productCode">A valid, unique code for the campaign. (e.g., P1, P2.)</param>
        /// <param name="quantity">A number that shows how many of the given product is ordered.</param>
        /// <returns>A message that depends on the success of the operation.</returns>
        public string CreateOrder(string productCode, int quantity)
        {
            // TODO: Check if such a product exists, warn if it doesnt.
            // TODO: Check if stock suffices, warn if it doesnt.
            // TODO: Check if a campaign exists, update the campaign attributes if it does.
            bool productExists = products.ContainsKey(productCode);
            if (productExists)
            {
                Product theProduct = this.products.GetValueOrDefault(productCode);
                bool stockSuffices = theProduct.stock >= quantity;
                if (stockSuffices)
                {
                    bool campaignForProductExists = campaigns.ContainsKey(productCode);
                    if (campaignForProductExists)
                    {
                        Campaign theCampaign = this.campaigns.GetValueOrDefault(productCode);
                        theProduct.stock -= quantity;
                        theCampaign.totalSales += quantity;
                        theCampaign.turnover += theProduct.price * quantity;
                        return $"Order created; product {productCode}, quantity {quantity}";
                    }
                    else
                    {
                        theProduct.stock -= quantity;
                        return $"Order created; product {productCode}, quantity {quantity}";
                    }
                }
                else
                {
                    return $"Order failed; insufficient stock ({theProduct.stock}) for the product {theProduct.productCode}.";
                }
            }
            else
            {
                return $"Order failed; no product with the product code {productCode}.";
            }
        }
        /// <summary>
        /// Creates a campaign if the following conditions met:
        /// <list type="bullet">
        /// <item> A campaign for the given product code does not already exist.</item>
        /// <item> A product with the given product code exists.</item>
        /// <item> There is enough stock for the target sales count.</item>
        /// </list>
        /// Rest of the parameters are assumed to be valid. (e.g., duration is positive.)
        /// </summary>
        /// <param name="name">A valid name for the campaign. (e.g., C1, C2.)</param>
        /// <param name="productCode">The unique code of the product.</param>
        /// <param name="duration">A valid integer with the unit "hour(s)".</param>
        /// <param name="priceManipulationLimit">A valid integer that shows the percentage a price can be increased or decreased by.</param>
        /// <param name="targetSalesCount">The amount of the products that is targeted to be sold.</param>
        /// <returns>
        /// A message that depends on the success of the operation. Sample output:
        /// <list type="bullet">
        /// <item>Success: Campaign created; name C1, product P1, duration 10, limit 20, target sales count 100</item>
        /// <item>Failure: Cannot create a campaign with the product code P1, since a campaign for this product already exists.</item>
        /// <item>Failure: Cannot create a campaign for the product P1, since the product stock (10) is insufficient.</item>
        /// <item>Failure: Cannot create a campaign for the product P1, since such a product does not exist.</item>
        /// </list>
        /// </returns>
        public string CreateCampaign(string name, string productCode, int duration, int priceManipulationLimit, int targetSalesCount)
        {
            bool productExists = products.ContainsKey(productCode);
            if (productExists)
            {
                int productStock = GetProduct(productCode).stock;
                if (productStock >= targetSalesCount)
                {
                    try
                    {
                        Campaign newCampaign = new Campaign(name, productCode, duration, priceManipulationLimit, targetSalesCount);
                        Product campaignProduct = GetProduct(productCode);
                        newCampaign.startTime = this.time;
                        newCampaign.initialPrice = campaignProduct.price;
                        this.campaigns.Add(productCode, newCampaign);
                        return
                            $@"Campaign created; 
                            name {newCampaign.name}, 
                            product {newCampaign.productCode}, 
                            duration {newCampaign.duration}, 
                            limit {newCampaign.priceManipulationLimit}, 
                            target sales count {newCampaign.targetSalesCount}"
                            .Replace(Environment.NewLine, "")
                            .Replace("    ", "");
                    }
                    catch (System.ArgumentException)
                    {
                        return $"Cannot create a campaign with the product code {productCode}, since a campaign for this product already exists.";
                    }
                }
                else
                {
                    return $"Cannot create a campaign for the product {productCode}, since the product stock ({productStock}) is insufficient.";
                }

            }
            else
            {
                return $"Cannot create a campaign for the product {productCode}, since such a product does not exist.";
            }

        }
        /// <summary>
        /// Prepares a formatted string to indicate current status of a campaign.
        /// </summary>
        /// <param name="name">A valid name for the campaign. (e.g., C1, C2.)</param>
        /// <returns>
        /// A message that depends on the success of the operation. Sample output:
        /// <list type="bullet">
        /// <item>Success: Campaign C1 info; Status Active, Target Sales 100, Total Sales 50, Turnover 5000, Average Item Price 100</item>
        /// <item>Failure: Could not find a campaign with the name C2.</item>
        /// </list>
        /// </returns>
        public string GetCampaignInfo(string name)
        {
            try
            {
                Campaign theCampaign = this.campaigns.Values.FirstOrDefault(campaign => campaign.name == name);
                string campaignStatus = theCampaign.isActive ? "Active" : "Ended";
                string averageItemPrice = theCampaign.totalSales == 0 ? "-" : $"{theCampaign.turnover / theCampaign.totalSales}";

                return
                        $@"Campaign {theCampaign.name} info; 
                        Status {campaignStatus}, 
                        Target Sales {theCampaign.targetSalesCount}, 
                        Total Sales {theCampaign.totalSales}, 
                        Turnover {theCampaign.turnover}, 
                        Average Item Price {averageItemPrice}"
                        .Replace(Environment.NewLine, "")
                        .Replace("    ", "");
            }
            catch (System.NullReferenceException)
            {
                return $"Could not find a campaign with the name {name}.";
                // We don't actually throw the exception, since we want program to keep going.
                // throw;
            }
        }
        /// <summary>
        /// This method advances time of the store and updates the following:
        /// <list type="bullet">
        /// <item>Price of the product, depending on demand coefficient.</item>
        /// <item>Is active status of the campaign, depending on duration and time.</item>
        /// <item>Demand coefficient which is used to determine price change for the campaign product.</item>
        /// </list>
        /// </summary>
        /// <param name="time">A valid integer, since the time is incremented in hours.</param>
        /// <returns>A message that depends on the success of the operation.</returns>
        public string IncreaseTime(int time)
        {
            TimeSpan timeToAdd = new TimeSpan(time, 0, 0);
            this.time = this.time.Add(timeToAdd);
            var activeCampaigns = this.campaigns.Values.Where(campaign => campaign.isActive);
            foreach (var campaign in activeCampaigns)
            {
                if (campaign.isActive)
                {
                    double timePassed = (this.time - campaign.startTime).TotalHours;

                    // If campaign needs to end, do it before further calculations:
                    if (timePassed > campaign.duration || campaign.totalSales >= campaign.targetSalesCount)
                    {
                        campaign.isActive = false;
                        var campaignProduct = GetProduct(campaign.productCode);
                        // Set price back to its initial value:
                        campaignProduct.price = campaign.initialPrice;
                    }
                    else
                    {
                        // We need some numbers first:
                        // e.g., 100 / 10 = 10, 10 sales per hour is the expected average.
                        double expectedSalesRate = campaign.targetSalesCount / campaign.duration;
                        // e.g., 100 / 5 = 20, 20 sales per hour up to now.
                        double currentSalesRate = campaign.totalSales / timePassed;
                        // e.g., 20 / 10 = 2, demand is high.
                        double demandCoefficient = currentSalesRate / expectedSalesRate;
                        // e.g., 20 / 10 = 2, 2% of initialPrice is the limit for price increase/decrease.
                        double maximumChangeByPercent = campaign.priceManipulationLimit / campaign.duration;
                        // We can manipulate the price now:
                        var campaignProduct = GetProduct(campaign.productCode);
                        if (0 <= demandCoefficient && demandCoefficient < 0.5)
                        {
                            campaignProduct.price += -1.0m * campaign.initialPrice * (decimal)maximumChangeByPercent / 100;
                        }
                        else if (0.5 <= demandCoefficient && demandCoefficient < 1)
                        {
                            campaignProduct.price += -0.5m * campaign.initialPrice * (decimal)maximumChangeByPercent / 100;
                        }
                        else if (demandCoefficient == 1)
                        {
                            // Basically does nothing, but couldn't help my completionist tendencies.
                            campaignProduct.price += 0 * campaign.initialPrice * (decimal)maximumChangeByPercent / 100;
                        }
                        else if (1 < demandCoefficient && demandCoefficient < 2)
                        {
                            campaignProduct.price += 0.5m * campaign.initialPrice * (decimal)maximumChangeByPercent / 100;
                        }
                        else if (2 <= demandCoefficient)
                        {
                            campaignProduct.price += 1.0m * campaign.initialPrice * (decimal)maximumChangeByPercent / 100;
                        }
                    }

                }

            }


            return $"Time is { this.time.ToString("HH:mm") }";
        }
        /// <summary>
        /// GetProductInfo or CreateProduct does not return the object itself, but this method does.
        /// </summary>
        /// <param name="productCode">A valid, unique product code for the product. (e.g., P1, P2.)</param>
        /// <returns>The product object if found, null otherwise.</returns>
        public Product GetProduct(string productCode)
        {
            return this.products.GetValueOrDefault(productCode);
        }
        /// <summary>
        /// GetCampaignInfo or CreateCampaign does not return the object itself, but this method does.
        /// </summary>
        /// <param name="productCode">A valid, unique product code for the product. (e.g., P1, P2.)</param>
        /// <returns>The campaign object if found, null otherwise.</returns>
        public Campaign GetCampaign(string productCode)
        {
            return this.campaigns.GetValueOrDefault(productCode);
        }
    }
}