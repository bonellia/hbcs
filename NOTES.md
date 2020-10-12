I have realized the flavor and non-technical explanations regarding the implementation of this app inside README.md could be disruptive, so I decided to extract more casual commentary here. This file doesn't necessarily contain important remarks regarding the solution, so feel free to read it if you are interested in some background.
## Disclaimer ##
I am aware that I had a rather lengthy README file for a fairly simple programming task and I feel the need to remark that I don't mean to "show off", be pretentious or anything.  
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
- Realize not having been practicing TDD.
- Start over to create two separate dotnet projects.
- Prepare unit tests.
- Move over the old code and refactor.
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
- You should usually assert only once in unit tests and you should have a valid reason to do more. In case your method modifies properties of another object, you unit test kinda slips towards integration test, but it maybe just inevitable.
- I was familiar with automated software testing, but I was inexperienced with TDD. I had to start over to actually perform TDD practices where having tests ready before the implementation is favored. Obviously, I had bunch of methods already implemented on my second attempt, but this time I refactored *after* tests.
- I tend to include too many comments in the code. I realized that the code should be self-explanatory, so I omitted the XML comments from the test code. For everything else, I tried to add consistent explanations for parameters, methods/class summaries etc. I should be able to generate and XML document when I am done given that I don't forget it.

