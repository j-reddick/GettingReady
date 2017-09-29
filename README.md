# GettingReady
This is my implementation of the getting ready programming challenge. 

## Development notes
This was developed using Visual Studio 2017 and uses [string interpolation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interpolated-strings), which requires C# 6.0 or higher to compile. I do not have
other versions of Visual Studio installed, but it should compile with Visual Studio 2015 as well. Alternatively, it should compile
with any compilation method outside of Visual Studio that supports C# 6.0. 

## Design choices

### Person, ClothingItem, and ClothingType
This uses a simple Person class that has a collection of what pieces of clothing are being worn. In order to allow for 
flexibility in clothing names to change without affecting any existing rules surrounding the type of clothing, I created 
a simple ClothingItem object that requires a string name and a ClothingType enum representing the various types of clothing, 
such as Footwear or Shirt. Underlying names of the individual pieces of clothing can change without affecting the correctness 
of the system -- the rules are executed on the clothing types.

### Command and CommandFactory
An IGettingReadyCommand interface defines the basic requirements of a command. The command holds a reference to the Person object
on which it will operate and uses a WeatherType to make any weather dependent decisions. The command returns a string output 
describing what happened (i.e. Removing pjs). Typically I would prefer for an execution method such as this to have a void return type, 
but I found it preferable to return the output as opposed to using an out variable or separately getting the information from
an Output property after the call was made. 

A CommandFactory is used to create commands from their corresponding integer command line arguments. The CommandFactory uses 
reflection to find all implementations of IGettingReadyCommand and holds metadata about them, which allows for users to ask for 
a list of available commands. These qualities allow any new implementation of IGettingReadyCommand will automatically be 
added the next time the program runs and can be made visible to end users with no changes to the UI. 

### Rule and RuleRepository
I decided to use rules to separately decide whether a command is allowed. This allows for separateion of concerns -- the command
only cares about executing its action and doesn't know anything about whether it's allowed to or not. The rule will only care about
whether a command is allowed to run based on the current state. IGettingReadyRule provides the basic requirements, and 
GettingReadyRuleBase abstract class provides a base implementation for the code that will be common across all concrete 
implementations. A rule only cares about the state of the person object it is given, and the current WeatherType. Each rule is
self contained and multiple rules may apply to any given command.

The RulesRepository uses reflection to locate all concrete implementations of IGettingReadyRule, create an instance of each one,
and return them all in a collection. Any new rules that are created will automatically be discovered through reflection.

### UI
The requirements gave a very specific input type (i.e. HOT 8, 6, 4, 2, 1, 7), which matches well with command line arguments. I chose
to implement this solution using a C# Console application. Because of the way the rules and commands were designed, the system is
not tightly coupled with the UI at all and has significant flexibility on what input implementations could be provided.

## Possible next steps

### Config / database
If more commands and rules will be created, but end users will have slightly different requirements, using reflection to discover 
all rules and commands would no longer work. In this scenario, creating a config section or database that allows which commands and 
rules apply only to this specific access point would be a good next step. The instances themselves would still be created via
reflection -- just the discovery of which commands and rules apply to this system would be deferred to config or database. 

### More robust UI
This implementation uses a console application, but has no coupling to this implementation. It could easily be extended to a more 
robust UI, such as WPF, UWP, or even a web based UI with the addition of services. With minor tweaks, an implementation with a GUI 
could be provided that allows an end user to make command choices without failure by giving the user a list of possible valid
commands at any given state. 
