// See https://aka.ms/new-console-template for more information
using ExamplesCSharp;

Console.WriteLine("Hello, World!");

// lambda definition (using statement)
Func<int, int> square = x => 
    { 
            return x * x; 
    };
// lambda definition (using expression)
Func<int, int> square2 = x => x * x;

// simulated record via update methods
var user = new User("New User", DateTime.Now);
var updatedName = user.WithName("alice");

// immutable update syntax for records
var user2 = new User2() { Name = "New User", LastSeen = DateTime.Now };
var updatedName2 = user2 with { Name = "alice" };




//LinqExample.RunLinqExample(args[0]);
LinqExample.OnDemandEvaluation(args[0]);
LinqSideEffects.OnDemandEvaluation();
MapReduceHandsOn.Run(args[0],args[1]);