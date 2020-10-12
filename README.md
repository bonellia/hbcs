Please view `NOTES.md` file for more casual information regarding the assignment.
## Getting Started ##
To run the program, you need .NET Core runtime libraries installed on your system.
In the root directory of the project, navigate to Assignment folder. To start the program, run the following:
```
dotnet restore
dotnet run
```
The program has two modes:
- Automated mode: Runs all the scenarios placed to `scenarios` folder. Activated with Enter as soon as program starts.
- Manual mode: Interactive execution with manually entered commands. Activated by typing "manual" and pressing Enter.
To run the tests, run the following command from the root project directory:
```
dotnet test
```
Standalone executables will be uploaded and shared, but I highly recommend using a CLI to run the program.
## Purpose ##
This program has been written as the solution of an assignment for an online retailer firm.  
The main objective is to demonstrate various programming skills, so it is obviously not recommended for production use.

## Requirements ##
*This section contains information derived from the assignment document provided by the firm and explains details that would be normally included in an SRS document for a full project.*
#### **Domain** ####
The domain of the software is an e-commerce platform and the program is expected to be a campaign module that manipulates product prices according to demand.

The changes in the system is triggered manually by hourly increments on the current time.  
How the prices change depends on an algorithm determined by the developer. The algorithm used to update prices is explained further in this document.
#### **Entities** ####
The following list contains the entities and their relevant attributes:
- Product: product code, price, stock.
- Order: product code, quantity.
- Campaign: name, product code, duration, price manipulation limit, target sales count.

#### **Program Functions** ####
- `create_product()` - Creates product in your system with given product information.
- `get_product_info()` - Prints product information for given product code.
- `create_order()` - Creates order in your system with given information.
- `create_campaign()` - Creates campaign in your system with given information.
- `get_campaign_info()` - Prints campaign information for given campaign name.
- `increase_time()` - Increases time in the system.
## Design-Implementation Choices ##
*I would like to provide my reasonings for choosing one way over another in this section.*
### Tech Stack ###
This project was firstly intended to be implemented using node.js, but considering the tech stack hiring firm uses, I decided to switch to .NET Core with C#.

### Project Layout ###
There seems to be a lot of discussions and *some* conventions regarding how files and folders are placed within projects that are built using .NET. I have decided to have a more simplistic approach and do not spend too much time decided "how to perfect where everything should be".

### Strict-Loose Typing ###
Given the chance, I prefer strictly typed variables. However, there are advantages to loosely typing as well. In C#, as long as the right-hand-side implies the type, "var" could probably be used anywhere. Briefly, I decided to be more pedantic on the actual source code while I was satisfied enough to use "var" in general on tests. From readability and intuitiveness perspective, I hope both the test and application code are clear enough.

### Main Memory vs Secondary Storage ###
Use of a relational database would probably be favored in a real life scenario. However in-memory containers has been used to store runtime data for sake of simplicity, so the program data only lives throughout runtime. To prevent data-loss between contexts, try-catch blocks are utilized to keep program running without needing to set a store state from the beginning.

### Logging ###
I was going to skip it altogether, but I was suggested that it could be handy to have logs around, so even if the program is a CLI app that basically prints log-like information to screen all the time, I still added and used a logging package (Serilog) just for the demonstration purposes. To be quite honest, I didn't really have so much time to be precise with the logging levels and spread the logs everywhere within the code since I was running out ot time. I suppose on a production code, they should be taken much more seriously.

### Parsing User Input ###
I have decided to keep usage of external libraries to a minimum. Plus, it is a fun challenge to think of invalid inputs and handle them within the code. I used simple methods within `Util` class to take care of these.

### Documentation ###
I always appreciate having Javadoc style documentation comments while using libraries, so I try to use them on any programming language I work with given that the language supports it (Typescript, Python). All the methods as well as classes have XML comments within the source code. I have tried to support them by adding regular comments to further elaborate on usage of certain statements. These should suffice to understand what is going on within the code, but I will still be adding a section to explain how to use the program.

### Testing ###
On my first attempt, I realized I was using BDD over TDD. After realizing that it was favored for this assignment, I started over. Obviously I still used decent amount of implementation from the first iteration of the solution, but this time I created unit tests and refactored my code considering my tests. xUnit seemed to be more than enough for my needs. I used "Arrange, Act, Assert" pattern on my unit testing, because apparently it is a common pattern that separates test code neatly. I needed to use multiple assertions on some tests due to nature of the requested methods (e.g., it is necessary to check stock of a product when an order was successful), but I tried not to slip to integration testing while adding extra assertions. I acknowledge that string comparison on assetions are a bit sketchy (with all the rounding numbers all over the place), but for this assignment I decided not to return objects and add another set of methods to transform into success/failure messages.

## The Algorithm ##
*This section contains information regarding the way price is manipulated. No, there is no machine learning whatsoever.*
#### **Missing Parameters** ####
There could be various approaches to determine how the price changes. The first thing that comes to mind is to change the price linearly depending on demand. A more sophisticated solution could be possible with the addition of the following parameters:
- Number of times the product appearing on search results.
- Number of times the product's page being viewed by customers.
- Number of times the product being added to the shopping card by customers.
- Number of times the product is purchased by regular customers.  
#### **Candidate Factors** ####
The list of factors to dynamically determine a campaign product's price could go on forever depending on what kind of telemetry is being used on the platform. However, these are irrelevant within the scope of this assignment, so I decided to come up with a more simplistic solution using the following factors:
- Expected sales rate: Denoted by `target_sales_count` / `duration`.
- Current sales rate: Denoted by `current_sale_count` / `current_time`.
- Demand coefficient: Denoted by `current_sales_rate` / `expected_sales_rate`.
- Maximum change (%): Denoted by `manipulation limit` / `duration`.
#### **Extra Considerations** ####
The price could be increased exponentially, but that would probably have some complications such as customers thinking the vendor is taking advantage of the demand. On the other hand, if the price was dropping agressively, this could prevent the possibility of having sales on a higher price on average.  
I wanted demand coefficient to impact how agressive price should be manipulated. It works as follows:
| Demand Coefficient | Change Coefficient | Limit: 20, Duration: 10 Change by % |
|:------------------:|:------------------:|:-----------------------------------:|
|       [0, 0.5)     |         -1         |                 -2%                 |
|       [0.5, 1)     |        -0.5        |                 -1%                 |
|          1         |          0         |                  0                  |
|       (1, 2)       |         0.5        |                 +1%                 |
|       [2, ∞)       |          1         |                 +2%                 |

You can visit [the following Google Sheet](https://docs.google.com/spreadsheets/d/1pRwqkjXN6CzEHF8PI20mhAxdsrnBTRuip2qZcxtt2eY/edit?usp=sharing) to view how relevant parameters change as a table and graph for scenario 1 and scenario 5 using this approach.
This ensures that the price will be increased or decreased considering the demand and ideally reaching the maximum or minimum price as late as possible to prevent complications or losses mentioned above. One advantage of using such a method is that we don't really need to keep track of previous price changes.  
An important detail is that we **shouldn't** be increasing/decreasing the price compoundly (i.e., price + price*percentage), since price could potentially breach the upper/lower limit. To achieve that, I decided to save initial price on campaign and use it to apply percentage based price updates.
