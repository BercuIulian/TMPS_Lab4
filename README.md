# Behavioral Design Patterns


## Author: Bercu Iulian

----

## Objectives:

*  Study and understand the Behavioral Design Patterns.

*  As a continuation of the previous laboratory work, think about what communication between software entities might be involed in your system.

*  Create a new Project or add some additional functionalities using behavioral design patterns.




## Used Design Patterns: 

* Observer
* Strategy
* Command


## Implementation

The implementation employs the Observer Pattern by having a TradeObserver receive updates from a financial TradingSystem about changes in stock prices. The Strategy Pattern is applied through BuyStrategy and SellStrategy classes, defining distinct trading strategies, while the Command Pattern is used to encapsulate these strategies in TradeCommand instances, enabling the TradingSystem to execute them flexibly. The main method demonstrates the coordination of these patterns, attaching an observer, notifying about stock price changes, creating trade commands, and executing them within the financial trading system.


* Snippets from my files.


```
// Observer Pattern
public interface IObserver
{
    void Update(string stockSymbol, double price);
}

public class TradeObserver : IObserver
{
    public void Update(string stockSymbol, double price)
    {
        Console.WriteLine($"TradeObserver: Stock {stockSymbol} traded at {price}");
    }
}

```


## Conclusions / Screenshots / Results

In conclusion, the implementation showcases the effective use of behavioral design patterns—Observer, Strategy, and Command—in a financial trading system. These patterns enhance modularity and flexibility, allowing for the dynamic observation of stock price changes, the definition of diverse trading strategies, and the encapsulation and execution of those strategies through commands. This modular approach promotes maintainability and extensibility in designing complex systems by separating concerns and facilitating the addition of new features with minimal impact on existing code.


* The result of running the program

  ![image](https://github.com/BercuIulian/TMPS_Lab4/assets/113422203/386b6beb-2904-406f-ba03-9c9fa7bcdf8c)



