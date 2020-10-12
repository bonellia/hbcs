using System;
using System.IO;
namespace Assignment
{

    class Program
    {
        static private bool manualMode;
        static void Main(string[] args)
        {
            
            Program myProgram = new Program();            
            Console.WriteLine("For automated tests, please copy your scenario files to \"scenarios\\\" directory and press Enter.");
            Console.WriteLine("For manual execution, please type \"manual\" and press Enter.");
            string operationMode = Console.ReadLine();
            manualMode = operationMode == "manual" ? true : false;
            if (manualMode)
            {
                Console.WriteLine("You can see a list of commands with \"help\".");
                string[] commands = new string[] {"help"};
                myProgram.CreateStoreAndProceedManually(commands);
            }
            else
            {
                string[] scenarioFiles = Directory.GetFiles("./scenarios");
                foreach (var scenarioFile in scenarioFiles)
                {
                    Console.WriteLine($"[{scenarioFile}] : Running the commands...");
                    string[] commands = File.ReadAllLines(scenarioFile);
                    myProgram.CreateStoreAndProceedAutomatically(commands);
                }
            }
        }
        private void CreateStoreAndProceedManually(string[] commands)
        {
            ProcessCommands(manualMode, commands);
        }
        private void CreateStoreAndProceedAutomatically(string[] commands)
        {
            ProcessCommands(manualMode, commands);
        }
        private void ProcessCommands(bool manualMode, string[] commands)
        {
            Util util = new Util();
            Store myStore = new Store();
            int counter = 0;
            // We would like program to keep running, unless its execution is interrupted manually.
            // Every time a new command (and parameters) is provided, we can call the relevant Store method.
            while (true)
            {
                
                string userInput;
                if (manualMode)
                {
                    userInput = Console.ReadLine();
                }
                else
                {
                    userInput = commands[counter++];
                    if (counter == commands.Length)
                    {
                        break;
                    }
                }                    
                string command = util.GetCommandFromUserInput(userInput);
                string[] parameters = util.GetParametersFromUserInput(userInput);
                // Usage of switch statement is quite controversial, but I like it anyways when used right.
                switch (command)
                {
                    // Some people like to push Enter key on a CLI application.
                    // This case allows adding empty lines without triggering "Invalid command." warning.
                    case (""):
                        {
                            break;
                        }
                    // A help command could be handy to have some extra information within the program itself.
                    case ("help"):
                        {
                            Console.WriteLine("create_product PRODUCTCODE PRICE STOCK - Creates product in your system with given product information.");
                            Console.WriteLine("get_product_info PRODUCTCODE - Prints product information for given product code.");
                            Console.WriteLine("create_order PRODUCTCODE - Creates order in your system with given information.");
                            Console.WriteLine("create_campaign NAME PRODUCTCODE DURATION PMLIMIT TARGETSALESCOUNT - Creates campaign in your system with given information.");
                            Console.WriteLine("get_campaign_info NAME - Prints campaign information for given campaign name.");
                            Console.WriteLine("increase_time HOUR - Increates time in your system.");
                            Console.WriteLine("reset - Resets the store and all the configuration.");
                            break;
                        }
                    // User may want to start over without having to re-open the program.
                    case ("reset"):
                    {
                        // I beleive in garbage collector.
                        myStore = null;
                        myStore = new Store();
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
                            Console.WriteLine(myStore.CreateProduct(productCode, price, stock));
                            break;
                        }
                    case ("get_product_info"):
                        {
                            string productCode = parameters[0];
                            Console.WriteLine(myStore.GetProductInfo(productCode));
                            break;
                        }
                    case ("create_order"):
                        {
                            string productCode = parameters[0];
                            int quantity = Int32.Parse(parameters[1]);
                            Console.WriteLine(myStore.CreateOrder(productCode, quantity));
                            break;
                        }
                    case ("create_campaign"):
                        {
                            string name = parameters[0];
                            string productCode = parameters[1];
                            int duration = Int32.Parse(parameters[2]);
                            int priceManipulationLimit = Int32.Parse(parameters[3]);
                            int targetSalesCount = Int32.Parse(parameters[4]);
                            Console.WriteLine(myStore.CreateCampaign(name, productCode, duration, priceManipulationLimit, targetSalesCount));
                            break;
                        }
                    case ("get_campaign_info"):
                        {
                            string name = parameters[0];
                            Console.WriteLine(myStore.GetCampaignInfo(name));
                            break;
                        }
                    case ("increase_time"):
                        {
                            int hour = Int32.Parse(parameters[0]);
                            Console.WriteLine(myStore.IncreaseTime(hour));
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
