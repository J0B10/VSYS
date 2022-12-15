using Microsoft.Extensions.DependencyInjection;

class Program
{
    interface IRun
    {
        void run();
    }

    class MyApp : IRun
    {
        ITime t;

        public MyApp(ITime t)
        {
            this.t = t;
        }
        public void run()
        {
            System.Console.WriteLine("Zeit="+t.time());
        }
    }

    interface ITime
    {
        String time();
    }

    class MyLocalTime : ITime
    {
        public string time()
        {
            return DateTime.Now.ToString();
        }
    }

    class MyDummyTime : ITime
    {
        public string time()
        {
            return "Dummy="+(new System.DateTime());
        }
    }

    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddSingleton<IRun, MyApp>();
        services.AddSingleton<ITime, MyDummyTime>();
        var sp = services.BuildServiceProvider();
        IRun? app = sp.GetService<IRun>();
        if (app != null) {
            app.run();
        }
    }
}