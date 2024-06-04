//сейчас программа уязвима к множественным пробелам между словами
var dictionary = new Dictionary<string, string>();

string addTranslation = "AddTranslation";
string removeTranslation = "RemoveTranslation";
string changeTranslation = "ChangeTranslation";
string translate = "Translate";

Console.WriteLine("Русско-английский словарь.");
Console.WriteLine("Список команд: " +
                  $"\n\r{addTranslation} <русский> <английский> - добавить перевод слова" +
                  $"\n\r{removeTranslation} <русский> - удалить перевод слова" +
                  $"\n\r{changeTranslation} <русский> <английский> - изменить перевод уже существующего слова" +
                  $"\n\r{translate} <русский> - перевести слово");

string userRequest = null;
string command = null;
string word1 = null;
string word2 = null;
while (true) //в следующей версии добавлю выход из цикла при нажатии Esc
{
    userRequest = Console.ReadLine().Trim();
    command = userRequest.ToLower().Substring(0, userRequest.IndexOf(' '));
    userRequest = userRequest.Substring(userRequest.IndexOf(" ") + 1);
    if (userRequest.IndexOf(" ") !=  -1)
    {
        word1 = userRequest.Substring(0, userRequest.IndexOf(" "));
    }
    else { word1 = userRequest.Trim(); }
    if (command == addTranslation.ToLower())
    {
        word2 = userRequest.Substring(userRequest.IndexOf(" "));
        if (!dictionary.ContainsKey(word1))
        {
            dictionary.Add(word1, word2);
            Console.WriteLine("Успешно!");
        }
        else 
        {
            Console.WriteLine($"{word1} уже есть в словаре, его перевод - {word2}");
        }
    }
    else if (command == removeTranslation.ToLower()) 
    {
        if (dictionary.ContainsKey(word1))
        {
            dictionary.Remove(word1);
            Console.WriteLine("Успешно!");
        }
        else
        {
            Console.WriteLine($"{word1} отсутствует в словаре");
        }
    }
    else if (command == changeTranslation.ToLower()) 
    {
        word2 = userRequest.Substring(userRequest.IndexOf(" "));
        if (dictionary.ContainsKey(word1))
        {
            dictionary[word1] = word2;
            Console.WriteLine("Успешно!");
        }
        else
        {
            Console.WriteLine($"{word1} отсутствует в словаре");
        }
    }
    else if (command == translate.ToLower())
    {
        if (dictionary.ContainsKey(word1))
        {
            Console.WriteLine($"{word1} переводится как {dictionary[word1]}");
        }
        else
        {
            Console.WriteLine($"{word1} отсутствует в словаре");
        }
    }
    else { Console.WriteLine("Данная команда не найдена"); }
}