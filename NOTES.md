I have realized the flavor and non-technical explanations regarding the implementation of this app inside README.md could be disruptive, so I decided to extract more casual commentary here. This file doesn't necessarily contain important remarks regarding the solution, so feel free to read it if you are interested in some background.
## Disclaimer ##
I am aware that I had a rather lengthy README file for a fairly simple programming task, but I should remark that I don't mean to "show off", be pretentious or anything.  
My reasoning behind providing this much details is as follows:
- It has been stated that so-called "soft skills" are appreciated as much as technical skills by the firm, so I wanted to expose my thought process and the way I express my decision making thoroughly. Hopefully, my clumsiness with the framework will be somehow negligible with the help of these elaborate explanations.
- I usually assume that certain details could be overlooked, or worse, misinterpreted if they were only shown within the code for any project. I believe it is vital to have some sort of documentation to review or understand one another's code.
- Finally, I have the intention to have this small project as a reference to myself in the future, so there is that.  

**No code snippet that is found online or from previous personal projects has been used during the implementation of this project.**

## Timeline ##
The project is created doing the following, in a slightly mixed order:
- Read the assignment explanation document provided by the firm.
- Decide which technologies to use.
- Determine the classes, attributes and methods to be implemented.
- Implement features and test them. 
- Document the code.
- Review the project.
- Package the program.
- Request feedback before final submission.
- Deliver.

## Conclusion ##
Overall, it has been a refreshing experience to work on a small project that had nicely determined requirements while having a lot of freedom. I would probably not find myself building this with the intention of demonstrating my programming skills, unless it wasn't requested by third parties, so it was a nice opportunity to dust off my syntax knowledge for .NET and C#.
#### **What I Learned?** ####
- Although I don't have strong opinions on programming languages and different technologies in general, I realized I feel much more comfortable coding when I am using a high-level language. I have always cared about the availability of good documentation and community support using a technology whether it is a physical product or a software library. In that regard, C# and .NET Core seems to be matured enough and I would consider using them safely in the future on my personal projects as well.
- Domain knowledge for e-commerce platforms come naturally by simply being a customer and using them as well, but I had chance to take a second and appreciate my formal education, since whether it was a database design project or a software requirements specification assignment; we have been exposed to the business side of the online retailers and having this perspective was quite useful while completing this project.

## Extras ##
*You could really skip these, unless you are interested in some flavor and potentially useful information regarding the assignment.*
#### **"Oh shit!" Moments** ####
- I've been using integer for prices, turns out [decimal is a better choice](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types) given that we manipulate prices by percentages.
- There comes a point where you need to print a string that you don't want to split by lines on CLI, but within the code itself for readability purposes. Turns out you can combine '@' and '$' special characters to achieve that in C#. However, this was still not enough, since it requires you to further eliminate indentation whitespace from the code.
#### **Resources** ####
We usually relay on Google, official docs and StackOverflow a lot, especially while developing on a stack we are not that familiar with. I figured I could include the bookmarks I saved during my research to further reflect some of the problems I have faced while coding. The following list is not ordered by visit during the implementation:
- []()
- []()
- []()
- []()
- []()
- []()
- []()
- []()