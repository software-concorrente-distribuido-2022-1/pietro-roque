// EXERCICIO 2
Random r1 = new Random();

int x = 10;
int[] A = new int[100];

for (int i = 0; i < A.Length; i++)
{
    A[i] = i;
}

int mid = (A.Length + 1) / 4;

int[] firstHalf = A.Take(mid).ToArray();
int[] secondHalf = A.Skip(mid).Take(mid * 2).ToArray();

object[] result = new object[] { firstHalf, secondHalf };

Random r2 = new Random();

int func = ParallelSearch(x, A, 2);

Console.WriteLine(func);

static int ParallelSearch(int x, int[] A, int numThreads)
{
    List<Thread> threads = new();

    bool foundIt = false;

    for (int i = 0; i < numThreads; i++)
    {
        Thread threadWithParam = new Thread(new ParameterizedThreadStart((object obj) =>
        {
            for (int j = 0; j <= A.Length; j++)
            {
                if (i == x)
                {
                    foundIt = true;
                    Console.WriteLine(i.ToString());
                    break;
                }
            }
        }));

        threadWithParam.Start();
        if (foundIt) return 1;
    }

    return -1;
}
