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
## Design Choices ##
*I would like to provide my reasonings for choosing one way over another in this section.*
#### **Tech Stack** ####
This project was firstly intended to be implemented using node.js, but considering the tech stack hiring firm uses, I decided to switch to .NET Core with C#.

#### **Project Layout** ####
There seems to be a lot of discussions and *some* conventions regarding how files and folders are placed within projects that are built using .NET. I have decided to have a more simplistic approach and do not spend too much time decided "how to perfect where everything should be".

#### **Main Memory vs Secondary Storage** ####
Use of a relational database would probably be favored in a real life scenario. However in-memory containers has been used to store runtime data for sake of simplicity, so the program data only lives throughout runtime. To prevent data-loss between contexts, try-catch blocks are utilized to keep program running without needing to set a store state from the beginning.

### **Parsing User Input** ###
I have decided to keep usage of external libraries to a minimum. Plus, it is a fun challenge to think of invalid inputs and handle them within the code. I used simple methods within `Util` class to take care of these.

#### **Documentation** ####
I always appreciate having Javadoc style documentation comments while using libraries, so I try to use them on any programming language I work with given that the language supports it (Typescript, Python). All the methods as well as classes have XML comments within the source code. I have tried to support them by adding regular comments to further elaborate on usage of certain statements. These should suffice to understand what is going on within the code, but I will still be adding a section to explain how to use the program.

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
- Remaining time: Denoted by `duration` / `current_time`.
- Demand coefficient: Denoted by `current_sales_rate` / `expected_sales_rate`.
#### **Extra Considerations** ####
The price could be increased exponentially, but that would probably have some complications such as customers thinking the vendor is taking advantage of the demand. On the other hand, if the price was dropping agressively, this could prevent the possibility of having sales on a higher price on average. to find a healthy balance between these two, `remaining time` factor is considered. The price of a campaign product is manipulated considering the following on any `increase_time()` trigger:
- Calculate demand coefficient.
- If it is higher than 1, increase the price by `price manipulation limit` / `remaining_time` percent.
- If it is equal to 1, do not change the price.
- If it is less than 1, decrease the price by `price manipulation limit` / `remaining_time` percent.

This ensures that the price will be increased or decreased considering the remaining time and ideally reaching the maximum or minimum price as late as possible to prevent complications or losses mentioned above.

