using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _03.Asynchronous_WhenAny_Breakfast
{
    /// <summary>
    /// Este código utiliza la asincronicidad de una manera óptima.
    /// La serie de instrucciones await al final del código anterior se puede mejorar mediante el uso de métodos de la clase Task. 
    /// Una de estas API es <WhenAll>, que devuelve un objeto Task que se completa cuando finalizan todas las tareas de la lista 
    /// de argumentos, como se muestra en el código siguiente:
    /// 
    /// await Task.WhenAll(eggsTask, baconTask, toastTask);
    /// Console.WriteLine("eggs are ready");
    /// Console.WriteLine("bacon is ready");
    /// Console.WriteLine("toast is ready");
    /// Console.WriteLine("Breakfast is ready!");
    /// 
    /// Otra opción consiste en usar <WhenAny></WhenAny>, que devuelve un objeto Task<Task> que se completa cuando finaliza 
    /// cualquiera de sus argumentos. Puede esperar por la tarea devuelta, con la certeza de saber que ya ha terminado. 
    /// En el código siguiente se muestra cómo se puede usar WhenAny para esperar a que la primera tarea finalice y, después, 
    /// procesar su resultado. Después de procesar el resultado de la tarea completada, quítela de la lista de tareas que se pasan 
    /// a WhenAny.
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

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");

            DateTime endDate = DateTime.Now;
            Console.WriteLine("Total time: " + (endDate - startDate).TotalSeconds + " seconds");
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
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
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
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