## Technical questions

1. How long did you spend on the coding assignment? What would you add to your solution if you had
more time? If you didn't spend much time on the coding assignment then use this as an opportunity to
explain what you would add.

aprox. 3.5 hours
I would add pipeline behaviours or abstractions to handle cross-cutting concerns such as exceptions handling, logging etc.
I would add validation (input) using FluentValidations
Obviously more unittests :P

2. What was the most useful feature that was added to the latest version of your language of choice?
Please include a snippet of code that shows how you've used it.

# File-scoped namespace 

```csharp
namespace CryptoQuotation.Service.Application;

public static class DependencyInjection ..
```

# Global usings

```csharp
global using MediatR;
```

3. How would you track down a performance issue in production? Have you ever had to do this?

Yes, though the solution depends on how the software is hosted/developed etc. Usually going through the application logs is a good start
or use extensions on Azure Monitor (suchs as app insights) or I believe it's called Alerts in AWS.
If there's no standard tooling available because it's on premise or a legacy application you could use tools like performance profilers such as dotTrace.
And if profiling is a no-go on a production environment (since it slows down the application even more) we could try and see if we can reproduce the performance issue
on a different environment (most likely Acceptance)

4. What was the latest technical book you have read or tech conference you have been to? What did you learn?

hmm.. that was a long time ago when I read a book.. When I am interested in a particular subject I resort to youtube. e.g. 
[clean architecture](https://www.youtube.com/watch?v=dK4Yb6-LxAk) or I watch youtube channels such as Scott Hanselman. What I try to learn is understanding the concepts explained and which tooling / libraries exists to use for solving commen problems related to these concepts. e.g. you could implement your own Mediator design pattern or use the nuget package.

5. What do you think about this technical assessment?
Great. Though I might have overengineered it a bit. I could have done the assignment in half the time and put everything in one project. But then I had to explain that that's not usually how I
structure my code. This setup, however, is more suitable for somewhat larger projects.

6. Please, describe yourself using JSON.

```json
{
  "whoAmI": {
    "name": "Remco Franken",
    "age": 48,
    "description": "Besides beeing a software craftsman that enjoys software architecture and writing code I'm also married and have two young daughters. And just to spice things up a bit I've included an array of hobbies :D",
    "hobbies": [
      "Play Tennis",
      "Play videogames.. still",
      "Hangout with friends and drinking some good wines",
      "Watching movies"
    ]
  }
}
```

