using System.Diagnostics;
//3 PROBLEMAS COM THREADS

// EXERCICIO 1
Thread thread = new Thread(ThreadFunction);

thread.Start();

while (thread.ThreadState == System.Threading.ThreadState.Running)
{
}

Console.WriteLine("Programa finalizado");

static void ThreadFunction()
{
    for (int i = 0; i <= 100; i++)
    {
        Console.WriteLine(i.ToString());
    }
}

// EXERCICIO 2
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

// EXERCICIO 3
/* Sim, isso é uma situação possível com threads, caso não haja o tratamento e as duas
sejam chamadas ao mesmo tempo. Para contornar esse problema, pode-se fazer uma
verificação que aguarda o método atualizar() concluir primeiro para que, depois, uma nova
thread seja instanciada, chamando o método depósito(). Eu demonstrei essa validação nos
meus exercícios, pela verificação do estado da thread. Utilizando essa lógica, segue um
exemplo que poderia resolver: */

object Identity = new();

Thread updateThread = new(Atualizar);
Thread depositThread = new(Depositar);

updateThread.Start();
depositThread.Start();

while (updateThread.ThreadState == System.Threading.ThreadState.Running)
{
}


//Métodos mockup
void Depositar()
{
    lock (Identity)
    {
        //do
    }
}

void Atualizar()
{
    lock (Identity)
    {
        //do
    }
}

