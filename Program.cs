using System;
using System.Collections.Generic;

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

// Strategy Pattern
public interface ITradingStrategy
{
    void Execute(string stockSymbol);
}

public class BuyStrategy : ITradingStrategy
{
    public void Execute(string stockSymbol)
    {
        Console.WriteLine($"Buying {stockSymbol} stocks");
        // Additional logic for buying stocks
    }
}

public class SellStrategy : ITradingStrategy
{
    public void Execute(string stockSymbol)
    {
        Console.WriteLine($"Selling {stockSymbol} stocks");
        // Additional logic for selling stocks
    }
}

// Command Pattern
public interface ICommand
{
    void Execute();
}

public class TradeCommand : ICommand
{
    private readonly ITradingStrategy _strategy;
    private readonly string _stockSymbol;

    public TradeCommand(ITradingStrategy strategy, string stockSymbol)
    {
        _strategy = strategy;
        _stockSymbol = stockSymbol;
    }

    public void Execute()
    {
        _strategy.Execute(_stockSymbol);
    }
}

// Context
public class TradingSystem
{
    private readonly List<IObserver> _observers = new List<IObserver>();

    public void AttachObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void NotifyObservers(string stockSymbol, double price)
    {
        foreach (var observer in _observers)
        {
            observer.Update(stockSymbol, price);
        }
    }

    public void ExecuteTrade(ICommand tradeCommand)
    {
        tradeCommand.Execute();
    }
}

class Program
{
    static void Main()
    {
        var tradingSystem = new TradingSystem();

        // Observer Pattern
        var tradeObserver = new TradeObserver();
        tradingSystem.AttachObserver(tradeObserver);

        // Strategy Pattern
        ITradingStrategy buyStrategy = new BuyStrategy();
        ITradingStrategy sellStrategy = new SellStrategy();

        // Command Pattern
        ICommand buyCommand = new TradeCommand(buyStrategy, "AAPL");
        ICommand sellCommand = new TradeCommand(sellStrategy, "GOOGL");

        // Simulate stock prices changes
        tradingSystem.NotifyObservers("AAPL", 150.0);
        tradingSystem.NotifyObservers("GOOGL", 2000.0);

        // Execute trading strategies
        tradingSystem.ExecuteTrade(buyCommand);
        tradingSystem.ExecuteTrade(sellCommand);
    }
}
