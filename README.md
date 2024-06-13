# C# Exercise 5 - Garage 1.0

**NOTE** - The result of the exercise must be shown to a teacher and approved before it can be considered completed.

## An initial comprehensive project

To tie together much of what you have learned, we will now build a garage application.

This application should provide the functionality that a system might need if it is to be used to simulate a simple garage. This means being able to park vehicles, retrieve vehicles, check which vehicles are there and what properties they have. All of this in a console application with a main menu and submenus.

The reason you should program a garage is that it is easy to anchor the division in the whole. We can mainly divide a garage into the following parts:

### The Garage
A representation of the building itself. The garage is a place where a number of vehicles can be stored. The garage can therefore be represented as a collection of vehicles.

### Vehicles
Cars, motorcycles, unicycles, or whatever type of vehicle you want to place in the garage.

These are the two "object types" that you see in a physical garage. But if we look closer, there should also be subclasses of vehicles, meaning that each vehicle type is its own subclass in the system. In addition, functionality is required to handle placing vehicles in the garage, retrieving vehicles from the garage, and getting a presentation of what is in the garage and searching it.

In more programming-friendly terms, we should at a minimum have:

- A collection of vehicles; the Garage class.
- A vehicle class, the Vehicle class.
- A number of subclasses for vehicles.
- A user interface that allows us to use the functionality of a garage. Here all interaction with the user occurs.
- A GarageHandler. To abstract a layer so that there is no direct contact between the user interface and the garage class. This is suitably done through a class that handles the functionality that the interface needs access to.
- We do not program directly against concrete types, so we use interfaces for this, e.g., IUI, IHandler, IVehicle. (Tip is to extract to interfaces when the implementation is complete if you find this part difficult)

## Requirements Specification

Vehicles should be implemented as the Vehicle class and subclasses of it.
- Vehicle contains all the properties that should exist in all vehicle types, e.g., registration number, color, number of wheels, and other properties you can think of.
- The registration number is unique.
- There must be at least the following subclasses:
  - Airplane
  - Motorcycle
  - Car
  - Bus
  - Boat
- These should each implement at least one unique property, such as:
  - Number of Engines
  - Cylinder volume
  - Fuel type (Gasoline/Diesel)
  - Number of seats
  - Length

The garage itself should be implemented as a generic collection of vehicles:

```csharp
class Garage<T>
```

Moreover, the generic type should be constrained using a constraint:

```csharp
class Garage<T> where ...
```

Furthermore, it should be possible to iterate over an instance of Garage using foreach. This means that Garage should implement the generic variant of the IEnumerable interface:

```csharp
class Garage<T> : ...
```

The class does not need to inherit from any other class or implement any other interface.

The collection of vehicles should be handled internally in the class as an array. The internal array should be private. When instantiating a new garage, the capacity must be specified as an argument to the constructor.

**We should NOT use a List<Vehicle> internally in the Garage class!**

## Functionality

It should be possible to:
- List all parked vehicles
- List vehicle types and how many of each are in the garage
- Add and remove vehicles from the garage
- Set a capacity (number of parking spaces) when instantiating a new garage
- Populate the garage with a number of vehicles from the start
- Find a specific vehicle via the registration number. It should work with both ABC123 and Abc123 or AbC123.
- Search for vehicles based on one or more properties (all possible combinations from the base class Vehicle). For example:
  - All black vehicles with four wheels.
  - All pink motorcycles with 3 wheels.
  - All trucks
  - All red vehicles
- The user should receive feedback on whether things have gone well or badly. For example, when we park a vehicle, we want confirmation that the vehicle is parked. If it does not work, the user should know why.

The program should be a console application with a text-based user interface.

From the interface, it should be possible to:
- Navigate to all functionality of the garage via the interface
- Create a garage with a user-specified size
- It should be possible to shut down the application from the interface

The application should robustly handle input errors, so it does not crash with incorrect input or usage.

## Unit Testing

Tests should be created in a separate test project. We limit ourselves to testing the public methods in the Garage class. (Writing tests for the entire application is considered an extra task if time permits)

Feel free to experiment with writing the tests before you have implemented the functionality! Then use ctrl . to generate your objects and methods. Then implement the functionality until the test passes.

Structure the tests according to the principle:

1. Arrange: set up what is to be tested, instantiate objects and inputs
2. Act: call the method to be tested
3. Assert: check that you got the expected result

Also, remember to name the tests in an explanatory way. When a test fails, we want to know what did not work just by looking at the test method name.

For example:
```csharp
[MethodName_StateUnderTest_ExpectedBehavior]

public void Sum_NegativeNumberAs1stParam_ExceptionThrown()
```

## Extra:

Handle multiple garages that can have different types of vehicles in them, such as a hangar, a regular garage, and a motorcycle garage. This will mean that you should be able to navigate between the different garages in the UI to perform the previously mentioned functions on only the garage that is currently selected. It should be clearly shown which garage you are currently working with.

It is possible in C# to write to and read from the file system from your application. Find out how to do this to be able to save your garage (via menu or automatically on shutdown) and load your garage (via menu or automatically on application start).

Ability to also search for vehicle-specific properties.

Read the size of the garage from configuration.

Optional functionality you think should be included.

Good luck!