## Extras ##
*You could really skip these, unless you are interested in some flavor and potentially useful information regarding the assignment.*
#### **"Oh shit!" Moments** ####
- I've been using integer for prices, turns out [decimal is a better choice](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types) given that we manipulate prices by percentages.
- There comes a point where you need to print a string that you don't want to split by lines on CLI, but within the code itself for readability purposes. Turns out you can combine '@' and '$' special characters to achieve that in C#. However, this was still not enough, since it requires you to further eliminate indentation whitespace from the code.
#### **Resources** ####
We usually relay on Google, official docs and StackOverflow a lot, especially while developing on a stack we are not that familiar with. I figured I could include the bookmarks I saved during my research to further reflect some of the problems I have faced while coding. The following list is not ordered by visit during the implementation:
- [C# 101](https://www.youtube.com/playlist?list=PLdo4fOcmZ0oVxKLQCHpiUWun7vlJJvUiN)
- [.NET Core 101](https://www.youtube.com/playlist?list=PLdo4fOcmZ0oWoazjhXQzBKMrFuArxpW80)
- [.NET Core and Visual Studio Code](https://code.visualstudio.com/docs/languages/dotnet)
- [.NET project structure](https://gist.github.com/davidfowl/ed7564297c61fe9ab814)
- [git - What's the common practice of gitignore for aspnet core project - Stack Overflow](https://stackoverflow.com/questions/39289765/whats-the-common-practice-of-gitignore-for-aspnet-core-project)
- [index](http://fsprojects.github.io/ProjectScaffold/index.html#Getting-started)
- [Unit testing C# code in .NET Core using dotnet test and xUnit - .NET Core | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test)
- [How to add a line break in C# .NET documentation - Stack Overflow](https://stackoverflow.com/questions/7279108/how-to-add-a-line-break-in-c-sharp-net-documentation/15925302)
- [JSON-like syntax for dictionary/array initialization and operation · Discussion #1238 · dotnet/csharplang](https://github.com/dotnet/csharplang/discussions/1238)
- [xml comments - XML Auto Commenting C# in Visual Studio Code - Stack Overflow](https://stackoverflow.com/questions/34275209/xml-auto-commenting-c-sharp-in-visual-studio-code)
- [Dictionary<TKey,TValue>.KeyCollection(Dictionary<TKey,TValue>) Constructor (System.Collections.Generic) | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.keycollection.-ctor?view=netcore-3.1)
- [Compiler Error CS0120 | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs0120)
- [Testing .NET Core Apps with Visual Studio Code | Pluralsight](https://www.pluralsight.com/guides/testing-.net-core-apps-with-visual-studio-code)
- [c# - How do I represent a time only value in .NET? - Stack Overflow](https://stackoverflow.com/questions/2037283/how-do-i-represent-a-time-only-value-in-net)
- [DateTime.Now Property (System) | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.now?view=netcore-3.1)
- [DateTime.Add(TimeSpan) Method (System) | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.add?view=netcore-3.1)
- [c# - How to set time to midnight for current day? - Stack Overflow](https://stackoverflow.com/questions/13467230/how-to-set-time-to-midnight-for-current-day)
- [c# - DateTime Format like HH:mm 24 Hours without AM/PM - Stack Overflow](https://stackoverflow.com/questions/360982/datetime-format-like-hhmm-24-hours-without-am-pm)
- [Parse strings using String.Split (C# Guide) | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split)
- [How to convert a string to a number - C# Programming Guide | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number)
- [Readable C# equivalent of Python slice operation - Stack Overflow](https://stackoverflow.com/questions/20678653/readable-c-sharp-equivalent-of-python-slice-operation)
- [Building C# 8.0 | .NET Blog](https://devblogs.microsoft.com/dotnet/building-c-8-0/)
- [Single-Dimensional Arrays - C# Programming Guide | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays)
- [How YOU can get started with .NET Core and C# in VS Code](https://softchris.github.io/pages/dotnet-core.html#resources)
- [Explicitly Ignoring Exceptions in C# - Rick Strahl's Web Log](https://weblog.west-wind.com/posts/2018/Jun/16/Explicitly-Ignoring-Exceptions-in-C)
- [nouns - "Runtime", "run time", and "run-time" - English Language & Usage Stack Exchange](https://english.stackexchange.com/questions/67013/runtime-run-time-and-run-time)
- [Variable declaration in a C# switch statement - Stack Overflow](https://stackoverflow.com/questions/222601/variable-declaration-in-a-c-sharp-switch-statement)
- [demand graph - Google Search](https://www.google.com/search?q=demand+graph&tbm=isch&ved=2ahUKEwiTuIWpj6jsAhXHuxoKHSxkBr0Q2-cCegQIABAA&oq=demand+graph&gs_lcp=CgNpbWcQAzIECAAQQzICCAAyBAgAEEMyAggAMgIIADICCAAyAggAMgIIADICCAAyAggAUIlDWIlDYLZEaABwAHgAgAGHAYgBhwGSAQMwLjGYAQCgAQGqAQtnd3Mtd2l6LWltZ8ABAQ&sclient=img&ei=KKmAX5OEC8f3aqzImegL&bih=936&biw=1903&client=firefox-b-d&hl=en)
- [How to convert a string to a number - C# Programming Guide | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number)
- [Documenting your code with XML comments | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/codedoc)
- [c# - How to generate XML documentation for CSPROJ with multiple targets - Stack Overflow](https://stackoverflow.com/questions/47115877/how-to-generate-xml-documentation-for-csproj-with-multiple-targets)
- [E.g. vs. I.e.—How to Use Them Correctly | Grammarly](https://www.grammarly.com/blog/know-your-latin-i-e-vs-e-g/)
- [currency - What is the best data type to use for money in C#? - Stack Overflow](https://stackoverflow.com/questions/693372/what-is-the-best-data-type-to-use-for-money-in-c)
- [Floating-point numeric types - C# reference | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types)
- [@ - C# Reference | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/verbatim)
- [Best practices for writing unit tests - .NET Core | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)
- [Filtering out values from a C# Generic Dictionary - Stack Overflow](https://stackoverflow.com/questions/2131648/filtering-out-values-from-a-c-sharp-generic-dictionary)
- [c# - Check if a dictionary contains any key object with a specific property - Stack Overflow](https://stackoverflow.com/questions/52644691/check-if-a-dictionary-contains-any-key-object-with-a-specific-property)
- [c# - Is it important to unit test a constructor? - Stack Overflow](https://stackoverflow.com/questions/357929/is-it-important-to-unit-test-a-constructor)
- [Getting started: .NET Core with command line > xUnit.net](https://xunit.net/docs/getting-started/netcore/cmdline#write-first-theory)
- [unit test logic involving multiple classes - Stack Overflow](https://stackoverflow.com/questions/4722016/unit-test-logic-involving-multiple-classes/4722058)
- [Unit tests vs class tests | Arkency Blog](https://blog.arkency.com/2014/09/unit-tests-vs-class-tests/)
- [Should one unit test test a single method, or a single case of a method? - Quora](https://www.quora.com/Should-one-unit-test-test-a-single-method-or-a-single-case-of-a-method)
- [When to Use and Not Use var in C# - IntelliTect](https://intellitect.com/when-to-use-and-not-use-var-in-c/)
- [type safety - What is the difference between a strongly typed language and a statically typed language? - Stack Overflow](https://stackoverflow.com/questions/2690544/what-is-the-difference-between-a-strongly-typed-language-and-a-statically-typed)
- [Building self-contained, single executable .NET Core 3 CLI tools | radu's blog](https://radu-matei.com/blog/self-contained-dotnet-cli/)
- [How do I 'delete' and object in C# - General and Gameplay Programming - GameDev.net](https://gamedev.net/forums/topic/517038-how-do-i-delete-and-object-in-c/4361001/)
- [Logging in C# .NET Modern-day Practices: The Complete Guide - Michael's Coding Spot](https://michaelscodingspot.com/logging-in-dotnet/)
- [.net core - How to create a LoggerFactory with a ConsoleLoggerProvider? - Stack Overflow](https://stackoverflow.com/questions/53690820/how-to-create-a-loggerfactory-with-a-consoleloggerprovider)

No, I didn't manually generate the bookmark list. :D Turns out Firefox stores bookmarks in the profile folder in a file named `places.sqlite`. Here is the SQL query that I used to generate valid markdown links as a list:
```
-- 2568 is id of the parent folder I saved the assignment related bookmarks.
SELECT '- [' || mb.title || ']' || '(' || mp.url || ')'
FROM moz_bookmarks mb, moz_places mp
WHERE mb.parent = 2568 AND mb.fk = mp.id 
```