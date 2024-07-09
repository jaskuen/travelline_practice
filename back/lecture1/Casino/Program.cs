using Microsoft.VisualBasic;

int balance = 10000;
Random rnd = new Random();
Console.WriteLine($"Добро пожаловать! Ваш текущий баланс: {balance}. Вы хотите сыграть? Нажмите ENTER, чтобы начать");
ConsoleKeyInfo key = Console.ReadKey();
bool isPlaying = key.Key == ConsoleKey.Enter;
string betStr = null;
int bet = 0;
int randomNum = 0;
int multiplicator = 100;
const int MAX_ROLL_NUMBER = 20;
const int MIN_WIN_NUMBER = 18;// [0] - максимально возможное число, [1] - минимальное выигрышное число
while (balance > 0 && isPlaying)
{
    Console.Write("Введите вашу ставку: ");
    betStr = Console.ReadLine();
    while (!Int32.TryParse(betStr, out bet))
    {
        Console.WriteLine("Неправильный формат числа, попробуйте ещё раз!");
    }
    randomNum = rnd.Next(MAX_ROLL_NUMBER) + 1;
    if (randomNum >= MIN_WIN_NUMBER)
    {
        Console.WriteLine($"Поздравляем, вы победили! Выпало число {randomNum}.");
        balance += bet * (1 + (randomNum * multiplicator % 17));
        Console.WriteLine($"Ваш выигрыш: {bet}.");
    }
    else
    {
        Console.WriteLine($"Увы, вы проиграли(. Выпало число {randomNum}.");
        balance -= bet;
    }
    Console.WriteLine($"Ваш текущий баланс: {balance}");
    Console.WriteLine("Если хотите продолжить игру, нажмите ENTER:");
    isPlaying = Console.ReadKey().Key == ConsoleKey.Enter;
}
if (balance < 0)
{
    Console.WriteLine($"Вы должны нам {-balance}!");
}
Console.WriteLine("Спасибо за игру! Приходите ещё!");