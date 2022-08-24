// EXERCICIO 2
using System.Diagnostics;

List<Thread> fruits = new List<Thread>();

Random r = new();

Thread banana = new Thread(() => PrintFruit("Banana", r.Next(0, 3000)));
Thread orange = new Thread(() => PrintFruit("Orange", r.Next(0, 3000)));
Thread peach = new Thread(() => PrintFruit("Peach", r.Next(0, 3000)));
Thread apple = new Thread(() => PrintFruit("Apple", r.Next(0, 3000)));
Thread strawberry = new Thread(() => PrintFruit("Strawberry", r.Next(0, 3000)));

fruits.Add(banana);
fruits.Add(orange);
fruits.Add(peach);
fruits.Add(apple);
fruits.Add(strawberry);

Stopwatch stopwatch = new();

stopwatch.Start();

fruits.ForEach(fruit => fruit.Start());

while (fruits.Any(x => x.ThreadState != System.Threading.ThreadState.Stopped))
{
}

stopwatch.Stop();

Console.WriteLine(stopwatch.Elapsed.ToString());

static void PrintFruit(string s, int waitTime)
{
    Thread.Sleep(waitTime);
    Console.WriteLine(s + "\n");
}