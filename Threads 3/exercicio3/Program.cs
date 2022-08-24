// EXERCICIO 3
List<Thread> corrida = new();

Thread lebre1 = new(() => Jump());
Thread lebre2 = new(() => Jump());
Thread lebre3 = new(() => Jump());
Thread lebre4 = new(() => Jump());
Thread lebre5 = new(() => Jump());

corrida.Add(lebre1);
corrida.Add(lebre2);
corrida.Add(lebre3);
corrida.Add(lebre4);
corrida.Add(lebre5);

corrida.ForEach(t => t.Start());

if (corrida.Any(t => t.ThreadState != ThreadState.Running))
{
    Thread winner = corrida.Where(t => t.ThreadState == ThreadState.Stopped).First();
    corrida.Where(t => t.ThreadState == ThreadState.Running).ToList().ForEach(t => t.Abort());

    Console.WriteLine("Thread vencedora " + winner.Name);

}

static void Jump()
{
    int i = 0;
    int jumps = 0;
    Random r = new Random();

    while (i <= 20)
    {
        if (i >= 20) break;

        int random = r.Next(1, 3);

        i += random;
        jumps++;
    }

    Console.WriteLine("Número de pulos " + jumps.ToString());
}