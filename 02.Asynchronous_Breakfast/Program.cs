using Shared.Entities;
using Shared;
using System;
using System.Threading.Tasks;

namespace _02.Asynchronous_Breakfast
{
    /// <summary>
    /// Este código utiliza la asincronicidad, aunque aún no está lo suficientemente pulido.
    /// No produce un bloqueo mientras se cocinan los huevos o el beicon, pero tampoco inicia otras tareas. 
    /// Es decir, pondría el pan en la tostadora y se quedaría esperando a que estuviera listo, pero, por lo menos, 
    /// si alguien reclamara su atención, le haría caso. 
    /// En un restaurante en el que se atienden varios pedidos, el cocinero empezaría a preparar otro desayuno mientras se 
    /// hace el primero.
    /// 
    /// El subproceso que se encarga del desayuno ya no se bloquearía mientras espera por las tareas iniciadas que aún no han terminado.
    /// Original: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/async/
    /// Otros enlaces interesantes: https://www.campusmvp.es/recursos/post/async-y-await-en-c-como-manejar-asincronismo-en-net-de-manera-facil.aspx
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            DateTime startDate = DateTime.Now;

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = await FryEggsAsync(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = await FryBaconAsync(3);
            Console.WriteLine("bacon is ready");

            Toast toast = await ToastBreadAsync(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");

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

        private static async Task<Toast> ToastBreadAsync(int slices)
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
        
        private static async Task<Bacon> FryBaconAsync(int slices)
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
        
        private static async Task<Egg> FryEggsAsync(int howMany)
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
