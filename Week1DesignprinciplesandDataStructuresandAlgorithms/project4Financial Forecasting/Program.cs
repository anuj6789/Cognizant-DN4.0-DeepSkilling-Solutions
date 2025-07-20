using System;

class Program
{
    
    static double Forecast(double currentValue, double[] growthRates, int period = 0)
    {
        if (period >= growthRates.Length)
            return currentValue; 

        double nextValue = currentValue * (1 + growthRates[period]);
        return Forecast(nextValue, growthRates, period + 1); 
    }

    static void Main()
    {
        double startingValue = 1000;
        double[] growthRates = { 0.05, 0.07, 0.06, 0.08 }; 

        double result = Forecast(startingValue, growthRates);

        Console.WriteLine("Financial Forecasting Tool");
        Console.WriteLine("==========================");
        Console.WriteLine($"Starting value: ${startingValue}");
        Console.WriteLine($"Forecast after 4 periods: ${result:F2}");
    }
}
