# Class Library

[Back](../README.md)

A simple way to demonstrate patterns and principles is with a class library.

# Single Responsibility Principle (SRP)

> "There should never be more than one reason for a class to change."

-- *Robert C. Martin*

# Open/Closed Principle (OCP)

> "Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification"

-- *Wikipedia* ([Open–closed principle - Wikipedia](https://en.wikipedia.org/wiki/Open–closed_principle/))

This can be seen at [Services/Cart.cs](PatternsAndPrinciples/ShoppingCart/Services/Cart.cs)

# Liskov substitution principle (LSP)

> "Subtypes must be substitutable for their base types."

-- *Named for Barbara Liskov*

# Interface segregation principle (ISP)

> "Clients should not be forced to depend on methods they do not use."

-- *Robert C. Martin*

This can be seen at [Interfaces/IPricingCalculator.cs](PatternsAndPrinciples/ShoppingCart/Interfaces/IPricingCalculator.cs)

# Dependency Inversion Principle (DIP)

> "High-level modules should not depend on low-level modules.  Both should depend on abstractions. Furthermore, abstractions should not depend on details, but rather details should depend on abstractions."

-- *Robert C. Martin and Micah Martin*

This can be seen at [Services/Cart.cs](PatternsAndPrinciples/ShoppingCart/Services/Cart.cs)

# Install MS Test 

To use MS Text in our Class Library, install the following packages from nuget:

* Microsoft.NET.Test.Sdk 
* MSTest.TestAdapter
* MSTest.TestFramework

[Back](../README.md)