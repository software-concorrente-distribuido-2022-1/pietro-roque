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
