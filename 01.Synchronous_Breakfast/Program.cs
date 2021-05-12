using Shared.Entities;
using Shared;
using System;
using System.Threading.Tasks;

namespace _01.Synchronous_Breakfast
{
    /// <summary>
    /// Los equipos no interpretan estas instrucciones de la misma manera que las personas. 
    /// El equipo se bloqueará en cada instrucción hasta que el trabajo se complete antes de pasar a la instrucción siguiente. 
    /// Podría decirse que esto da lugar a un desayuno poco satisfactorio. Las tareas posteriores no se pueden iniciar mientras 
    /// no se completen las anteriores. 
    /// Es como si usted se quedara mirando la tostadora después de meter el pan y no pudiera oír a nadie que le dirigiera la palabra hasta que las tostadas estuvieran listas.    

    /// Original: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/async/
    /// Otros enlaces interesantes: https://www.campusmvp.es/recursos/post/async-y-await-en-c-como-manejar-asincronismo-en-net-de-manera-facil.aspx
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.Now;

            Console.WriteLine("Hello World!");
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = FryEggs(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("bacon is ready");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
            Console.WriteLine("toast is ready");

            DateTime endDate = DateTime.Now;
            Console.WriteLine("Total time: " + (endDate - startDate).TotalSeconds + " seconds");
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(SharedConstants.DelayTime).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(SharedConstants.DelayTime).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(SharedConstants.DelayTime).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(SharedConstants.DelayTime).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}
