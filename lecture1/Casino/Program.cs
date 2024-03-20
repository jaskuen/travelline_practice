int balance = 10000;
Random rnd = new Random();
Console.WriteLine($"Добро пожаловать! Ваш текущий баланс: {balance}. Вы хотите сыграть? Нажмите ENTER, чтобы начать");
ConsoleKeyInfo key = Console.ReadKey();
bool exit = key.Key != ConsoleKey.Enter;
string betStr = null;
int bet = 0;
int randomNum = 0;
int multiplicator = 100;
while (balance > 0 && !exit)
{
    Console.Write("Введите вашу ставку: ");
    betStr = Console.ReadLine();
    bet = Int32.Parse(betStr);
    randomNum = rnd.Next(20) + 1;
    if (randomNum >= 18)
    {
        Console.WriteLine($"Поздравляем, вы победили! Выпало число {randomNum}.");
        balance += bet * (1 + ( randomNum * multiplicator % 17));
        Console.WriteLine($"Ваш выигрыш: {bet}.");
    }
    else
    {
        Console.WriteLine($"Увы, вы проиграли(. Выпало число {randomNum}.");
        balance -= bet;
    }
    Console.WriteLine($"Ваш текущий баланс: {balance}");
    Console.WriteLine("Если хотите продолжить игру, нажмите ENTER:");
    exit = Console.ReadKey().Key != ConsoleKey.Enter;
}
if (balance < 0)
{
    Console.WriteLine($"Вы должны нам {-balance}!");
}
Console.WriteLine("Спасибо за игру! Приходите ещё!");