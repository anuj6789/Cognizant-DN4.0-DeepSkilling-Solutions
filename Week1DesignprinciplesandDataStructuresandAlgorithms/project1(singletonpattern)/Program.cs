using Singletonpattern;

class Program
{
    static void Main()
    {
      
        Logger.Instance.Log("First log entry");
        Logger.Instance.Log("Second log entry");

        
        var logger1 = Logger.Instance;
        var logger2 = Logger.Instance;

        if (logger1 == logger2)
        {
            Logger.Instance.Log("Both logger1 and logger2 refer to the same instance.");
        }
    }
}
