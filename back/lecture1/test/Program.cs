Console.Write("Введите название товара: ");
string productName = Console.ReadLine();
Console.Write("Введите кол-во единиц товара: ");
string productCountStr = Console.ReadLine();
int productCount = Int32.Parse(productCountStr);
Console.Write("Введите Ваше имя: ");
string username = Console.ReadLine();
Console.Write("Введите адрес желаемой доставки: ");
string deliveryAddress = Console.ReadLine();
Console.WriteLine("Здравствуйте, " + username + ", вы заказали " + productCount + " " + productName + " на адрес " + deliveryAddress + ", все верно? Нажмите ENTER, чтобы подтвердить.");
ConsoleKeyInfo key = Console.ReadKey();
DateTime dateToday = DateTime.Now;
if (key.Key == ConsoleKey.Enter)
{
    Console.WriteLine(username + "!");
    Console.WriteLine("Ваш заказ " + productName + " в количестве " + productCount + " оформлен!");
    Console.WriteLine("Ожидайте доставку по адресу " + deliveryAddress + " к " + dateToday.AddDays(3));
}
else
{
    Console.WriteLine(username + ", до следующего заказа!");
}

