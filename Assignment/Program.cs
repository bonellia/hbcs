using System;
using System.IO;
using Serilog;
namespace Assignment
{

    class Program
    {
        static private bool manualMode;
        static void Main(string[] args)
        {
            // Microsoft.Extensions.Logging was not very intuitive for me, so I settled with Serilog.
            // However, I added it for demonstration purposes only, since it was recommended by Safak.
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                //.WriteTo.Console() Disabling it, so it doesn't interfere with the normal program output.
                .WriteTo.File("logs\\store.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information("Program has been started successfully.");
            Program myProgram = new Program();            
            Console.WriteLine("For automated tests, please copy your scenario files to \"scenarios\\\" directory and press Enter.");
            Console.WriteLine("For manual execution, please type \"manual\" and press Enter.");
            string operationMode = Console.ReadLine();
            
            manualMode = operationMode == "manual" ? true : false;
            if (manualMode)
            {
                Log.Information("The operation mode has been set to manual.");
                Console.WriteLine("You can see a list of commands with \"help\".");
                string[] commands = new string[] {"help"};
                myProgram.CreateStoreAndProceedManually(commands);
            }
            else
            {
                Log.Information("The operation mode has been set to automated.");
                try
                {
                    string[] scenarioFiles = Directory.GetFiles("./scenarios");
                    Log.Information("Scenario files has been read successfully.");
                    foreach (var scenarioFile in scenarioFiles)
                    {
                        Log.Information($"Reading the commands from the scenario file on directory \"{scenarioFile}\".");
                        string[] commands = File.ReadAllLines(scenarioFile);
                        Log.Information($"Running the commands for the scenario file on directory \"{scenarioFile}\".");
                        myProgram.CreateStoreAndProceedAutomatically(commands);
                    }
                    // To keep the app open after automated run has been completed, so the user can view the output within the CLI.
                    Console.ReadLine();
                }
                catch (System.Exception)
                {
                    Log.Error("Failed to read scenario files.");
                }
                
            }
        }
        private void CreateStoreAndProceedManually(string[] commands)
        {
            
            Log.Information("Enabling interactive mode for manual command execution.");
            ProcessCommands(manualMode, commands);
        }
        private void CreateStoreAndProceedAutomatically(string[] commands)
        {
            Log.Information($"Processing {commands.Length} commands in automated mode.");
            ProcessCommands(manualMode, commands);
        }
        private void ProcessCommands(bool manualMode, string[] commands)
        {
            Log.Information("Instantiating a new Util object to be used for input parsing.");
            Util util = new Util();
            Log.Information("Instantiating a new store to run commands.");
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
                        // I believe in garbage collector.
                        Log.Information("Resetting the store.");
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
