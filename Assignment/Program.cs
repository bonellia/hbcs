using System;
namespace Assignment
{

    class Program
    {
        static void Main(string[] args)
        {
            Util util = new Util();
            Store myStore = new Store();
            Console.WriteLine($"A new store has been opened.");
            Console.WriteLine("You can see a list of commands with \"help\".");

            // We would like program to keep running, unless its execution is interrupted manually.
            // Every time a new command (and parameters) is provided, we can call the relevant Store method.
            while (true)
            {
                string userInput = Console.ReadLine();
                string command = util.GetCommandFromUserInput(userInput);
                string[] parameters = util.GetParametersFromUserInput(userInput);
                // Usage of switch statement is quite controversial, but I like it anyways when used right.
                switch (command)
                {
                    // It wouldn't really hurt to have some extra information within the program itself.
                    case ("help"):
                    {
                        Console.WriteLine("create_product PRODUCTCODE PRICE STOCK - Creates product in your system with given product information.");
                        Console.WriteLine("get_product_info PRODUCTCODE - Prints product information for given product code.");
                        Console.WriteLine("create_order PRODUCTCODE - Creates order in your system with given information.");
                        Console.WriteLine("create_campaign NAME PRODUCTCODE DURATION PMLIMIT TARGETSALESCOUNT - Creates campaign in your system with given information.");
                        Console.WriteLine("get_campaign_info NAME - Prints campaign information for given campaign name.");
                        Console.WriteLine("increase_time HOUR - Increates time in your system.");
                        break;
                    }
                    case ("create_product"):
                    {
                        // Obviously parameters are ordered and I could just use parameters[1], parameters[2] etc. on method call.
                        // However, I'd like to favor readibility on line count - readability trade-off.
                        // The need to parse strings to numbers would make function calls even longer anyways.
                        string productCode = parameters[0];
                        decimal price = decimal.Parse(parameters[1]);
                        int stock = Int32.Parse(parameters[2]);
                        myStore.CreateProduct(productCode, price, stock);
                        break;
                    }
                    case ("get_product_info"):
                    {
                        string productCode = parameters[0];
                        myStore.GetProductInfo(productCode);
                        break;
                    }
                    case ("create_order"):
                    {
                        string productCode = parameters[0];
                        int quantity = Int32.Parse(parameters[1]);
                        myStore.CreateOrder(productCode, quantity);
                        break;
                    }
                    case ("create_campaign"):
                    {
                        string name = parameters[0];
                        string productCode = parameters[1];
                        int duration = Int32.Parse(parameters[2]);
                        int priceManipulationLimit = Int32.Parse(parameters[3]);
                        int targetSalesCount = Int32.Parse(parameters[4]);
                        myStore.CreateCampaign(name, productCode, duration, priceManipulationLimit, targetSalesCount);
                        break;
                    }
                    case ("get_campaign_info"):
                    {
                        string name = parameters[0];
                        myStore.GetCampaignInfo(name);
                        break;
                    }
                    case ("increase_time"):
                    {
                        int hour = Int32.Parse(parameters[0]);
                        myStore.IncreaseTime(hour);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid command. Please use \"help\" to check available commands.");
                        break;
                    }
                }

            }

        }
    }
}
