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
