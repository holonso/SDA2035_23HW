using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace p23ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Факториал какого числа будем вычислять? :");
            int n = Convert.ToInt32(Console.ReadLine());
            //Асинхронный метод вычисления факториал с задержкой 100мс
            Task.Run(() => FactorialAsync(n));
            //Проверка выполненя асинхр.метода из под Main с задержкой 200мс 
            int s = 1;
            for (int j = 1; j <= n; j++)
            {
                s *= j;
                Console.WriteLine("Проверка в методе Main. Прогресс: {0}", s);
                Thread.Sleep(200);
            }
            Console.WriteLine("Проверка в методе Main завершена");

            Console.ReadKey();

        }
        static async Task<int> FactorialAsync(int n)
        {
            int result = await Task.Run(() =>
            {
                int f = 1;
                for (int i = 1; i <= n; i++)
                {
                    f *= i;
                    Console.WriteLine("Асинхронное вычисление факториала. Прогресс: {0}", f);
                    Thread.Sleep(100);
                }
                return f;
            });
            return result;
        }
    }
}
