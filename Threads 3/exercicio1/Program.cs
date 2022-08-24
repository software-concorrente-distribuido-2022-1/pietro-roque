using System.Diagnostics;

// EXERCICIO 1
Thread itemA = new(() => CheckPrimeNumbers(1000000, 30000000));
Thread itemB = new(() => CheckPrimeNumbers(90000000, 1200000000));

Stopwatch totalTimestamp = new();

itemA.Start();
totalTimestamp.Start();

while (itemA.ThreadState != System.Threading.ThreadState.Stopped)
{
}

totalTimestamp.Stop();

Console.WriteLine("\n");

itemB.Start();
totalTimestamp.Start();

while (itemB.ThreadState != System.Threading.ThreadState.Stopped)
{
}

totalTimestamp.Stop();

Console.WriteLine("Tempo total: " + totalTimestamp.Elapsed.ToString());

static void CheckPrimeNumbers(int start, int end)
{
    List<int> result = new();
    int num, i, flag = 0;
    int counter = 0;

    for (num = start; num <= end; num++)
    {
        flag = 0;

        for (i = 2; i <= num / 2; i++)
        {
            if (num % i == 0)
            {
                flag++;
                break;
            }
        }

        if (flag == 0 && num != 1)
        {
            counter++;
            result.Add(num);
        }
    }

    foreach (int item in result)
    {
        Console.Write(item + ", ");
    }

    Console.WriteLine("\nTotal de números primos " + counter);
}